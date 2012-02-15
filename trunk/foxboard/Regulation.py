# Projet Sousmarin
#
# Brebois Jerome
#
# Fonctions qui Gere et regule les differents parametres
#

import Dialoguemoteur
import adc
import time
import threading

thdb0 = 1

def init () :
	print "ok"
	Dialoguemoteur.init()
	#initialisation des thread
	#thread
	global thdb0
	thdb0 = thdpositionner (0,0)
	thdb0.start()

def kill() :
	# attendre
	while ((thdb0.valeuractuelle0 + thdb0.valeuractuelle1)>10):
		time.sleep(0.1)
	if (thdb0.valeuractuelle0 + thdb0.valeuractuelle1)<10:
		thdb0.stop()

def lirepositionballast (ballast) :
	valeuractuelle = ''
	if (ballast == 0):
		while (len(valeuractuelle)==0):
			Dialoguemoteur.envoyer(1,'G')
			time.sleep(0.1)
			valeuractuelle =  Dialoguemoteur.recevoir(1)
			if (len(valeuractuelle)==3):
				#on doit avoir recut 3byte commencant par 'G'
				if valeuractuelle[0] == 'G':
					valeuractuelle = valeuractuelle[1:3]
				else :
					valeuractuelle = ''
			else : 
				valeuractuelle = ''
		valeuractuelle = ord(valeuractuelle[0])*256+ord(valeuractuelle[1])
		print ("trame recue = G +"+str(valeuractuelle))
		return valeuractuelle
	elif (ballast == 1):
		while (len(valeuractuelle)==0):
			Dialoguemoteur.envoyer(1,'J')
			time.sleep(0.1)
			valeuractuelle =  Dialoguemoteur.recevoir(1)
			if (len(valeuractuelle)==3):
				#on doit avoir recut 3byte commencant par 'J'
				if valeuractuelle[0] == 'J':
					valeuractuelle = valeuractuelle[1:3]
				else :
					valeuractuelle = ''
			else : 
				valeuractuelle = ''
		valeuractuelle = ord(valeuractuelle[0])*256+ord(valeuractuelle[1])
		print ("trame recue = J +"+str(valeuractuelle))
		return valeuractuelle
	else :
		print "erreur lecture position ballast"
		return 0
		
class surveillance (threading.Thread) :
	#THREAD qui calcul la position des moteur si pas de fourche optique
	def __init__(self) :
		threading.Thread.__init__(self)
		self.terminated = False
		self.XposB0calc = 0
		self.XposB1calc = 0
		self.sensB0 = 0
		self.sensB1 = 0
		self.vitB0 = 0
		self.vitB1 = 0			
		# facteur de correction Vitesse * temps = distance (255*30s*factCorr=1023)
		self.fact = 0.1337
	def run(self) :
		while not self.terminated :
			tinit = time.time()
			time.sleep(0.1)
			if (self.vitB0 != 0) :
				if (self.sensB0 == 0x00):
					#on avance pour remplir les ballast => pos++
					self.XposB0calc = self.XposB0calc + self.vitB0*self.fact*(time.time()-tinit)
					if (self.XposB0calc >= 1023 ) :
						self.XposB0calc = 1023
				if (self.sensB0 == 0x01):
					#on recule pour vider les ballast => pos--
					self.XposB0calc = self.XposB0calc - self.vitB0*self.fact*(time.time()-tinit)
					if (self.XposB0calc <= 0 ) :
						self.XposB0calc = 0						
			if (self.vitB1 != 0) :
				if (self.sensB1 == 0x00):
					#on avance pour remplir les ballast => pos++
					self.XposB1calc = self.XposB1calc + self.vitB1*self.fact*(time.time()-tinit)
					if (self.XposB1calc >= 1023 ) :
						self.XposB1calc = 1023
				if (self.sensB1 == 0x01):
					#on recule pour vider les ballast => pos--
					self.XposB1calc = self.XposB1calc - self.vitB1*self.fact*(time.time()-tinit)
					if (self.XposB1calc <= 0 ) :
						self.XposB1calc = 0	
	def stop():
		self.terminated = True
		

