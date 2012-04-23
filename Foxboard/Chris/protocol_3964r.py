# -*-coding:Utf-8 -*

'''
Created on 2 avr. 2012

@author: Compère Christopher
'''

if __name__ == '__main__':
    pass

#debug = True
debug = False

#Nombre d'essai pour l'envoi de la trame
nbr_error = 5

def get_data_3964r(serial, timeout):
    STX = chr(0x02)
    ETX = chr(0x03)
    DLE = chr(0x10)
    NAK = chr(0x15)

    serial.timeout = timeout
    serial.flushInput
    c = serial.read()
    if c == STX:
        print "\nReceiving frame 3964r"
        if debug == True :
            print("RX <- STX")
        bcc = STX
        serial.flushOutput
        serial.write(DLE)
        if debug == True :
            print("TX -> DLE")

        c = ''
        c = serial.read()
        if c != '':
            data1 = c
            bcc = (ord(bcc))^(ord(data1))
            if debug == True :
                print("RX <- Data 1 : " + str(data1))
            c = ''
            c = serial.read()
            if c != '':
                data2 = c
                bcc = (ord(chr(bcc)))^(ord(data2))
                if debug == True :
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
                    if debug == True :
                        print("RX <- Data 3 : " + str(ord(data3)))
                    
                    c = ''
                    c = serial.read()
                    if c != '':
                        dle = c
                        if dle == DLE:
                            if debug == True :
                                print("RX <- DLE")
                            bcc = (ord(chr(bcc)))^(ord(dle))
                            
                            c = ''
                            c = serial.read()
                            if c != '':
                                etx = c
                                if etx == ETX:
                                    if debug == True :
                                        print("RX <- ETX")
                                    bcc = (ord(chr(bcc)))^(ord(etx))
                                    
                                    c = ''
                                    c = serial.read()
                                    if c != '':
                                        bcc_rx = c
                                        if debug == True :
                                            print("RX <- BCC : " + str(ord(bcc_rx)))
                                        
                                        if bcc == ord(bcc_rx):
                                            serial.flushOutput
                                            serial.write(DLE)
                                            if debug == True :
                                                print("TX -> DLE")
                                                print("Correct BCC")
                                            print("Frame 3964r reception [OK]")
                                            tab_data = [data1, data2, data3]
                                            return tab_data
                                        else:
                                            serial.flushOutput
                                            serial.write(NAK)
                                            print("Error timeout [Incorrect BCC]")
                                            if debug == True :
                                                print("TX -> NAK")
           
                                    else:
                                        serial.flushOutput
                                        serial.write(NAK)
                                        print("Error timeout [BCC not received]")
                                        if debug == True :
                                            print("TX -> NAK")

                                else:
                                    serial.flushOutput
                                    serial.write(NAK)
                                    print("Error [Byte received is not ETX]")
                                    if debug == True :
                                        print("TX -> NAK")

                            else:
                                serial.flusOutput
                                serial.write(NAK)
                                print("Error timeout [ETX not received]")
                                if debug == True :
                                    print("TX -> NAK")

                        else:
                            serial.flushOutput
                            serial.write(NAK)
                            print("Error [Byte received is not DLE]")
                            if debug == True :
                                print("TX -> NAK")
                                
                    else:
                        serial.flushOutput
                        serial.write(NAK)
                        print("Error timeout [DLE not received]")
                        if debug == True :
                            print("TX -> NAK")

                else:
                    serial.flushOutput
                    serial.write(NAK)
                    print("Error timeout [Data3 not received]")
                    if debug == True :
                        print("TX -> NAK")

            else:
                serial.flushOutput
                serial.write(NAK)
                print("Error timeout [Data2 not received]")
                if debug == True :
                    print("TX -> NAK")

        else:
            serial.flushOutput
            serial.write(NAK)
            print("Error timeout [Data1 not received]")
            if debug == True :
                print("TX -> NAK")


def send_data_3964r(serial, timeout, data1, data2, data3):
    STX = chr(0x02)
    ETX = chr(0x03)
    DLE = chr(0x10)
    
    bcc = ord(STX) ^ ord(data1) ^ ord(data2) ^ ord(data3) ^ ord(DLE) ^ ord(ETX)
    
    error = 0
    flag_error = True
    while((error != nbr_error) and (flag_error == True)):
        flag_error = False
        
        print "\nTransmitting frame 3964r"
        serial.flushInput()
        serial.flushOutput()
        serial.write(STX)
        if debug == True :
            print("TX -> STX")
        
        c = ''
        serial.timeout = timeout
        c = serial.read()
        if c == DLE:
            if debug == True :
                print("RX <- DLE")
            serial.flushOutput()
            serial.write(data1)
            if debug == True :
                print("TX -> Data1 : " + str(data1))
            
            c = ''
            serial.timeout = 0
            c = serial.read()
            if c == '':
                serial.flushOutput()
                serial.write(data2)
                if debug == True :
                    print("TX -> Data2 : " + str(ord(data2)))
                
                c = serial.read()
                if c == '':
                    serial.flushOutput()
                    serial.write(data3)
                    if debug == True :
                        print("TX -> Data3 : " + str(ord(data3)))
                    
                    c = serial.read()
                    if c == '':
                        if data3 == DLE:
                            bcc = bcc ^ ord(DLE)
                            serial.flushOutput()
                            serial.write(data3)
                            if debug == True :
                                print("TX -> DLE (x2)")
                        
                        c = serial.read()
                        if c == '':
                            serial.flushOutput()
                            serial.write(DLE)
                            if debug == True :
                                print("TX -> DLE")
                            
                            if c == '':
                                serial.flushOutput()
                                serial.write(ETX)
                                if debug == True :
                                    print("TX -> ETX")
                                
                                if c == '':
                                    serial.flushOutput()
                                    serial.write(chr(bcc))
                                    if debug == True :
                                        print("TX -> BCC : " + str(bcc))
                                    
                                    serial.timeout = timeout
                                    c = serial.read()
                                    if c == '':
                                        print("Error timeout [DLE not received]")
                                        error = error + 1
                                        flag_error = True
                                    elif c == DLE:
                                        if debug == True :
                                            print("RX <- DLE")
                                        print("Frame 3964r transmission [OK]")
                                    else:
                                        if debug == True :
                                            print("RX <- not DLE")
                                        print("Error [Byte received is not DLE]")
                                        error = error + 1
                                        flag_error = True
                                else:
                                    if debug == True :
                                        print("RX <- data")
                                    print("Error #1 [Disrupted communication]")
                                    error = error + 1
                                    flag_error = True
                            else:
                                if debug == True :
                                    print("RX <- data")
                                print("Error #2 [Disrupted communication]")
                                error = error + 1
                                flag_error = True
                        else:
                            if debug == True :
                                print("RX <- data")
                            print("Error #3 [Disrupted communication]")
                            error = error + 1
                            flag_error = True
                    else:
                        if debug == True :
                            print("RX <- data")
                        print("Error #4 [Disrupted communication]")
                        error = error + 1
                        flag_error = True
                else:
                    if debug == True :
                        print("RX <- data")
                    print("Error #5 [Disrupted communication]")
                    error = error + 1
                    flag_error = True
            else:
                if debug == True :
                    print("RX <- data")
                print("Error #6 [Disrupted communication]")
                error = error + 1
                flag_error = True
        elif c == '':
            if debug == True :
                print("Error timeout [DLE not received]")
            error = error + 1
            flag_error = True
        else:
            if debug == True :
                print("RX <- not DLE")
            print("Error [Byte received is not DLE]")
            error = error + 1
            flag_error = True
