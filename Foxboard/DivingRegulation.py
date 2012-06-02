# -*-coding:Utf-8 -*

'''
Created on 1 mai 2012

@author: Compère Christopher
'''

import threading
import Queue
import time

from SensorInterface import *
from MotorInterface import motorCommand

class DivingRegulation(threading.Thread):
    '''
    classdocs
    '''

    def __init__(self):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self._EnableRegulation = True
        self._Depth = 0
        self._Frequency = 500
        
    def run(self):
        while(1):
            if self._EnableRegulation == True:
                print "Diving Regulator"
            time.sleep(1./self._Frequency)
            
    def setEnable(self, running):
        self._EnableRegulation = running
        
    def setDepth(self, depth):
        self._Depth = depth
