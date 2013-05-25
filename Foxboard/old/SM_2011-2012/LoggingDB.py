# -*-coding:Utf-8 -*

'''
Created on 1 mai 2012

@author: Compère Christopher
'''
import threading
import time

#from pysqlite2 import dbapi2 as sqlite3
from SensorInterface import temperature1_db, temperature2_db, temperature3_db, temperature4_db, temperature5_db, temperature6_db, temperature7_db, temperature8_db, adc1_db, adc2_db, adc3_db, adc4_db, accelerometer1_db, hygrometer1_db, hygrometer2_db, impuls1_db, impuls2_db

class LoggingDB(threading.Thread):
    '''
    classdocs
    '''
    def __init__(self):
        '''
        Constructor
        '''
        threading.Thread.__init__(self)
        self._Frequency = 200
    
    def run(self):
        while(1):
            print "Log DB"
            time.sleep(1./self._Frequency)
