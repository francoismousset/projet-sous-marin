# Projet Sousmarin
#
# Brebois Jerome
#
# Fonctions qui lisent l'adc et gerent les multiplexeurs
#


import fox
import time
import os

#definition des broche du multiplexeur 0 check : v : Temperature
mux0b0 = fox.Pin ('J7.35','low')
#A
mux0b1 = fox.Pin ('J7.36','low')	
#B
mux0b2 = fox.Pin ('J7.37','low')	
#C
mux0e0 = fox.Pin ('J7.38','low')	
#E

#definition des broche du multiplexeur 1 check : V : Batterie + tension 0-10v + Pression
mux2b0 = fox.Pin ('J7.4','low')		
#A
mux2b1 = fox.Pin ('J7.3','low')		
#B
mux2b2 = fox.Pin ('J7.6','low')		
#C
mux2e0 = fox.Pin ('J7.5','low')		
#E

#definition des broche du multiplexeur 2 check : v : Accelerometre
mux1b0 = fox.Pin ('J7.8','low')		
#A
mux1b1 = fox.Pin ('J7.7','low')		
#B
mux1b2 = fox.Pin ('J7.10','low')	
#C
mux1e0 = fox.Pin ('J7.9','low')		
#E
#5 pour enable = recom noy


#fonctions


#enable + disable

def init() :
	# inclure le module capable de gerer les ADCs
	try :
		#
		os.system ('insmod at91_adc.ko')
	except :
		#Le module a deja ete lie au kernel
		print "le module a deja ete lie au kernel"
	#fonction qui va metre a 0 les adresse des multiplexeurs + enable
	#print "initialisation"
	#imux = numero du multiplexeur
	#ib = numero de broche d adresse du multiplexeur
	for imux in range(3):
		#enable e0
		exec ("mux"+str(imux)+"e0.off()")					
		#mets les bits enable des mux a 0 => actif
		for ib in range(3):
			# print "mux"+str(imux)+"b"+str(ib)+".off()"
			exec ("mux"+str(imux)+"b"+str(ib)+".off()")		
			#mets les bits d adresse a,b et c a 0

#fct qui enable un multiplexeur
def muxenable (multiplexeur):
	exec ("mux"+str(multiplexeur)+"e0.off()")

#fct qui disable un multiplexeur
def muxdisable (multiplexeur):
	exec ("mux"+str(multiplexeur)+"e0.on()")

#fonction qui positionne un multiplexeur donne
def posmux (position , multiplexeur):
	if ((position<8) and (multiplexeur<3)):
		for i in range(3) :
			if ((position % 2)>0) :
				exec ("mux"+str(multiplexeur)+"b"+str(i)+".on()")
			else :
				exec ("mux"+str(multiplexeur)+"b"+str(i)+".off()")
			position = position >> 1
	else :
		print "ERREUR position ou multiplexeur trop grand"

#fonction qui lit l'ADC et renvoir une valeur 0-1023
def readval (position,multiplexeur) :
	posmux (position,multiplexeur)
	exec ("adc"+str(multiplexeur)+"=open('/sys/bus/platform/devices/at91_adc/chan"+str(multiplexeur)+"',mode='r')")
	exec ("valeur = int(adc"+str(multiplexeur)+".read(4))")
	exec ("adc"+str(multiplexeur)+"=open('/sys/bus/platform/devices/at91_adc/chan"+str(multiplexeur)+"',mode='r')")
	exec ("valeur = int(adc"+str(multiplexeur)+".read(4))")
	exec ("adc"+str(multiplexeur)+"=open('/sys/bus/platform/devices/at91_adc/chan"+str(multiplexeur)+"',mode='r')")
	exec ("valeur = int(adc"+str(multiplexeur)+".read(4))")
	exec ("adc"+str(multiplexeur)+".close()")

	return valeur


#reecrire avec boucles.
#simplifier en utilisant la vonction readval ds boucle for
def readall () :
	#creation d'une matrice [3*8]
	Tabvaleurs = [],[],[]
	#parcours toutes les positions du mux
	for i in range (8):
		for mux in range(3) :
			posmux (i,mux)
			time.sleep (0.1)	
			Tabvaleurs[mux].append(readval(i,mux))
		#delai en seconde
	return Tabvaleurs
	del Tabvaleurs

#fonction qui pour un peripherique donne renvoie la ou les valeurs desiree
#a completer...
def readperiph (peripherique) :
	#les ballast doivent etre lu a l'aide de la partie regulation
	if (peripherique == 'pression' ):
		return ((((2*1.2*readval (4,1))/1023)-1.8327)/0.0015)
	elif (peripherique == 'temperature0') :
		return readval (0,0)
	elif (peripherique == 'temperature1') :
		return readval (1,0)
	elif (peripherique == 'batterie') :
		return ((3.3*readval (3,2)*(38.23+9.95))/(1023.0*(9.95)))
	elif (peripherique == 'tension0') :
		return ((3.3*readval (3,2)*(38.23+9.95))/(1023.0*(9.95)))	
	elif (peripherique == 'axeX0'):
		return readval (0,2)
	elif (peripherique == 'axeY0'):
		return readval (1,2)
	elif (peripherique == 'axeX1'):
		return readval (2,2)
	elif (peripherique == 'axeY1'):
		return readval (3,2)

	else :
		print "le peripherique demander n existe pas"
		return 'Erreur'

