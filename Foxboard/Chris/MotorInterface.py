# -*-coding:Utf-8 -*

'''
Created on 25 avr. 2012

@author: Compère Christopher
'''

import threading
import Queue
import time

motorCommand = Queue.Queue(20)

class MotorInterface(threading.Thread):
    '''
    classdocs
    '''

    def __init__(self, comPort3964r):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self.motorComPort = comPort3964r
        self._Frequency = 200
        
    def run(self):
        while(1):
            print "Motor Interface"
            if motorCommand.empty() == False:
                tab_data = motorCommand.get()
                self.motorComPort.send_data_3964r(self.motorComPort.timeout, tab_data[0], tab_data[1], tab_data[2])
                print "Commande moteur : [ " + str(tab_data[0]) + " | " + str(ord(tab_data[1])) + " | " + str(ord(tab_data[2])) + " ]"
            time.sleep(1./self._Frequency)
