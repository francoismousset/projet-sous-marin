import serial
import time
import File3964MotE
import File3964MotR
from threading import *

#***************************************************************************************************************************************************
#*******************************************************initialisation du port**********************************************************************
#***************************************************************************************************************************************************
s = serial.Serial(
	port='/dev/ttyS2',
	baudrate=9600, 
	timeout=0,
	parity=serial.PARITY_NONE,
	stopbits=serial.STOPBITS_ONE,
	bytesize=serial.EIGHTBITS)

#***************************************************************************************************************************************************
#*******************************************************variables globales****************************************************************
#***************************************************************************************************************************************************
#*************Emission*******************
BCC = 0
Error = 0
Time_out = 0
Compteur_0 = 0
Compteur_1 = 0
Compteur_2 = 0
Compteur_3 = 0
Compteur_4 = 0
Somme_compteur = 0
Error_Transmit = 0
Correct_Transmit = 0

#*************Reception*******************
Check_Sum = 0
Time_out_r = 0
BCC_Receive = 0
Trame_receive = 0

#*************Affectation*******************
STX =chr(0x02)
ETX =chr(0x03)
DLE =chr(0x10)
NAK =chr(0x15)
#***************************************************************************************************************************************************
#********************************************************Fonctions**********************************************************************************
#***************************************************************************************************************************************************
#*************Emission*******************
def Test_compteur():
	global NAK             			#Variable globale
	global Error
	global Error_Transmit
	
	Error = 1			 			#Signaler erreur 
	
	if (Somme_compteur == 6): 		#Tester la somme des erreurs							
		s.write(NAK)  				#Si somme erreur = 6, envoyer NAK et arreter la communication	    				
		print("Emeteur: TX NAK")
		Error_Transmit = 1			#Signaler Fin de transmission apres 6 erreurs  
		
def Time_over():
	global Time_out
	
	Time_out = 1					#Delay: apres x secondes mettre Time_out a False
	print("Time Over_E")						

def Emission_STX():
	global STX
	global BCC
	
	s.write(STX)  					#Envoi du STX
	BCC= BCC^(ord(STX))             #Calcul du check sum
	print("Emetteur: TX STX")

def Receptionn_DLE():

	global DLE
	global STX
	global Time_out
	global Compteur_0
	global Compteur_1
	global Compteur_2
	global Compteur_3
	global Compteur_4
	global Somme_compteur

	Pass = 0
	Time_out = 0
	Convert_Data = 0
	Data_receive = 0
	
	t = Timer(0.02,Time_over) 
	t.start()								
	while (Time_out == 0):
		Convert_Data = 0
		Data_receive = 0
		while (((Data_receive == 0) or (Data_receive=="")) and (Time_out == 0)):
			Data_receive = s.read(1) 							
			if (Data_receive!=""):
				Convert_Data  = ord(Data_receive)  				
			
		if ((Convert_Data == ord(DLE)) and (Time_out == 0)): 	
			t.cancel()											
			Time_out = 1
			print("Emetteur: RX DLE OK") 
		if ((Convert_Data != ord(DLE)) and (Convert_Data != ord(STX)) and (Convert_Data != 0x00) and (Time_out == 0)):
			t.cancel()
			Pass = 1
			Time_out = 1
			Compteur_0 = Compteur_0 + 1
			Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
			print("Emetteur: RX DLE FAIL")
			print("Compteur_0 =",Compteur_0)
			Test_compteur()
			
	if ((Time_out == 1) and (Pass == 0) and (Convert_Data != ord(DLE))):
		t.cancel()
		Compteur_4 = Compteur_4 + 1
		Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
		print("Emetteur= Time_over + RX DLE FAIL") 
		print("Compteur_4 =",Compteur_4)
		Test_compteur()	

def Emission_DATA(Trame):

	global DLE
	global BCC
	
	i = 0
	print("SEND DATA")
	while(i<len(Trame)):
		s.write(Trame[i])
		BCC = BCC^ord(Trame[i])
		print(ord(Trame[i]))
		if (Trame[i] == (DLE)):
			s.write(Trame[i])
			BCC=BCC^ord(Trame[i])
			print(ord(Trame[i]))
		i=i+1
	i=0

