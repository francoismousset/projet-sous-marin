# -*-coding:Utf-8 -*

'''
Created on 25 avr. 2012

@author: Compère Christopher
'''
import serial

class SerialComPort3964r(serial.Serial):

    def __init__(self, port, baudrate, timeout, debug):
        '''
        Constructor
        '''
        serial.Serial.__init__(self,
                               port = port,
                               baudrate = baudrate,
                               bytesize = serial.EIGHTBITS,
                               parity = serial.PARITY_NONE,
                               stopbits = serial.STOPBITS_ONE,
                               timeout = timeout)     
        self.STX = chr(0x02)
        self.ETX = chr(0x03)
        self.DLE = chr(0x10)
        self.NAK = chr(0x15)
        
        self.debug = debug
        
        #Nombre d'essai pour l'envoi de la trame
        self.nbr_error = 5
        
    def get_data_3964r(self, timeout):
    
        self.timeout = timeout
        self.flushInput
        c = self.read()
        if c == self.STX:
            print "\nReceiving frame 3964r"
            if self.debug == True :
                print("RX <- STX")
            bcc = self.STX
            self.flushOutput
            self.write(self.DLE)
            if self.debug == True :
                print("TX -> DLE")
    
            c = ''
            c = self.read()
            if c != '':
                data1 = c
                bcc = (ord(bcc))^(ord(data1))
                if self.debug == True :
                    print("RX <- Data 1 : " + str(data1))
                c = ''
                c = self.read()
                if c != '':
                    data2 = c
                    bcc = (ord(chr(bcc)))^(ord(data2))
                    if self.debug == True :
                        print("RX <- Data 2 : " + str(ord(data2)))
                    
                    c = ''
                    c = self.read()
                    if c != '':
                        if c == self.DLE:
                            c = ''
                            c = self.read()
                            bcc = (ord(chr(bcc)))^(ord(c))
    
                        data3 = c
                        bcc = (ord(chr(bcc)))^(ord(data3))
                        if self.debug == True :
                            print("RX <- Data 3 : " + str(ord(data3)))
                        
                        c = ''
                        c = self.read()
                        if c != '':
                            dle = c
                            if dle == self.DLE:
                                if self.debug == True :
                                    print("RX <- DLE")
                                bcc = (ord(chr(bcc)))^(ord(dle))
                                
                                c = ''
                                c = self.read()
                                if c != '':
                                    etx = c
                                    if etx == self.ETX:
                                        if self.debug == True :
                                            print("RX <- ETX")
                                        bcc = (ord(chr(bcc)))^(ord(etx))
                                        
                                        c = ''
                                        c = self.read()
                                        if c != '':
                                            bcc_rx = c
                                            if self.debug == True :
                                                print("RX <- BCC : " + str(ord(bcc_rx)))
                                            
                                            if bcc == ord(bcc_rx):
                                                self.flushOutput
                                                self.write(self.DLE)
                                                if self.debug == True :
                                                    print("TX -> DLE")
                                                    print("Correct BCC")
                                                print("Frame 3964r reception [OK]")
                                                tab_data = [data1, data2, data3]
                                                return tab_data
                                            else:
                                                self.flushOutput
                                                self.write(self.NAK)
                                                print("Error timeout [Incorrect BCC]")
                                                if self.debug == True :
                                                    print("TX -> NAK")
               
                                        else:
                                            self.flushOutput
                                            self.write(self.NAK)
                                            print("Error timeout [BCC not received]")
                                            if self.debug == True :
                                                print("TX -> NAK")
    
                                    else:
                                        self.flushOutput
                                        self.write(self.NAK)
                                        print("Error [Byte received is not ETX]")
                                        if self.debug == True :
                                            print("TX -> NAK")
    
                                else:
                                    self.flusOutput
                                    self.write(self.NAK)
                                    print("Error timeout [ETX not received]")
                                    if self.debug == True :
                                        print("TX -> NAK")
    
                            else:
                                self.flushOutput
                                self.write(self.NAK)
                                print("Error [Byte received is not DLE]")
                                if self.debug == True :
                                    print("TX -> NAK")
                                    
                        else:
                            self.flushOutput
                            self.write(self.NAK)
                            print("Error timeout [DLE not received]")
                            if self.debug == True :
                                print("TX -> NAK")
    
                    else:
                        self.flushOutput
                        self.write(self.NAK)
                        print("Error timeout [Data3 not received]")
                        if self.debug == True :
                            print("TX -> NAK")
    
                else:
                    self.flushOutput
                    self.write(self.NAK)
                    print("Error timeout [Data2 not received]")
                    if self.debug == True :
                        print("TX -> NAK")
    
            else:
                self.flushOutput
                self.write(self.NAK)
                print("Error timeout [Data1 not received]")
                if self.debug == True :
                    print("TX -> NAK")
    
    
    def send_data_3964r(self, timeout, data1, data2, data3):
     
        bcc = ord(self.STX) ^ ord(data1) ^ ord(data2) ^ ord(data3) ^ ord(self.DLE) ^ ord(self.ETX)
        
        error = 0
        flag_error = True
        while((error != self.nbr_error) and (flag_error == True)):
            flag_error = False
            
            print "\nTransmitting frame 3964r"
            self.flushInput()
            self.flushOutput()
            self.write(self.STX)
            if self.debug == True :
                print("TX -> STX")
            
            c = ''
            self.timeout = timeout
            c = self.read()
            if c == self.DLE:
                if self.debug == True :
                    print("RX <- DLE")
                self.flushOutput()
                self.write(data1)
                if self.debug == True :
                    print("TX -> Data1 : " + str(data1))
                
                c = ''
                self.timeout = 0
                c = self.read()
                if c == '':
                    self.flushOutput()
                    self.write(data2)
                    if self.debug == True :
                        print("TX -> Data2 : " + str(ord(data2)))
                    
                    c = self.read()
                    if c == '':
                        self.flushOutput()
                        self.write(data3)
                        if self.debug == True :
                            print("TX -> Data3 : " + str(ord(data3)))
                        
                        c = self.read()
                        if c == '':
                            if data3 == self.DLE:
                                bcc = bcc ^ ord(self.DLE)
                                self.flushOutput()
                                self.write(data3)
                                if self.debug == True :
                                    print("TX -> DLE (x2)")
                            
                            c = self.read()
                            if c == '':
                                self.flushOutput()
                                self.write(self.DLE)
                                if self.debug == True :
                                    print("TX -> DLE")
                                
                                if c == '':
                                    self.flushOutput()
                                    self.write(self.ETX)
                                    if self.debug == True :
                                        print("TX -> ETX")
                                    
                                    if c == '':
                                        self.flushOutput()
                                        self.write(chr(bcc))
                                        if self.debug == True :
                                            print("TX -> BCC : " + str(bcc))
                                        
                                        self.timeout = timeout
                                        c = self.read()
                                        if c == '':
                                            print("Error timeout [DLE 2 not received]")
                                            error = error + 1
                                            flag_error = True
                                        elif c == self.DLE:
                                            if self.debug == True :
                                                print("RX <- DLE")
                                            print("Frame 3964r transmission [OK]")
                                        else:
                                            if self.debug == True :
                                                print("RX <- not DLE")
                                            print("Error [Byte received is not DLE]")
                                            error = error + 1
                                            flag_error = True
                                    else:
                                        if self.debug == True :
                                            print("RX <- data")
                                        print("Error #1 [Disrupted communication]")
                                        error = error + 1
                                        flag_error = True
                                else:
                                    if self.debug == True :
                                        print("RX <- data")
                                    print("Error #2 [Disrupted communication]")
                                    error = error + 1
                                    flag_error = True
                            else:
                                if self.debug == True :
                                    print("RX <- data")
                                print("Error #3 [Disrupted communication]")
                                error = error + 1
                                flag_error = True
                        else:
                            if self.debug == True :
                                print("RX <- data")
                            print("Error #4 [Disrupted communication]")
                            error = error + 1
                            flag_error = True
                    else:
                        if self.debug == True :
                            print("RX <- data")
                        print("Error #5 [Disrupted communication]")
                        error = error + 1
                        flag_error = True
                else:
                    if self.debug == True :
                        print("RX <- data")
                    print("Error #6 [Disrupted communication]")
                    error = error + 1
                    flag_error = True
            elif c == '':
                print("Error timeout [DLE 1 not received]")
                error = error + 1
                flag_error = True
            else:
                if self.debug == True :
                    print("RX <- not DLE")
                print("Error [Byte received is not DLE]")
                error = error + 1
                flag_error = True
        