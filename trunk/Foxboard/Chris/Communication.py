# -*-coding:Utf-8 -*

'''
Created on 10 avr. 2012

@author: Compère Christopher
'''

import serial
from protocol_3964r import *

ComPort_US = serial.Serial(port = '/dev/rfcomm0',
                           baudrate = 600,
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

Timeout = 0.5

while(1):
    tab_data = get_data_3964r(ComPort_US, Timeout)
    
    if tab_data != None:
        
        if((tab_data[0] == 'M') or (tab_data[0] == 'K')):
            send_data_3964r(ComPort_Motor, Timeout, tab_data[0], tab_data[1], tab_data[2])
            print "Commande moteur : " + str(tab_data[0]) + " " + str(ord(tab_data[1])) + " " + str(ord(tab_data[2]))
            
        elif(tab_data[0] == 'T'):
            send_data_3964r(ComPort_Sensor, tab_data[0], tab_data[1], tab_data[2])
            tab_data = get_data_3964r(ComPort_Sensor)
            send_data_3964r(ComPort_US, tab_data[0], tab_data[1], tab_data[2])