class thdpositionner (threading.Thread) :
	def __init__(self,parainit0=0,parainit1=0):
		threading.Thread.__init__(self)
		self.Terminated = False
		self.parametre0 = parainit0
		self.parametre1 = parainit1
		self.vitesse0 = 0
		self.vitesse1 = 0
		##ajouter variable param et valeur 0 et 1
	def run(self):
		tmp_time0 = time.time()
		tmp_time1 = time.time()
		while not self.Terminated:
			#
			self.valeuractuelle0 = lirepositionballast(0)
			time.sleep(1)
			self.valeuractuelle1 = lirepositionballast(1)
			if (self.valeuractuelle0 < self.parametre0) :
				#avance du piston ballast0
				if (((time.time()-tmp_time0) > 0.1)and (abs(self.parametre0-self.valeuractuelle0)>60)):
					print '#le moteur tourne depuis plus de 0.1Sec et est eloigner'
					if (self.vitesse0 < 245) :
						self.vitesse0 += 10
					tramevitesse = 'K'+chr(0x00)+chr(self.vitesse0)
					print "#la vitesse demandee est de"+str(self.vitesse0)
					Dialoguemoteur.envoyer(1,tramevitesse)
					tmp_time0 = time.time()
				elif (((time.time()-tmp_time0) > 0.1) and (abs(self.parametre0-self.valeuractuelle0)<60) and (abs(self.parametre0-self.valeuractuelle0)>5)) :
					print'#le moteur tourne depuis plus de 0.1S et est proche'
					if (self.vitesse0 > 15) :
						self.vitesse0 -= 10
					elif (self.vitesse0 == 0 ) :
						self.vitesse0 = 5
					tramevitesse = 'K'+chr(0x00)+chr(self.vitesse0)
					Dialoguemoteur.envoyer(1,tramevitesse)
					tmp_time0 = time.time()
				elif (abs(self.parametre0-self.valeuractuelle0) < 5):
					print"#on considere qu'on a atteint la position demandee Ballast0 est corectement positionner"
					tramevitesse = 'K'+chr(0x00)+chr(0x00)
					Dialoguemoteur.envoyer(1,tramevitesse)	
			elif (self.valeuractuelle0 > self.parametre0) :
				#recul du piston ballast0
				if (((time.time()-tmp_time0) > 0.1)and (abs(self.parametre0-self.valeuractuelle0)>60)):
					if (self.vitesse0 < 245) :
						self.vitesse0 += 10
					tramevitesse = 'K'+chr(0x01)+chr(self.vitesse0)
					Dialoguemoteur.envoyer(1,tramevitesse)
					tmp_time0 = time.time()
				elif (((time.time()-tmp_time0) > 0.10) and (abs(self.parametre0-self.valeuractuelle0)<60)and (abs(self.parametre0-self.valeuractuelle0)>5)) :			
					# on se rapproche du point B
					# on diminue la vitesse progressivement
					if (self.vitesse0 > 15) :
						self.vitesse0 -= 10
					elif (self.vitesse0 == 0 ) :
						self.vitesse0 = 5
					tramevitesse = 'K'+chr(0x01)+chr(self.vitesse0)
					Dialoguemoteur.envoyer(1,tramevitesse)
					#on reset le compteur de temps
					tmp_time0 = time.time()
				elif (abs(self.parametre0-self.valeuractuelle0) <5):
					#on considere qu'on a atteint la position demandee ballast0 = ok
					tramevitesse = 'K'+chr(0x01)+chr(0x00)
					Dialoguemoteur.envoyer(1,tramevitesse)	
			elif (self.valeuractuelle0 == self.parametre0) :
				#le ballast 0 est corectement positionner
				tramevitesse = 'K'+chr(0x00)+chr(0x00)
				Dialoguemoteur.envoyer(1,tramevitesse)
			time.sleep(2)
			if (self.valeuractuelle1 < self.parametre1) :
				print"#avance du piston ballast1"
				if (((time.time()-tmp_time1) > 0.1)and (abs(self.parametre1-self.valeuractuelle1)>60)):
					print "#le piston B1 est loin"
					if (self.vitesse1 < 245) :
						self.vitesse1 += 10
					tramevitesse = 'M'+chr(0x00)+chr(self.vitesse1)
					print "#la vitesse demandee est de"+str(self.vitesse1)
					Dialoguemoteur.envoyer(1,tramevitesse)
					tmp_time1 = time.time()
				elif (((time.time()-tmp_time1) > 0.1) and (abs(self.parametre1-self.valeuractuelle1)<60) and (abs(self.parametre1-self.valeuractuelle1)>5)) :
					print "#le piston B1 est proche"
					if (self.vitesse1 > 15) :
						self.vitesse1 -= 10
					elif (self.vitesse1 == 0 ) :
						self.vitesse1 = 5
					tramevitesse = 'M'+chr(0x00)+chr(self.vitesse1)
					Dialoguemoteur.envoyer(1,tramevitesse)
					tmp_time1 = time.time()
				elif (abs(self.parametre1-self.valeuractuelle1) < 5):
					print"#on considere qu'on a atteint la position demandee Ballast1 est corectement positionner"
					tramevitesse = 'M'+chr(0x00)+chr(0x00)
					Dialoguemoteur.envoyer(1,tramevitesse)	
			elif (self.valeuractuelle1 > self.parametre1) :
				print"#recul du piston ballast1"
				if (((time.time()-tmp_time1) > 0.1)and (abs(self.parametre1-self.valeuractuelle1)>60)):
					if (self.vitesse1 < 255) :
						self.vitesse1 += 10
					tramevitesse = 'M'+chr(0x01)+chr(self.vitesse1)
					Dialoguemoteur.envoyer(1,tramevitesse)
					tmp_time1 = time.time()
				elif (((time.time()-tmp_time1) > 0.10) and (abs(self.parametre1-self.valeuractuelle1)<60)and (abs(self.parametre1-self.valeuractuelle1)>5)) :			
					# on se rapproche du point B
					# on diminue la vitesse progressivement
					if (self.vitesse1 > 15) :
						self.vitesse1 -= 10
					elif (self.vitesse1 == 0 ) :
						self.vitesse1 = 5
					tramevitesse = 'M'+chr(0x01)+chr(self.vitesse1)
					Dialoguemoteur.envoyer(1,tramevitesse)
					#on reset le compteur de temps
					tmp_time1 = time.time()
				elif (abs(self.parametre1-self.valeuractuelle1) <5):
					#on considere qu'on a atteint la position demandee ballast1 = ok
					tramevitesse = 'M'+chr(0x01)+chr(0x00)
					Dialoguemoteur.envoyer(1,tramevitesse)	
			elif (self.valeuractuelle1 == self.parametre1) :
				#
				tramevitesse = 'M'+chr(0x00)+chr(0x00)
				Dialoguemoteur.envoyer(1,tramevitesse)

		print "le thread est terminer correctement"
	def stop(self) :
		self.Terminated = True

def reguler (peripherique,parametre) :
	#
	if (peripherique == 'ballast0') :
		thdb0.parametre0 = parametre
	if (peripherique == 'ballast1') :
		thdb0.parametre1 = parametre
