# -*-coding:Utf-8 -*

'''
Created on 25 avr. 2012

@author: Compère Christopher
'''

import threading
import Queue
import time

#Valeur des capteurs pour log DB
temperature1_db = Queue.Queue(1)
temperature2_db = Queue.Queue(1)
temperature3_db = Queue.Queue(1)
temperature4_db = Queue.Queue(1)
temperature5_db = Queue.Queue(1)
temperature6_db = Queue.Queue(1)
temperature7_db = Queue.Queue(1)
temperature8_db = Queue.Queue(1)
adc1_db = Queue.Queue(1)
adc2_db = Queue.Queue(1)
adc3_db = Queue.Queue(1)
adc4_db = Queue.Queue(1)
accelerometer1_db = Queue.Queue(1)
hygrometer1_db = Queue.Queue(1)
hygrometer2_db = Queue.Queue(1)
impuls1_db = Queue.Queue(1)
impuls2_db = Queue.Queue(1)

#Valeur des capteurs pour US
temperature1_US = Queue.Queue(1)
temperature2_US = Queue.Queue(1)
temperature3_US = Queue.Queue(1)
temperature4_US = Queue.Queue(1)
temperature5_US = Queue.Queue(1)
temperature6_US = Queue.Queue(1)
temperature7_US = Queue.Queue(1)
temperature8_US = Queue.Queue(1)
adc1_US = Queue.Queue(1)
adc2_US = Queue.Queue(1)
adc3_US = Queue.Queue(1)
adc4_US = Queue.Queue(1)
accelerometer1_US = Queue.Queue(1)
hygrometer1_US = Queue.Queue(1)
hygrometer2_US = Queue.Queue(1)
impuls1_US = Queue.Queue(1)
impuls2_US = Queue.Queue(1)

#Valeur des capteurs pour Bluetooth
temperature1_BT = Queue.Queue(1)
temperature2_BT = Queue.Queue(1)
temperature3_BT = Queue.Queue(1)
temperature4_BT = Queue.Queue(1)
temperature5_BT = Queue.Queue(1)
temperature6_BT = Queue.Queue(1)
temperature7_BT = Queue.Queue(1)
temperature8_BT = Queue.Queue(1)
adc1_BT = Queue.Queue(1)
adc2_BT = Queue.Queue(1)
adc3_BT = Queue.Queue(1)
adc4_BT = Queue.Queue(1)
accelerometer1_BT = Queue.Queue(1)
hygrometer1_BT = Queue.Queue(1)
hygrometer2_BT = Queue.Queue(1)
impuls1_BT = Queue.Queue(1)
impuls2_BT = Queue.Queue(1)

#Valeur des capteurs pour la régulation
adc1_reg = Queue.Queue(1)
adc2_reg = Queue.Queue(1)
adc3_reg = Queue.Queue(1)
adc4_reg = Queue.Queue(1)
accelerometer1_reg = Queue.Queue(1)

timeoutBeforeResponse = 0.1

