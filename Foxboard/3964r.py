# -*-coding:Utf-8 -*

'''
Created on 2 avr. 2012

@author: Compère Christopher
'''

import serial

if __name__ == '__main__':
    pass

s = serial.Serial(port = 'COM2',
                  baudrate = 9600,
                  parity = serial.PARITY_NONE,
                  stopbits = serial.STOPBITS_ONE,
                  bytesize = serial.EIGHTBITS)

STX = chr(0x02)
ETX = chr(0x03)
DLE = chr(0x10)
NAK = chr(0x15)

def get_data_3964r():
    s.timeout = 0.5
    s.flushInput
    c = s.read()
    if c == STX:
        print ""
        print "Receiving frame 3964r"
        print("RX <- STX")
        bcc = STX
        s.flushOutput
        s.write(DLE)
        print("TX -> DLE")

        c = ''
        c = s.read()
        if c != '':
            data1 = c
            bcc = (ord(bcc))^(ord(data1))
            print("RX <- Data 1 : " + str(data1))
            c = ''
            c = s.read()
            if c != '':
                data2 = c
                bcc = (ord(chr(bcc)))^(ord(data2))
                print("RX <- Data 2 : " + str(ord(data2)))
                
                c = ''
                c = s.read()
                if c != '':
                    if c == DLE:
                        c = ''
                        c = s.read()
                        bcc = (ord(chr(bcc)))^(ord(c))

                    data3 = c
                    bcc = (ord(chr(bcc)))^(ord(data3))
                    print("RX <- Data 3 : " + str(ord(data3)))
                    
                    c = ''
                    c = s.read()
                    if c != '':
                        dle = c
                        if dle == DLE:
                            print("RX <- DLE")
                            bcc = (ord(chr(bcc)))^(ord(dle))
                            
                            c = ''
                            c = s.read()
                            if c != '':
                                etx = c
                                if etx == ETX:
                                    print("RX <- ETX")
                                    bcc = (ord(chr(bcc)))^(ord(etx))
                                    
                                    c = ''
                                    c = s.read()
                                    if c != '':
                                        bcc_rx = c
                                        print("RX <- BCC : " + str(ord(bcc_rx)))
                                        
                                        if bcc == ord(bcc_rx):
                                            s.flushOutput
                                            s.write(DLE)
                                            print("TX -> DLE")
                                            print("Correct BCC")
                                            print("Reception OK !")
                                            tab_data = [data1, data2, data3]
                                            return tab_data
                                        else:
                                            s.flushOutput
                                            s.write(NAK)
                                            print("TX -> NAK (Incorrect BCC)")                             
                                    else:
                                        print("Timeout Error")
                                        s.flushOutput
                                        s.write(NAK)
                                        print("TX -> NAK")
                                else:
                                    print("RX <- not ETX")
                                    s.flushOutput
                                    s.write(NAK)
                                    print("TX -> NAK")
                            else:
                                s.flusOutput
                                s.write(NAK)
                                print("TX -> NAK")
                        else:
                            print("RX <- not DLE")
                            s.flushOutput
                            s.write(NAK)
                            print("TX -> NAK")
                    else:
                        print("Timeout Error")
                        s.flushOutput
                        s.write(NAK)
                        print("TX -> NAK")
                else:
                    print("Timeout Error")
                    s.flushOutput
                    s.write(NAK)
                    print("TX -> NAK")
            else:
                print("Timeout Error")
                s.flushOutput
                s.write(NAK)
                print("TX -> NAK")
        else:
            print("Timeout Error")
            s.flushOutput
            s.write(NAK)
            print("TX -> NAK")

def send_data_3964r(data1, data2, data3):
    
    bcc = ord(STX) ^ ord(data1) ^ ord(data2) ^ ord(data3) ^ ord(DLE) ^ ord(ETX)
    
    error = 0
    flag_error = True
    while((error != 5) and (flag_error == True)):
        flag_error = False
        print ""
        print "Transmitting frame 3964r"
        s.flushInput()
        s.flushOutput()
        s.write(STX)
        print("TX -> STX")
        
        c = ''
        s.timeout = 0.5
        c = s.read()
        if c == DLE:
            print("RX <- DLE")
            s.flushOutput()
            s.write(data1)
            print("TX -> Data1 : " + str(data1))
            
            c = ''
            s.timeout = 0
            c = s.read()
            if c == '':
                s.flushOutput()
                s.write(data2)
                print("TX -> Data2 : " + str(ord(data2)))
                
                c = s.read()
                if c == '':
                    s.flushOutput()
                    s.write(data3)
                    print("TX -> Data3 : " + str(ord(data3)))
                    
                    c = s.read()
                    if c == '':
                        if data3 == DLE:
                            bcc = bcc ^ ord(DLE)
                            s.flushOutput()
                            s.write(data3)
                            print("TX -> DLE (x2)")
                        
                        c = s.read()
                        if c == '':
                            s.flushOutput()
                            s.write(DLE)
                            print("TX -> DLE")
                            
                            if c == '':
                                s.flushOutput()
                                s.write(ETX)
                                print("TX -> ETX")
                                
                                if c == '':
                                    s.flushOutput()
                                    s.write(chr(bcc))
                                    print("TX -> BCC : " + str(bcc))
                                    
                                    s.timeout = 0.5
                                    c = s.read()
                                    if c == '':
                                        print("No response")
                                        error = error + 1
                                        flag_error = True
                                    elif c == DLE:
                                        print("RX <- DLE")
                                        print("Transmission OK !")
                                    else:
                                        print("RX <- not DLE")
                                        print("Transmission error !")
                                        error = error + 1
                                        flag_error = True
                                else:
                                    print("RX <- data")
                                    print("Disrupted communication !")
                                    error = error + 1
                                    flag_error = True
                            else:
                                print("RX <- data")
                                print("Disrupted communication !")
                                error = error + 1
                                flag_error = True
                        else:
                            print("RX <- data")
                            print("Disrupted communication !")
                            error = error + 1
                            flag_error = True
                    else:
                        print("RX <- data")
                        print("Disrupted communication !")
                        error = error + 1
                        flag_error = True
                else:
                    print("RX <- data")
                    print("Disrupted communication !")
                    error = error + 1
                    flag_error = True
            else:
                print("RX <- data")
                print("Disrupted communication !")
                error = error + 1
                flag_error = True
        elif c == '':
            print("No response")
            error = error + 1
            flag_error = True
        else:
            print("RX <- not DLE")
            print("Transmission error !")
            error = error + 1
            flag_error = True

while(1):
    tab_data = get_data_3964r()
    #if tab_data != None:
        #send_data_3964r(tab_data[0], tab_data[1], tab_data[2])
