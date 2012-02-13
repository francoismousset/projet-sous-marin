/****************************************************************
 *																*
 *	FileName :		main.c										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		18/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "main.h"

//Constante à décommenter pour compiler le programme en mode DEBUG
//Le mode DEBUG permet de piloter manuellement les moteurs par le port série
//#define DEBUG
#ifdef DEBUG
#include <stdlib.h>
#include "usart.h"
#endif

//Permet d'avoir la fonction get_positionX(); afin d'obtenir le nombre d'impulsion sans étalonnage
#include "external_interrupt.h"

//Programme principale
int main(void)
{
#ifdef DEBUG
	unsigned char commande_mot = 0, sens_rotation = 0, vitesse = 0;
	char tab_vitesse[] = "000";
#else
	char str_cmd[SIZE_MSG];
	unsigned int position = 0;
#endif

	//Fonction pour intialiser les différentes fonctions
	init_main();

	while(1)
	{
#ifndef DEBUG
		//Attente d'une commande 3964 de la FOXBOARD
		//Le tableau str_cmd est rempli par la commande
		//Voir Site sous-marin pour la description des commandes :
		//http://sites.google.com/site/projetsousmarin/sousmarin-v2-0/electronnique-embarquee-2-0/tableau-recapitulatif
		get_data_3964r(str_cmd);

		//Selection du type de commande
		switch(str_cmd[0])
		{
			//Moteur 1
			case 'K':
				//Si Vitesse moteur 1 est != 0
				if(str_cmd[2] != 0)
				{
					//Si le sens de rotation est horlogique (=0)
					if(str_cmd[1] == 0)
						//Definition du sens de rotation
						rotation_motor1(CLOCKWISE);
					else
						//Definition du sens de rotation
						rotation_motor1(COUNTERCLOCKWISE);
					
					//Définition de la vitesse du moteur 1
					set_speed_motor1(str_cmd[2]);
					//Active la sortie ENABLE de la carte driver
					enable_motor1(TRUE);		
				}
				//Si la vitesse du moteur 1 est égale à 0
				else
					//Désactive la sortie ENABLE de la carte driver
					enable_motor1(FALSE);
				break;
			
			//Moteur 2
			case 'M':
				//Si Vitesse moteur 2 est != 0
				if(str_cmd[2] != 0)
				{
					//Si le sens de rotation est horlogique (=0)
					if(str_cmd[1] == 0)
						//Definition du sens de rotation
						rotation_motor2(CLOCKWISE);
					else
						//Definition du sens de rotation
						rotation_motor2(COUNTERCLOCKWISE);
					
					//Définition de la vitesse du moteur 2
					set_speed_motor2(str_cmd[2]);
					//Active la sortie ENABLE de la carte driver
					enable_motor2(TRUE);
				}
				else
					//Désactive la sortie ENABLE de la carte driver
					enable_motor2(FALSE);
				break;

			//Requete de la position du ballast 1
			case 'G':
				//Position est un unsigned int (16bits)
				//position = get_ballast_position1();	//position étalonnée

				//Pour des questions de debugging, je revois le nombre d'impulsion à la FOXBOARD
				position = get_position1();				//Nombre d'impulsion

				//Place les bits de poids faible dans str_cmd[2]
				str_cmd[2] = position & 0x00FF;
				position >>= 8;
				//Place les bits de poids fort dans str_cmd[1]
				str_cmd[1] = position & 0x00FF;

				//On renvoie les informations de position à la FOXBOARD via 3964
				send_data_3964r(str_cmd, SIZE_MSG);
				break;

			//Requete de la position du ballast 2			
			case 'J':
				//Position est un unsigned int (16bits)
				//position = get_ballast_position2();	//position étalonnée

				//Pour des questions de debugging, je revois le nombre d'impulsion à la FOXBOARD
				position = get_position2();				//Nombre d'impulsion

				//Place les bits de poids faible dans str_cmd[2]
				str_cmd[2] = position & 0x00FF;
				position >>= 8;
				//Place les bits de poids fort dans str_cmd[1]
				str_cmd[1] = position & 0x00FF;

				//On renvoie les informations de position à la FOXBOARD via 3964
				send_data_3964r(str_cmd, SIZE_MSG);
				break;

			default:
				break;		
		}

//Compilation en mode DEBUG
#else
		//Initialisation des variables
		commande_mot = 0;
		sens_rotation = 0;
		vitesse = 255;

		//Demande une commande valide pour actionner le moteur (M, m, K ou k)
		while((commande_mot != 'M') && (commande_mot != 'K') && (commande_mot != 'm') && (commande_mot !='k'))
		{
			puts_usart("Commande moteur ('M' | 'K') : ");
			commande_mot = getchar_usart();
			putchar_usart(commande_mot);

			//Carriage return (caractère pour le retour à la ligne)
			putchar_usart(0x0d);
			putchar_usart(0x0a);
		}
		//Demande un sens de rotation valide (0 ou 1)
		while((sens_rotation != '0') && (sens_rotation != '1'))
		{
			puts_usart("Sens de rotation (0 ou 1) : ");
			sens_rotation = getchar_usart();
			putchar_usart(sens_rotation);

			//Carriage return (caractère pour le retour à la ligne)
			putchar_usart(0x0d);
			putchar_usart(0x0a);
		}
		//Demande d'entrer une vitesse entre 0 et 254
		while((vitesse < 0) || (vitesse > 254))
		{
			puts_usart("Vitesse (000 -> 255) : ");
			gets_usart(tab_vitesse,3);
			puts_usart(tab_vitesse);
			vitesse = (unsigned char)atoi(tab_vitesse);
			
			//Carriage return (caractère pour le retour à la ligne)
			putchar_usart(0x0d);
			putchar_usart(0x0a);
		}

		//Execution de la commande moteur
		//Moteur 1
		if((commande_mot == 'M') || (commande_mot =='m'))
		{
			//Sens de rotation
			if(sens_rotation != '0')
				rotation_motor2(COUNTERCLOCKWISE);
			else
				rotation_motor2(CLOCKWISE);
			//Vitesse moteur
			if(vitesse != 0)
				enable_motor2(TRUE);
			else
				enable_motor2(FALSE);
			set_speed_motor2(vitesse);
				
		}
		//Moteur 2
		else
		{
			//Sens de rotation
			if(sens_rotation != '0')
				rotation_motor1(COUNTERCLOCKWISE);
			else
				rotation_motor1(CLOCKWISE);
			//Vitesse moteur
			if(vitesse != 0)
				enable_motor1(TRUE);
			else
				enable_motor1(FALSE);
			set_speed_motor1(vitesse);
		}
#endif
	}
	return 42; //http://fr.wikipedia.org/wiki/La_grande_question_sur_la_vie,_l%27univers_et_le_reste
}

//Fonction d'appel d'initialisation vers les différents fonctions de la carte moteur
void init_main(void)
{
	//L'activation des interruptions est nécessaire pour le watchdog
	sei();

	//L'ordre des différentes initialisations est importante !
	//Du plus au moins critique
	init_watchdog();
	init_motor_driver(); //Vide les ballasts sur FC
	init_ballast_position();
	init_3964r();
}
