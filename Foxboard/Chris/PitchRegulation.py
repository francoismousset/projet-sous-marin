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

class PitchRegulation(threading.Thread):
    '''
    classdocs
    '''

    def __init__(self):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self._EnableRegulation = True
        self._Frequency = 50
        
    def run(self):
        while(1):
            if self._EnableRegulation == True:
                print "Pitch Regulator"
            time.sleep(1./self._Frequency)
    
    def setEnable(self, running):
        self._EnableRegulation = running
