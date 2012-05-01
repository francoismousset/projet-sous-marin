# -*-coding:Utf-8 -*

'''
Created on 1 mai 2012

@author: Chris
'''
import threading
import Queue
import time

#from pysqlite2 import dbapi2 as sqlite3
from SensorInterface import *

class LoggingDB(threading.Thread):
    '''
    classdocs
    '''
    def __init__(self):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self._Frequency = 50
    
    def run(self):
        while(1):
            print "Log DB"
            time.sleep(1./self._Frequency)
            