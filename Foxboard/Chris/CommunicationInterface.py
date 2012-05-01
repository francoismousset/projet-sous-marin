# -*-coding:Utf-8 -*

'''
Created on 10 avr. 2012

@author: Compère Christopher
'''

#import serial
#from protocol_3964r import get_data_3964r, send_data_3964r
from SerialComPort3964r import SerialComPort3964r
from SensorInterface import *
from MotorInterface import *
from PitchRegulation import *
from DivingRegulation import *
from LoggingDB import *

import time

debug = True
#debug = False

Timeout_US = 0.5
Timeout_Motor = 0.025
Timeout_Sensor = 0.025

Frequency = 10

if debug == True :
    CompPort_US = SerialComPort3964r(port = 'COM3',
                                     baudrate = 9600,
                                     timeout = Timeout_US,
                                     debug = False)
    
    ComPort_Motor = SerialComPort3964r(port = 'COM2',
                                       baudrate = 9600,
                                       timeout = Timeout_Motor,
                                       debug = False)
    
    ComPort_Sensor = SerialComPort3964r(port = 'COM1',
                                        baudrate = 9600,
                                        timeout = Timeout_Sensor,
                                        debug = False)
    
else:
    ComPort_US = SerialComPort3964r(port = '/dev/rfcomm0',
                                    baudrate = 300,
                                    timeout = Timeout_US,
                                    debug = False)

    ComPort_Motor = SerialComPort3964r(port = '/dev/ttyS2',
                                       baudrate = 9600,
                                       timeout = Timeout_Motor,
                                       debug = False)

    ComPort_Sensor = SerialComPort3964r(port = '/dev/ttyS3',
                                        baudrate = 9600,
                                        timeout = Timeout_Sensor,
                                        debug = False)

threadMotor = MotorInterface(ComPort_Motor)
threadSensor = SensorInterface(ComPort_Sensor)
threadPitchRegulation = PitchRegulation()
threadDivingRegulation = DivingRegulation()
threadLoggingDB = LoggingDB()

threadMotor.start()
threadSensor.start()
threadPitchRegulation.start()
threadDivingRegulation.start()
threadLoggingDB.start()

while(1):  
    tab_data = CompPort_US.get_data_3964r(Timeout_US)
    if tab_data != None:
        if((tab_data[0] == 'M') or (tab_data[0] == 'K')):
            motorCommand.put(tab_data)
    print "Com US"
    time.sleep(1./Frequency)
