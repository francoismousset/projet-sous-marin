# -*-coding:Utf-8 -*

'''
Created on 2 avr. 2012

@author: Compère Christopher
'''

if __name__ == '__main__':
    pass

def get_data_3964r(serial, timeout):
    STX = chr(0x02)
    ETX = chr(0x03)
    DLE = chr(0x10)
    NAK = chr(0x15)

    serial.timeout = timeout
    serial.flushInput
    c = serial.read()
    if c == STX:
        print ""
        print "Receiving frame 3964r"
        print("RX <- STX")
        bcc = STX
        serial.flushOutput
        serial.write(DLE)
        print("TX -> DLE")

        c = ''
        c = serial.read()
        if c != '':
            data1 = c
            bcc = (ord(bcc))^(ord(data1))
            print("RX <- Data 1 : " + str(data1))
            c = ''
            c = serial.read()
            if c != '':
                data2 = c
                bcc = (ord(chr(bcc)))^(ord(data2))
                print("RX <- Data 2 : " + str(ord(data2)))
                
                c = ''
                c = serial.read()
                if c != '':
                    if c == DLE:
                        c = ''
                        c = serial.read()
                        bcc = (ord(chr(bcc)))^(ord(c))

                    data3 = c
                    bcc = (ord(chr(bcc)))^(ord(data3))
                    print("RX <- Data 3 : " + str(ord(data3)))
                    
                    c = ''
                    c = serial.read()
                    if c != '':
                        dle = c
                        if dle == DLE:
                            print("RX <- DLE")
                            bcc = (ord(chr(bcc)))^(ord(dle))
                            
                            c = ''
                            c = serial.read()
                            if c != '':
                                etx = c
                                if etx == ETX:
                                    print("RX <- ETX")
                                    bcc = (ord(chr(bcc)))^(ord(etx))
                                    
                                    c = ''
                                    c = serial.read()
                                    if c != '':
                                        bcc_rx = c
                                        print("RX <- BCC : " + str(ord(bcc_rx)))
                                        
                                        if bcc == ord(bcc_rx):
                                            serial.flushOutput
                                            serial.write(DLE)
                                            print("TX -> DLE")
                                            print("Correct BCC")
                                            print("Reception OK !")
                                            tab_data = [data1, data2, data3]
                                            return tab_data
                                        else:
                                            serial.flushOutput
                                            serial.write(NAK)
                                            print("TX -> NAK (Incorrect BCC)")                             
                                    else:
                                        print("Timeout Error")
                                        serial.flushOutput
                                        serial.write(NAK)
                                        print("TX -> NAK")
                                else:
                                    print("RX <- not ETX")
                                    serial.flushOutput
                                    serial.write(NAK)
                                    print("TX -> NAK")
                            else:
                                serial.flusOutput
                                serial.write(NAK)
                                print("TX -> NAK")
                        else:
                            print("RX <- not DLE")
                            serial.flushOutput
                            serial.write(NAK)
                            print("TX -> NAK")
                    else:
                        print("Timeout Error")
                        serial.flushOutput
                        serial.write(NAK)
                        print("TX -> NAK")
                else:
                    print("Timeout Error")
                    serial.flushOutput
                    serial.write(NAK)
                    print("TX -> NAK")
            else:
                print("Timeout Error")
                serial.flushOutput
                serial.write(NAK)
                print("TX -> NAK")
        else:
            print("Timeout Error")
            serial.flushOutput
            serial.write(NAK)
            print("TX -> NAK")

def send_data_3964r(serial, timeout, data1, data2, data3):
    STX = chr(0x02)
    ETX = chr(0x03)
    DLE = chr(0x10)
    
    bcc = ord(STX) ^ ord(data1) ^ ord(data2) ^ ord(data3) ^ ord(DLE) ^ ord(ETX)
    
    error = 0
    flag_error = True
    while((error != 5) and (flag_error == True)):
        flag_error = False
        print ""
        print "Transmitting frame 3964r"
        serial.flushInput()
        serial.flushOutput()
        serial.write(STX)
        print("TX -> STX")
        
        c = ''
        serial.timeout = timeout
        c = serial.read()
        if c == DLE:
            print("RX <- DLE")
            serial.flushOutput()
            serial.write(data1)
            print("TX -> Data1 : " + str(data1))
            
            c = ''
            serial.timeout = 0
            c = serial.read()
            if c == '':
                serial.flushOutput()
                serial.write(data2)
                print("TX -> Data2 : " + str(ord(data2)))
                
                c = serial.read()
                if c == '':
                    serial.flushOutput()
                    serial.write(data3)
                    print("TX -> Data3 : " + str(ord(data3)))
                    
                    c = serial.read()
                    if c == '':
                        if data3 == DLE:
                            bcc = bcc ^ ord(DLE)
                            serial.flushOutput()
                            serial.write(data3)
                            print("TX -> DLE (x2)")
                        
                        c = serial.read()
                        if c == '':
                            serial.flushOutput()
                            serial.write(DLE)
                            print("TX -> DLE")
                            
                            if c == '':
                                serial.flushOutput()
                                serial.write(ETX)
                                print("TX -> ETX")
                                
                                if c == '':
                                    serial.flushOutput()
                                    serial.write(chr(bcc))
                                    print("TX -> BCC : " + str(bcc))
                                    
                                    serial.timeout = timeout
                                    c = serial.read()
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
