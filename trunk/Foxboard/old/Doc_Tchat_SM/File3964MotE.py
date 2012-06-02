#File3964MotE

import time
import File3964MotR

def Jerome_Write_File(Data_1,Data_2,Data_3):
	print("Jerome ecrit dans le fichier DATA_E")
	Trame = Data_1 + Data_2 + Data_3
	f=open('/home/SM/3964motE',mode = 'w')  #'/home/SM/3964motE' '\Python\DATA_E'
	f.write(Trame)
	#f.write(str(Trame))
	f.close()
	
	
def Jerome_Read_File():
	i = 0
	Trame = ""
	print("Jerome lit dans le fichier DATA_R")
	f=open('/home/SM/3964motR',mode = 'r')  #'/home/SM/3964motR'  '\Python\DATA_R'
	while (i<=2):
		f.seek(i)
		Trame = Trame + str(f.read(1))
		i=i+1
	f.close()
	print(Trame)
	return(Trame)