def Emissionn_DLE():
	
	global DLE
	global BCC
	global Time_out
	global Compteur_0
	global Compteur_1
	global Compteur_2
	global Compteur_3
	global Compteur_4
	global Somme_compteur

	Time_out = 0
	Convert_Data = 0
	Data_receive = 0
	
	Data_receive = s.readline() 					
	if ((Data_receive == 0) or (Data_receive=="")):
		s.write(DLE) 
		BCC=BCC^(ord(DLE)) 
		print("Emetteur: Tx DLE")
	else:
		Compteur_3 = Compteur_3 + 1
		Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
		print("Emetteur: Error RX CHAR") 
		print("Compteur_3 =",Compteur_3)
		Test_compteur()	

def Emission_ETX():

	global ETX
	global BCC
	global Time_out
	global Compteur_0
	global Compteur_1
	global Compteur_2
	global Compteur_3
	global Compteur_4
	global Somme_compteur

	Time_out = 0
	Convert_Data = 0
	Data_receive = 0

	Data_receive = s.readline() 		#Si lecture nulle envoyez ETX
	if ((Data_receive == 0) or (Data_receive=="")):
		s.write(ETX)
		BCC=BCC^(ord(ETX))
		print("Emetteur: Tx ETX")
	else:
		Compteur_3 = Compteur_3 + 1
		Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
		print("Emetteur: Error RX CHAR")
		print("Compteur_3 =",Compteur_3)
		Test_compteur()

def Emission_BCC():
	global BCC
	global Time_out
	global Compteur_0
	global Compteur_1
	global Compteur_2
	global Compteur_3
	global Compteur_4
	global Somme_compteur

	Time_out = 0
	Convert_Data = 0
	Data_receive = 0
	
	Data_receive = s.readline() 		#Si lecture nulle envoyez BCC			
	BCC = chr(BCC)
	if ((Data_receive == 0) or (Data_receive=="")):
		s.write(BCC)
		print("Emetteur: Tx BCC")
		print("BCC_transmis=", ord(BCC)) 
	else:
		Compteur_3 = Compteur_3 + 1
		Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
		print("Emetteur: Error RX CHAR") 
		print("Compteur_3 =",Compteur_3)
		Test_compteur()
		
def Receptionn_2_DLE():

	global DLE
	global Time_out
	global Compteur_0
	global Compteur_1
	global Compteur_2
	global Compteur_3
	global Compteur_4
	global Somme_compteur
	global Correct_Transmit 

	Pass = 0
	Time_out = 0
	Convert_Data = 0
	Data_receive = 0
	
	ti = Timer(0.03,Time_over)
	ti.start()  							
	while (Time_out == 0):
		Convert_Data = 0
		Data_receive = 0
		while (((Data_receive == 0) or (Data_receive=="")) and (Time_out == 0)):
			Data_receive = s.read(1) 		
			if (Data_receive!=""):
				Convert_Data  = ord(Data_receive)  
			
		if ((Convert_Data == ord(DLE)) and (Time_out == 0)): 
			ti.cancel()
			Time_out = 1
			print("Emetteur: Rx DLE OK") 
		elif ((Convert_Data != 0) and (Convert_Data != ord(DLE)) and (Time_out == 0)):
			ti.cancel()
			Pass = 1
			Time_out = 1
			Compteur_1 = Compteur_1 + 1
			Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
			print("Emmetteur: Rx DLE FAIL") 
			print("Compteur_1 =",Compteur_1)
			Test_compteur()
	
	if ((Time_out == 1) and (Convert_Data != ord(DLE)) and (Pass == 0)):
		ti.cancel()
		Compteur_2 = Compteur_2 + 1
		Somme_compteur = Compteur_0 + Compteur_1 + Compteur_2 + Compteur_3 + Compteur_4
		print("Emetteur= Time_over + Rx DLE FAIL") 
		print("Compteur_2 =",Compteur_2)
		Test_compteur()
	if ((Time_out == 1) and (Convert_Data == ord(DLE))):
		ti.cancel()
		Time_out = 0
		Compteur_0 = 0
		Compteur_1 = 0
		Compteur_2 = 0
		Compteur_3 = 0
		Compteur_4 = 0
		Somme_compteur = 0
		Correct_Transmit = 1
		print("Fin transmission") 

#*************Reception*******************
def Time_over_r():
	global Time_out_r
	Time_out_r = 1
	print("Time_over_R")
	
