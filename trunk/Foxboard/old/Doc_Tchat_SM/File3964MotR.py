#File3964MotR

def Tchat_Write_File(Trame):
	print("TCHAT ecrit dans le Fichier DATA_R")
	f=open('/home/SM/3964motR',mode = 'w')   #'/home/SM/3964motR'  '\Python\DATA_R'
	f.write(Trame)
	#f.write(str(Trame))
	f.close()
		
def Tchat_Read_File():
	i = 0
	Trame = ""
	print("Tchat lit dans le fichier DATA_E")
	f=open('/home/SM/3964motE',mode = 'r')  #'/home/SM/3964motE' '\Python\DATA_E'
	while (i<=2):
		f.seek(i)
		Trame = Trame + str(f.read(1))
		i=i+1
	f.close()
	print(Trame)
	return(Trame)