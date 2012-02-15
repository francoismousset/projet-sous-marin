# Projet Sousmarin
#
# Brebois Jerome
#
# Fonctions qui Dialogue avec les differentes cartes et pc via l'usart en passant par le Bloc code 3964
#


import serial



portserie1 = serial.Serial


def init () :
	global portserie1
	portserie1 = serial.Serial(port='/dev/ttyS1',parity=serial.PARITY_NONE,bytesize=serial.EIGHTBITS,stopbits=serial.STOPBITS_ONE,timeout=1,xonxoff=0,rtscts=0,baudrate=9600)
	print "portserie SM -> Moteur initier correctement"


def envoyer (numttys,trame) :
	#
	#si numttys<4 ou si numttys=catreactionneur
	#exec("portserie"+str(numttys)+".write('"+trame+"')")
	# la cmd exec ne peut pas contenir de \x00 !!!
	if numttys == 0 :
		portserie0.write(trame)
	if numttys == 1 :
		portserie1.write(trame)	
	
def recevoir (numttys) :
	# fonction qui lit une trame sur le port ttys+numttys
	#read(taille max trame)
	exec("trame = portserie"+str(numttys)+".read(50)")
	#TRAME RECUE APRES TIMEOUT max
	return trame

def analysetrame (trame) :
	#fonction qui analyse une trame recue et qui la renvoie si ok ou genere une tramme erreur
	#
	if len(trame) == 0 :
		return "tramevide"
	else :
		return "trame a analyser"

def exit () :
	#exit - fermeture des ports
	#for i in range (2) :
		#exec("portserie"+str(i)+".close()")
	Dialogue.portserie1.close()