def Reception_STX():
	global STX
	global DLE
	global NAK
	global Check_Sum
	
	Data_Receipt=0
	STX_Receipt = 0
	Convert_Data_Receive =0
	
	s.readline()
	while (((Data_Receipt == 0) or (Data_Receipt==""))and (STX_Receipt == 0)):
		Data_Receipt = s.read(1)       						
		if (Data_Receipt!=""):
			Convert_Data_Receive  = ord(Data_Receipt)    	

			if (Convert_Data_Receive == ord(STX)):
				STX_Receipt = 1
				s.write(DLE)            					
				Check_Sum = Check_Sum^Convert_Data_Receive
				print("Recepteur: RX STX OK et TX DLE") 
				return (0)
			else:
				s.write(NAK)             				
				print("Recpeteur: RX STX FAIL et TX NAK") 
				return(1)
				
def Reception_DATA_et_DLE():
	global DLE
	global NAK
	global Check_Sum
	global Time_out_r
	global Trame_receive
	
	C0 = 0
	C1 = 0
	C2 = 0
	i_r = 0
	Pass = 0
	Data = []
	Time_out_r = 0
	Data_Receipt = 0
	Trame_receive = 0
	Trame_receive = ""
	Number_of_Char = 0
	Convert_Data_Receive = 0

	t7= Timer(0.02,Time_over_r)
	t6= Timer(0.02,Time_over_r)
	t5= Timer(0.02,Time_over_r)
	t4= Timer(0.02,Time_over_r)
	t3= Timer(0.02,Time_over_r)	
	t2= Timer(0.02,Time_over_r)		
	t1= Timer(0.02,Time_over_r)
	t1.start()  	
	while(Time_out_r == 0):
		Data_Receipt = 0
		Convert_Data_Receive = 0
		while (((Data_Receipt == 0) or (Data_Receipt=="")) and (Time_out_r == 0)):
			Data_Receipt = s.read(1)       
			if (Data_Receipt!=""):
				Convert_Data_Receive  = ord(Data_Receipt)
				
		if ((Number_of_Char == 0x03) and (Time_out_r == 0)): 
			print("ON")
			Pass = 1
			Time_out_r = 1  
			if(i_r == 3): 
				t4.cancel()
			if(i_r == 4):
				t5.cancel()
			if(i_r == 5):
				t6.cancel()
			if(i_r == 6):
				t7.cancel()
			i_r = 4  

		if ((Number_of_Char <= 0x03) and (Time_out_r == 0)):
			Data.append(Convert_Data_Receive) 
			print("Data_r_Recu=",Data[i_r])
			Check_Sum = Check_Sum^Data[i_r]
			if(Convert_Data_Receive == ord(DLE)):
				C0 = C0 + 1
				if (C0==1):
					Trame_receive = Trame_receive + chr(Data[i_r])
				if (C0==2):
					C0 = 0
					C1 = C1 + 1
			else:
				C2 = C2 + 1
				Trame_receive = Trame_receive + chr(Data[i_r])
				
			i_r = i_r + 1
			Number_of_Char = C1 + C2
	
			if (i_r == 1):
				print("OK_1")
				t1.cancel()
				Time_out_r = 0
				t2.start() # Time_out_r pour deuxieme Data
			if (i_r == 2):
				print("OK_2")
				t2.cancel()
				Time_out_r = 0
				t3.start() # Time_out_r pour Troisieme Data

			if (i_r == 3):
				print("OK_3")
				t3.cancel()
				Time_out_r = 0
				t4.start() # Time_out_r pour quatrieme Data
			if (i_r == 4):
				print("OK_4")
				t4.cancel()
				Time_out_r = 0
				t5.start()
			if (i_r == 5):
				print("OK_5")
				t5.cancel()
				Time_out_r = 0
				t6.start()
			if (i_r == 6):
				print("OK_6")
				t6.cancel()
				Time_out_r = 0
				t7.start()

	if ((Time_out_r == 1) and (i_r <= 0x03)):
		s.write(NAK)
		print("Recepteur: Error all data not receive") 
		return(1)
			
	if ((Time_out_r == 1) and (Convert_Data_Receive != ord(DLE)) and (Pass == 1)):
		s.write(NAK)
		print("Recepteur: Rx DLE FAIL et TX NAK") 
		return(1)

	if ((Time_out_r == 1) and (Convert_Data_Receive == ord(DLE)) and (Pass == 1)):
		Check_Sum = Check_Sum^Convert_Data_Receive
		print("Recepteur: RX DLE OK")
		print("Somme")
		return(0)
	