class SensorInterface(threading.Thread):
    '''
    classdocs
    '''
    def __init__(self, comPort3964r):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self.sensorComPort = comPort3964r
        self._Frequency = 850
    
    def run(self):
        while 1:
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x40', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:
                if temperature1_db.full() == True:
                    temperature1_db.get()
                temperature1_db.put(tab_data)
                if temperature1_US.full() == True:
                    temperature1_US.get()
                temperature1_US.put(tab_data)
                if temperature1_BT.full() == True:
                    temperature1_BT.get()
                temperature1_BT.put(tab_data)
                print "Temperature 1 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
            
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x41', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:
                if temperature2_db.full() == True:
                    temperature2_db.get()
                temperature2_db.put(tab_data)
                if temperature2_US.full() == True:
                    temperature2_US.get()
                temperature2_US.put(tab_data)
                if temperature2_BT.full() == True:
                    temperature2_BT.get()
                temperature2_BT.put(tab_data)
                print "Temperature 2 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
            
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x42', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:
                if temperature3_db.full() == True:
                    temperature3_db.get()
                temperature3_db.put(tab_data)
                if temperature3_US.full() == True:
                    temperature3_US.get()
                temperature3_US.put(tab_data)
                if temperature3_BT.full() == True:
                    temperature3_BT.get()
                temperature3_BT.put(tab_data)
                print "Temperature 3 : " + str(tab_data)            
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x43', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:
                if temperature4_db.full() == True:
                    temperature4_db.get()
                temperature4_db.put(tab_data)
                if temperature4_US.full() == True:
                    temperature4_US.get()
                temperature4_US.put(tab_data)
                if temperature4_BT.full() == True:
                    temperature4_BT.get()
                temperature4_BT.put(tab_data)
                print "Temperature 4 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                                    
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x44', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:
                if temperature5_db.full() == True:
                    temperature5_db.get()
                temperature5_db.put(tab_data)
                if temperature5_US.full() == True:
                    temperature5_US.get()
                temperature5_US.put(tab_data)
                if temperature5_BT.full() == True:
                    temperature5_BT.get()
                temperature5_BT.put(tab_data)
                print "Temperature 5 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x45', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if temperature6_db.full() == True:
                    temperature6_db.get()
                temperature6_db.put(tab_data)
                if temperature6_US.full() == True:
                    temperature6_US.get()
                temperature6_US.put(tab_data)
                if temperature6_BT.full() == True:
                    temperature6_BT.get()
                temperature6_BT.put(tab_data)
                print "Temperature 6 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x46', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if temperature7_db.full() == True:
                    temperature7_db.get()
                temperature7_db.put(tab_data)
                if temperature7_US.full() == True:
                    temperature7_US.get()
                temperature7_US.put(tab_data)
                if temperature7_BT.full() == True:
                    temperature7_BT.get()
                temperature7_BT.put(tab_data)
                print "Temperature 7 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x47', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if temperature8_db.full() == True:
                    temperature8_db.get()
                temperature8_db.put(tab_data)
                if temperature8_US.full() == True:
                    temperature8_US.get()
                temperature8_US.put(tab_data)
                if temperature8_BT.full() == True:
                    temperature8_BT.get()
                temperature8_BT.put(tab_data)
                print "Temperature 8 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x50', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if adc1_db.full() == True:
                    adc1_db.get()
                adc1_db.put(tab_data)
                if adc1_reg.full() == True:
                    adc1_reg.get()
                adc1_reg.put(tab_data)
                if adc1_US.full() == True:
                    adc1_US.get()
                adc1_US.put(tab_data)
                if adc1_BT.full() == True:
                    adc1_BT.get()
                adc1_BT.put(tab_data)
                print "ADC 1 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x51', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if adc2_db.full() == True:
                    adc2_db.get()
                adc2_db.put(tab_data)
                if adc2_reg.full() == True:
                    adc2_reg.get()
                adc2_reg.put(tab_data)
                if adc2_US.full() == True:
                    adc2_US.get()
                adc2_US.put(tab_data)
                if adc2_BT.full() == True:
                    adc2_BT.get()
                adc2_BT.put(tab_data)
                print "ADC 2 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x52', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if adc3_db.full() == True:
                    adc3_db.get()
                adc3_db.put(tab_data)
                if adc3_reg.full() == True:
                    adc3_reg.get()
                adc3_reg.put(tab_data)
                if adc3_US.full() == True:
                    adc3_US.get()
                adc3_US.put(tab_data)
                if adc3_BT.full() == True:
                    adc3_BT.get()
                adc3_BT.put(tab_data)
                print "ADC 3 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x53', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if adc4_db.full() == True:
                    adc4_db.get()
                adc4_db.put(tab_data)
                if adc4_reg.full() == True:
                    adc4_reg.get()
                adc4_reg.put(tab_data)
                if adc4_US.full() == True:
                    adc4_US.get()
                adc4_US.put(tab_data)
                if adc4_BT.full() == True:
                    adc4_BT.get()
                adc4_BT.put(tab_data)
                print "ADC 4 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x60', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if accelerometer1_db.full() == True:
                    accelerometer1_db.get()
                accelerometer1_db.put(tab_data)
                if accelerometer1_reg.full() == True:
                    accelerometer1_reg.get()
                accelerometer1_reg.put(tab_data)
                if accelerometer1_US.full() == True:
                    accelerometer1_US.get()
                accelerometer1_US.put(tab_data)
                if accelerometer1_BT.full() == True:
                    accelerometer1_BT.get()
                accelerometer1_BT.put(tab_data)
                print "Accelerometer 1 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x70', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if hygrometer1_db.full() == True:
                    hygrometer1_db.get()
                hygrometer1_db.put(tab_data)
                if hygrometer1_US.full() == True:
                    hygrometer1_US.get()
                hygrometer1_US.put(tab_data)
                if hygrometer1_BT.full() == True:
                    hygrometer1_BT.get()
                hygrometer1_BT.put(tab_data)
                print "Hygrometer 1 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x71', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if hygrometer2_db.full() == True:
                    hygrometer2_db.get()
                hygrometer2_db.put(tab_data)
                if hygrometer2_US.full() == True:
                    hygrometer2_US.get()
                hygrometer2_US.put(tab_data)
                if hygrometer2_BT.full() == True:
                    hygrometer2_BT.get()
                hygrometer2_BT.put(tab_data)
                print "Hygrometer 2 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x80', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if impuls1_db.full() == True:
                    impuls1_db.get()
                impuls1_db.put(tab_data)
                if impuls1_US.full() == True:
                    impuls1_US.get()
                impuls1_US.put(tab_data)
                if impuls1_BT.full() == True:
                    impuls1_BT.get()
                impuls1_BT.put(tab_data)
                print "Impulsion 1 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
                        
            self.sensorComPort.send_data_3964r(self.sensorComPort.timeout, '\x81', '\x00', '\x00')
            tab_data = self.sensorComPort.get_data_3964r(timeoutBeforeResponse, self.sensorComPort.timeout)
            if tab_data != None:            
                if impuls2_db.full() == True:
                    impuls2_db.get()
                impuls2_db.put(tab_data)
                if impuls2_US.full() == True:
                    impuls2_US.get()
                impuls2_US.put(tab_data)
                if impuls2_BT.full() == True:
                    impuls2_BT.get()
                impuls2_BT.put(tab_data)
                print "Impulsion 2 : " + str(tab_data)
            time.sleep(1./(self._Frequency/17.))
