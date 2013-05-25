# -*-coding:Utf-8 -*

'''
Created on 8 mai 2012

@author: Compère Christopher
'''

import threading

from MotorInterface import motorCommand
from SensorInterface import temperature1_BT, temperature2_BT, temperature3_BT, temperature4_BT, temperature5_BT, temperature6_BT, temperature7_BT, temperature8_BT, adc1_BT, adc2_BT, adc3_BT, adc4_BT, accelerometer1_BT, hygrometer1_BT, hygrometer2_BT, impuls1_BT, impuls2_BT  

class BluetoothCmdWatcher(threading.Thread):
    '''
    classdocs
    '''

    def __init__(self, comPort3964r):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self.ComPort_Bluetooth = comPort3964r
        
    def run(self):
        while(1):
            tab_data = self.ComPort_Bluetooth.get_data_3964r(None, self.ComPort_Bluetooth.timeout)
            if tab_data != None:
                if((tab_data[0] == 'M') or (tab_data[0] == 'K')):
                    motorCommand.put(tab_data)
                else:
                    if(tab_data[0] == '\x40'):
                        if(temperature1_BT.empty() == False):
                            tab_data = temperature1_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x41'):
                        if(temperature2_BT.empty() == False):                        
                            tab_data = temperature2_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x42'):
                        if(temperature3_BT.empty() == False):
                            tab_data = temperature3_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x43'):
                        if(temperature4_BT.empty() == False):
                            tab_data = temperature4_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x44'):
                        if(temperature5_BT.empty() == False):
                            tab_data = temperature5_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x45'):
                        if(temperature6_BT.empty() == False):
                            tab_data = temperature6_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x46'):
                        if(temperature7_BT.empty() == False):
                            tab_data = temperature7_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x47'):
                        if(temperature8_BT.empty() == False):
                            tab_data = temperature8_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x50'):
                        if(adc1_BT.empty() == False):
                            tab_data = adc1_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x51'):
                        if(adc2_BT.empty() == False):
                            tab_data = adc2_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x52'):
                        if(adc3_BT.empty() == False):
                            tab_data = adc3_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x53'):
                        if(adc4_BT.empty() == False):
                            tab_data = adc4_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x60'):
                        if(accelerometer1_BT.empty() == False):
                            tab_data = accelerometer1_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x70'):
                        if(hygrometer1_BT.empty() == False):
                            tab_data = hygrometer1_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x71'):
                        if(hygrometer2_BT.empty() == False):
                            tab_data = hygrometer2_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x80'):
                        if(impuls1_BT.empty() == False):
                            tab_data = impuls1_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x81'):
                        if(impuls2_BT.empty() == False):
                            tab_data = impuls2_BT.get()
                            self.ComPort_Bluetooth.send_data_3964r(self.ComPort_Bluetooth.timeout, tab_data[0], tab_data[1], tab_data[2])
