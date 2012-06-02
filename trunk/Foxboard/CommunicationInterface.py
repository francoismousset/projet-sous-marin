# -*-coding:Utf-8 -*

'''
Created on 10 avr. 2012

@author: Compère Christopher
'''

from SerialComPort3964r import SerialComPort3964r
from SensorInterface import SensorInterface
from MotorInterface import MotorInterface
from PitchRegulation import PitchRegulation
from DivingRegulation import DivingRegulation
from LoggingDB import LoggingDB
from USCmdWatcher import USCmdWatcher
from BluetoothCmdWatcher import BluetoothCmdWatcher

debug = True
#debug = False

Timeout_US = 0.5
Timeout_Motor = 0.5
Timeout_Sensor = 0.5
Timeout_Bluetooth = 0.5

if debug == True :
    ComPort_US = SerialComPort3964r(port = 'COM2',
                                    baudrate = 9600,
                                    timeout = Timeout_US,
                                    debug = False)

    ComPort_Bluetooth = SerialComPort3964r(port = 'COM3',
                                        baudrate = 9600,
                                        timeout = Timeout_Bluetooth,
                                        debug = True)
    
    ComPort_Motor = SerialComPort3964r(port = 'COM4',
                                       baudrate = 9600,
                                       timeout = Timeout_Motor,
                                       debug = False)
    
    ComPort_Sensor = SerialComPort3964r(port = 'COM8',
                                        baudrate = 9600,
                                        timeout = Timeout_Sensor,
                                        debug = True)

else:
    ComPort_US = SerialComPort3964r(port = '/dev/ttyS1',
                                    baudrate = 300,
                                    timeout = Timeout_US,
                                    debug = True)

    ComPort_Bluetooth = SerialComPort3964r(port = '/dev/rfcomm0',
                                        baudrate = 9600,
                                        timeout = Timeout_Bluetooth,
                                        debug = True)

    ComPort_Motor = SerialComPort3964r(port = '/dev/ttyS4',
                                       baudrate = 9600,
                                       timeout = Timeout_Motor,
                                       debug = True)

    ComPort_Sensor = SerialComPort3964r(port = '/dev/ttyS5',
                                        baudrate = 9600,
                                        timeout = Timeout_Sensor,
                                        debug = False)

threadMotor = MotorInterface(ComPort_Motor)
threadUSWatcher = USCmdWatcher(ComPort_US)
threadBluetoothWatcher = BluetoothCmdWatcher(ComPort_Bluetooth)
threadSensor = SensorInterface(ComPort_Sensor)
threadPitchRegulation = PitchRegulation()
threadDivingRegulation = DivingRegulation()
threadLoggingDB = LoggingDB()

threadMotor.start()
threadUSWatcher.start()
threadBluetoothWatcher.start()
threadSensor.start()
#threadPitchRegulation.start()
#threadDivingRegulation.start()
#threadLoggingDB.start()