def Reception_ETX():
	global ETX
	global NAK
	global Time_out_r
	global Check_Sum 
	
	Time_out_r = 0
	Data_Receipt = 0
	Convert_Data_Receive = 0
	
	t8= Timer(0.02,Time_over_r)
	t8.start()  
	
	while(Time_out_r == 0):
		Data_Receipt = 0
		Convert_Data_Receive = 0
		while (((Data_Receipt == 0) or (Data_Receipt=="")) and (Time_out_r == 0)):
			Data_Receipt = s.read(1)       
			if (Data_Receipt!=""):
				Convert_Data_Receive  = ord(Data_Receipt)    
	
		if ((Convert_Data_Receive == 0x03) and (Time_out_r == 0)):
			t8.cancel() 
			Time_out_r = 1 
			print("Recepteur: Rx ETX OK") 
	
	if ((Time_out_r == 1) and (Convert_Data_Receive != ord(ETX))): 
		t8.cancel()
		s.write(NAK)
		print("Recpeteur: RX ETX FAIL et TX NAK")
		return(1)

	if ((Time_out_r == 1) and (Convert_Data_Receive == ord(ETX))):
		t8.cancel()
		Check_Sum = Check_Sum^Convert_Data_Receive
		return(0)
			
def Reception_BCC():

	global NAK
	global Check_Sum 
	global Time_out_r
	global BCC_Receive
	
	Time_out_r = 0
	Data_Receipt = 0
	Convert_Data_Receive = 0
	
	t9= Timer(0.02,Time_over_r)
	t9.start()  

	while(Time_out_r == 0):
		Data_Receipt = 0
		Convert_Data_Receive = 0
		while (((Data_Receipt == 0) or (Data_Receipt=="")) and (Time_out_r == 0)):
			Data_Receipt = s.read(1)       
			if (Data_Receipt!=""):
				Convert_Data_Receive  = ord(Data_Receipt)   
			
		if ((Convert_Data_Receive != 0x00) and (Time_out_r == 0)):
			t9.cancel() 
			Time_out_r = 1  
			print("Recepteur: RX Check_Sum OK") 
		
	if ((Time_out_r == 1) and (Convert_Data_Receive == 0x00)): 
		t9.cancel()
		s.write(NAK)
		print("Recepteur: Rx Check_Sum FAIL et Tx NAK")
		return(1)

	if ((Time_out_r == 1) and (Convert_Data_Receive != 0x00)): 
		t9.cancel()
		BCC_Receive = Convert_Data_Receive
		print("BCC_r_calcule=",Check_Sum)
		return(0)
		
def Comparaison_BCC ():
	
	global DLE
	global NAK
	global Time_out_r
	global Check_Sum 
	global BCC_Receive
	global Trame_receive
	
	ii = 0
	Data_Receipt = 0
	Convert_Data_Receive = 0
	
	if(BCC_Receive==Check_Sum):
		s.write(DLE)
		print("Recepteur: Tx DLE")
		print("Trame_receive")
		while(ii<len(Trame_receive)):
			print(ord(Trame_receive[ii]))
			ii=ii+1
		ii=0
		Check_Sum = 0
		print("Fin Reception")
		return(0)

	else:
		s.write(NAK)
		print("Recepteur: Check_Sum st # et Tx NAK") 
		return(1)

#***************************************************************************************************************************************************
#*****************************************************Programme principale**************************************************************************
#***************************************************************************************************************************************************
#*************Reception*******************	
#def main_Reception():
	
#	global Check_Sum
#	global Time_out_r
#	global BCC_Receive
#	global Trame_receive
	
	#while(1):
		
