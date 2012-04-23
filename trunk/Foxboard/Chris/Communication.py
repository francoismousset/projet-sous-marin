# -*-coding:Utf-8 -*

'''
Created on 10 avr. 2012

@author: Compère Christopher
'''

import serial
from protocol_3964r import get_data_3964r, send_data_3964r

debug = True
#debug = False


Timeout_US = 0.5
Timeout_Motor = 0.025
Timeout_Sensor = 0.025

if debug == True :
    ComPort_US = serial.Serial(port = 'COM2',
                               baudrate = 9600,
                               parity = serial.PARITY_NONE,
                               stopbits = serial.STOPBITS_ONE,
                               bytesize = serial.EIGHTBITS)

else:
    ComPort_US = serial.Serial(port = '/dev/rfcomm0',
                               baudrate = 300,
                               parity = serial.PARITY_NONE,
                               stopbits = serial.STOPBITS_ONE,
                               bytesize = serial.EIGHTBITS)

    ComPort_Motor = serial.Serial(port = '/dev/ttyS2',
                                  baudrate = 9600,
                                  parity = serial.PARITY_NONE,
                                  stopbits = serial.STOPBITS_ONE,
                                  bytesize = serial.EIGHTBITS)

    ComPort_Sensor = serial.Serial(port = '/dev/ttyS3',
                                   baudrate = 9600,
                                   parity = serial.PARITY_NONE,
                                   stopbits = serial.STOPBITS_ONE,
                                   bytesize = serial.EIGHTBITS)

while(1):
    tab_data = get_data_3964r(ComPort_US, Timeout_US)
    if tab_data != None:
        
        if((tab_data[0] == 'M') or (tab_data[0] == 'K')):
            if debug == False:
                send_data_3964r(ComPort_Motor, Timeout_Motor, tab_data[0], tab_data[1], tab_data[2])
            print "Commande moteur : [ " + str(tab_data[0]) + " | " + str(ord(tab_data[1])) + " | " + str(ord(tab_data[2])) + " ]"
            
        elif(tab_data[0] == 'T'):
            if debug == False:
                send_data_3964r(ComPort_Sensor, Timeout_Sensor, tab_data[0], tab_data[1], tab_data[2])
                tab_data = get_data_3964r(ComPort_Sensor, Timeout_Sensor)
                send_data_3964r(ComPort_US, Timeout_US, tab_data[0], tab_data[1], tab_data[2])
