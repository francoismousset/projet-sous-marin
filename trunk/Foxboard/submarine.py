#Brebois Jerome
#
#programme principale Sousmarin
#
#Lancer le scipt a chaque demarage de la foxboard :sequence initialisation
#

#librairies a inclure
import serial
import adc
import Dialogueus
import Regulation
import time

#initialisation
Dialogueus.init()
adc.init()
Regulation.init()

#permet de boucler dans le programme principal jusqu'a ce que la commande exit 'Z' soit recue
dialogcomputertrame = ""
#Main
#ajouter un timer si pas de commande pendant 2 min remonter
while (dialogcomputertrame != 'Z' ) :
	#recevoir trame du Pc / que faire
	dialogcomputertrame = ""
	while (len(dialogcomputertrame)==0):
		time.sleep(0.5)
		dialogcomputertrame = Dialogueus.recevoir(0)
	#dialogactionneurtrame = Dialogueus.recevoir(1)
	#Traitements des donnees/interpretation de la trame recue
	#Commandes eventuelles
	if (dialogcomputertrame == 'A') :
		#demande de profondeur activee
		print "trame recue 'A'"
		Dialogueus.envoyer(0,adc.readperiph('pression0'))
	elif (dialogcomputertrame == 'C') :
		#Demande de roulis activee
		print "trame recue 'C'"
		Dialogueus.envoyer(0,adc.readperiph('axeX0'))
	elif (dialogcomputertrame == 'E') :
		#Demande de tangage activee
		print "trame recue 'E'"
		Dialogueus.envoyer(0,adc.readperiph('axeY0'))
	elif (dialogcomputertrame == 'G') :
		#Demande de position du ballast 0 activee
		print "trame recue 'G'"
		posballast0 = Regulation.thdb0.valeuractuelle0
		tramme = 'G'+str(posballast0/256)+str(posballast0%256)
		Dialogueus.envoyer(0,tramme)
	elif (dialogcomputertrame == 'I') :
		#Demande de position du ballast 1 activee
		print "Trame recue 'I'"
		posballast1 = Regulation.thdb0.valeuractuelle1
		tramme = 'G'+str(posballast1/256)+str(posballast1%256)
		Dialogueus.envoyer(0,tramme)
	elif (dialogcomputertrame[0] == 'K') :
		#consigne de position du ballast0 + 2byte
		print "Trame recue : "+dialogcomputertrame
		Regulation.reguler('ballast0',ord(dialogcomputertrame[1])*256+ord(dialogcomputertrame[2]))
	elif (dialogcomputertrame == 'M') :
		#consigne de position du ballast1 + 2byte
		print "Trame recue 'M'"
		Regulation.reguler('ballast1',ord(dialogcomputertrame[1])*256+ord(dialogcomputertrame[2]))
	#elif (dialogcomputertrame == 'O') :
		#Demande du tableau de processus en cours
	#elif (dialogcomputertrame == 'P') :
		#Reglage de l offset des capteurs
	elif (dialogcomputertrame == 'T') :
		#Demande de temperature
		print "Trame recue 'T'"
		Dialogueus.envoyer(0,adc.readperiph('temperature'))
	elif (dialogcomputertrame == 'Z') :
		#Remonter le sous marin
		#Vidage Ballast 0
		print "Trame recue 'Z'"
		Regulation.reguler('ballast0',0)
		#Vidage Ballast 1
		Regulation.reguler('ballast1',00)		
		#exit
		Regulation.kill()
		Dialogueus.exit()
		print "au revoir ..."
	#else :
		#if (len(dialogcomputertrame) ==0) :
			#Trame vide : ok
			#reguler
			#clignotter led
		#else :
			#Trame Erronee 		
			#
	# delai minimal d'attente d'une tramme ?

#fin du programme

# En cas de probleme grave ou d'erreurs non geree -> remonter le sous-marin

