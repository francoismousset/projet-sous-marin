# -*-coding:Utf-8 -*

'''
Created on 8 mai 2012

@author: Compère Christopher
'''

import threading

from MotorInterface import motorCommand
from SensorInterface import temperature1_US, temperature2_US, temperature3_US, temperature4_US, temperature5_US, temperature6_US, temperature7_US, temperature8_US, adc1_US, adc2_US, adc3_US, adc4_US, accelerometer1_US, hygrometer1_US, hygrometer2_US, impuls1_US, impuls2_US


class USCmdWatcher(threading.Thread):
    '''
    classdocs
    '''

    def __init__(self, comPort3964r):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self.ComPort_US = comPort3964r
        
    def run(self):
        while(1):
            tab_data = self.ComPort_US.get_data_3964r(None, self.ComPort_US.timeout)
            if tab_data != None:
                if((tab_data[0] == 'M') or (tab_data[0] == 'K')):
                    motorCommand.put(tab_data)
                else:
                    if(tab_data[0] == '\x40'):
                        if(temperature1_US.empty() == False):
                            tab_data = temperature1_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x41'):
                        if(temperature2_US.empty() == False):
                            tab_data = temperature2_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x42'):
                        if(temperature3_US.empty() == False):
                            tab_data = temperature3_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x43'):
                        if(temperature4_US.empty() == False):
                            tab_data = temperature4_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x44'):
                        if(temperature5_US.empty() == False):
                            tab_data = temperature5_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x45'):
                        if(temperature6_US.empty() == False):
                            tab_data = temperature6_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x46'):
                        if(temperature7_US.empty() == False):
                            tab_data = temperature7_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x47'):
                        if(temperature8_US.empty() == False):
                            tab_data = temperature8_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x50'):
                        if(adc1_US.empty() == False):
                            tab_data = adc1_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x51'):
                        if(adc2_US.empty() == False):
                            tab_data = adc2_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x52'):
                        if(adc3_US.empty() == False):
                            tab_data = adc3_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x53'):
                        if(adc4_US.empty() == False):
                            tab_data = adc4_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x60'):
                        if(accelerometer1_US.empty() == False):
                            tab_data = accelerometer1_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x70'):
                        if(hygrometer1_US.empty() == False):
                            tab_data = hygrometer1_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x71'):
                        if(hygrometer2_US.empty() == False):
                            tab_data = hygrometer2_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x80'):
                        if(impuls1_US.empty() == False):
                            tab_data = impuls1_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
                    elif(tab_data[0] == '\x81'):
                        if(impuls2_US.empty() == False):
                            tab_data = impuls2_US.get()
                            self.ComPort_US.send_data_3964r(self.ComPort_US.timeout, tab_data[0], tab_data[1], tab_data[2])