#	Receipt = 0
#	Check_Sum = 0
#	Time_out_r = 0
#	BCC_Receive = 0
#	Trame_receive = 0
#		
#	Receipt = Reception_STX()
#	if(Receipt == 0):
#		Receipt = Reception_DATA_et_DLE()
#	if (Receipt == 0):
#		Receipt = Reception_ETX()
#	if (Receipt == 0):
#		Receipt = Reception_BCC() 	
#	if (Receipt == 0):
#		Receipt = Comparaison_BCC()
def main_Reception():
	
	global Check_Sum
	global Time_out_r
	global BCC_Receive
	global Trame_receive
	
	#while(1):
		
	Receipt = 0
	Check_Sum = 0
	Time_out_r = 0
	BCC_Receive = 0
	Trame_receive = 0
		
	Receipt = Reception_STX()
	if(Receipt == 0):
		Receipt = Reception_DATA_et_DLE()
	if (Receipt == 0):
		Receipt = Reception_ETX()
	if (Receipt == 0):
		Receipt = Reception_BCC() 	
	if (Receipt == 0):
		Receipt = Comparaison_BCC()
		File3964MotR.Tchat_Write_File(Trame_receive)
		File3964MotE.Jerome_Read_File()

#*************Emission*******************		
#def main_Emission(Data_1,Data_2,Data_3):

#	global BCC
#	global Error
#	global Time_out
#	global Compteur_0
#	global Compteur_1
#	global Compteur_2
#	global Compteur_3
#	global Compteur_4
#	global Somme_compteur
#	global Error_Transmit
#	global Correct_Transmit
	
#	Recup_data_1 = Data_1					
#	Recup_data_2 = Data_2
#	Recup_data_3 = Data_3
	
#	#Data_11 = chr(Data_1)					
#	#Data_22 = chr(Data_2)
#	#Data_33 = chr(Data_3)
	
#	#Trame = Data_11 + Data_22 + Data_33 

#	Trame = Data_1 + Data_2 + Data_3
#	
#	Compteur_0 = 0
#	Compteur_1 = 0
#	Compteur_2 = 0
#	Compteur_3 = 0
#	Compteur_4 = 0
#	Error_Transmit = 0
#	Correct_Transmit = 0
	
#	while ((Correct_Transmit == 0) and (Error_Transmit == 0)):
#		BCC = 0
#		Error = 0
#		Time_out = 0
#		Somme_compteur = 0
#	
#		Emission_STX()
#		Receptionn_DLE()
#		if ((Error == 0) and (Error_Transmit == 0)):
#			Emission_DATA(Trame)
#			Emissionn_DLE()
#		if ((Error == 0) and (Error_Transmit == 0)):
#			Emission_ETX()
#		if ((Error == 0) and (Error_Transmit == 0)):
#			Emission_BCC()
#		if ((Error == 0) and (Error_Transmit == 0)):
#			Receptionn_2_DLE()
	
#	if(Correct_Transmit == 1):
#		main_Reception()

def main_Emission(Data_1,Data_2,Data_3):

	global BCC
	global Error
	global Time_out
	global Compteur_0
	global Compteur_1
	global Compteur_2
	global Compteur_3
	global Compteur_4
	global Somme_compteur
	global Error_Transmit
	global Correct_Transmit
	
	Trame =""
	Compteur_0 = 0
	Compteur_1 = 0
	Compteur_2 = 0
	Compteur_3 = 0
	Compteur_4 = 0
	Error_Transmit = 0
	Correct_Transmit = 0
	
	Recup_data_1 = Data_1					
	Recup_data_2 = Data_2
	Recup_data_3 = Data_3
	
	File3964MotE.Jerome_Write_File(Data_1,Data_2,Data_3)
	Trame = File3964MotR.Tchat_Read_File()
		
	while ((Correct_Transmit == 0) and (Error_Transmit == 0)):
		BCC = 0
		Error = 0
		Time_out = 0
		Somme_compteur = 0
	
		Emission_STX()
		Receptionn_DLE()
		if ((Error == 0) and (Error_Transmit == 0)):
			Emission_DATA(Trame)
			Emissionn_DLE()
		if ((Error == 0) and (Error_Transmit == 0)):
			Emission_ETX()
		if ((Error == 0) and (Error_Transmit == 0)):
			Emission_BCC()
		if ((Error == 0) and (Error_Transmit == 0)):
			Receptionn_2_DLE()
	if((Correct_Transmit == 1) and ((Data_1 == 'J') or (Data_1 == 'G'))):
		main_Reception()

main_Emission('M','\x00','\xFF')
time.sleep(5)		
main_Emission('M','\x01','\xFF')
time.sleep(5)
main_Emission('K','\x00','\xFF')
time.sleep(5)	
main_Emission('K','\x01','\xFF')