/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : Projet sous-marin
				   Carte capteur
* Author 		 : Echevin Benoît
* Created		 : 02/03/2012
* Last revised	 : 20/04/2012
* Version		 : 4.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : 3x DS1621 on I2C bus
*
**********************************************************************/

/***** Liste des includes *****/
#include <avr/io.h>
#include <avr/interrupt.h>
#include "3964r.h"
#include "main.h"
#include "I2Cmaster.h"
#include "DS1621.h"
#include "usart.h"
#include "timer1.h"
#include "ADC_FUNCTIONS.h"
#include "IMPULSE_FUNCTIONS.h"
#include <util/delay.h>

/***** Variables globales *****/
unsigned char bufUSART_RX = 0;						// Buffer contenant l'octet reçu sur RX
unsigned char dev1_access, dev2_access, dev3_access; 	// Contient l'état de connexion des capteur
char listTemp [6];										// Tableau des températures
char data [5];											// Tableau des informations reçues								
char numero_capteur;									// Indique le numéro du capteur
unsigned char statut_acquisition;						// Indique si les informations ont bien été prise du capteur
unsigned char decalage;									// Utilisé pour décaler les demandes de la FoxBoard lorsqu'une réponse a été réalisé
unsigned char fonctionnement_RX;						// Permet de déterminer si l'interruption sur le RX est du à la réception d'une commande de la FoxBoard
														//		ou à une vérification lors de l'envoi de donné vers celle-ci.
unsigned char TRANSMIT_STATUT ;
char data_to_transmit [2] ;								// Tableau des informations à envoyer 

char ADC_Choice = 0;

unsigned char nbpulse_1 = 0;
unsigned char nbpulse_2 = 0;
unsigned char Sens_0 = 1;
unsigned char Sens_1 = 1;

char ADC1L, ADC1H, ADC2L, ADC2H, ADC3L, ADC3H,
		ADC4L, ADC4H, IMP1L, IMP1H, IMP2L, IMP2H,
		ACCL, ACCH, HUM1L, HUM1H, HUM2L, HUM2H,
		TEMP1L, TEMP1H, TEMP2L, TEMP2H, TEMP3L, TEMP3H, 
		TEMP4L, TEMP4H, TEMP5L, TEMP5H, TEMP6L, TEMP6H, 
		TEMP7L, TEMP7H, TEMP8L, TEMP8H, ADCL_Temp, ADCH_Temp;



/*****************************************************************/
/*********************** Programme principal *********************/
/*****************************************************************/

int main(void)
{
	/***** Variables locales *****/
	
	init();									// Initialisations globales
	
	dev1_access = initDS1621(ADD1_DS1621);	// Initialiser le capteur de T° n°1
	dev2_access = initDS1621(ADD2_DS1621);	// Initialiser le capteur de T° n°1
	dev3_access = initDS1621(ADD3_DS1621);	// Initialiser le capteur de T° n°1
	

	/* boucle infinie */
	for(;;)
	{	
		if (data[0] == 0x00 )
		{
			_delay_ms(150);
		// Demande des informations aux capteurs
			// CAPTEUR I2C
			/* Si le capteur de T° n°1 est connecté au bus I2C */
			if(numero_capteur==0)
			{
				statut_acquisition = get_DS1621_Devices(ADD1_DS1621, listTemp); // Récupérer T° capteur n°1
				if (statut_acquisition == TRUE)
				{
					TEMP1H = listTemp[0];
					TEMP1L = listTemp[1];
				}
				else 
				{
					TEMP1H = 0xFF ;
					TEMP1L = 0xFF ;
				}
			}
			/* Si le capteur de T° n°2 est connecté au bus I2C */
			else if(numero_capteur==1)
			{
				statut_acquisition = get_DS1621_Devices(ADD2_DS1621, listTemp); // Récupérer T° capteur n°2
				if (statut_acquisition == TRUE)
				{
					TEMP2H = listTemp[0];
					TEMP2L = listTemp[1];
				}
				else 
				{
					TEMP1H = 0xFF ;
					TEMP1L = 0xFF ;
				}
			}
			/* Si le capteur de T° n°3 est connecté au bus I2C */
			else if(numero_capteur==2)
			{
				statut_acquisition = get_DS1621_Devices(ADD3_DS1621, listTemp); // Récupérer T° capteur n°3
				if (statut_acquisition == TRUE)
				{
					TEMP3H = listTemp[0];
					TEMP3L = listTemp[1];
				}
				else 
				{
					TEMP1H = 0xFF ;
					TEMP1L = 0xFF ;
				}
			}

			// ADC
			/* ADC1 */
			/*else if(numero_capteur==3)
			{	
				ADC_Mux(ADC_Choice);	// Sélectionne le canal à mettre sur l'ADC
				ADC_Choice ++ ;
				ADCSRA |= (1<<ADIE); 	// Active l'interruption ADC

			}*/
			/* ADC2 */
			/*else if(numero_capteur==4)
			{
				ADC_Mux(ADC_Choice);	// Sélectionne le canal à mettre sur l'ADC
				ADC_Choice ++ ;
				ADCSRA |= (1<<ADIE);	// Active l'interruption ADC
			}*/
			/* ADC3 */
			/*else if(numero_capteur==5)
			{
				ADC_Mux(ADC_Choice);	// Sélectionne le canal à mettre sur l'ADC
				ADC_Choice ++ ;
				ADCSRA |= (1<<ADIE);	// Active l'interruption ADC
			}*/
			/* ADC4 */
			/*else if(numero_capteur==6)
			{
				ADC_Mux(ADC_Choice);	// Sélectionne le canal à mettre sur l'ADC
				ADC_Choice = 0 ;
				ADCSRA |= (1<<ADIE);	// Active l'interruption ADC
			}*/

			// INCREMENTATION DU NUMERO DE CAPTEUR
			numero_capteur = numero_capteur+1 ;
			if(numero_capteur == nbre_max_capteur)
			{
				numero_capteur = 0;
			}
		}
		else
		{
		// Envoie des informations à la foxboard
			if(data[0]==CMD_INCLINAISON) // Envoie les informations d'inclinaisons du sous-marin
			{
				transmission(CMD_INCLINAISON, ACCL, ACCH);
			}
			else if (data[0]==CMD_HYGROMETRE1) // Envoie les informations d'humidité du premier capteur hygrométrique
			{
				transmission(CMD_HYGROMETRE1, HUM1L, HUM1H);
			}
			else if (data[0]==CMD_HYGROMETRE2) // Envoie les informations d'humidité du deuxième capteur hygrométrique
			{
				transmission(CMD_HYGROMETRE2, HUM2L, HUM2H);
			}
			else if (data[0]==CMD_BALLAST) // Envoie les informations de la position du ballast
			{
				IMP1L = nbpulse_1 ;
				IMP1H = 0x00 ;
				transmission(CMD_BALLAST, IMP1L, IMP1H);
			}
			else if (data[0]==CMD_SYSTEME_BALLAST) // Envoie les informations de la position du chariot portant le ballast
			{
				IMP1L = nbpulse_2 ;
				IMP1H = 0x00 ;
				transmission(CMD_SYSTEME_BALLAST, IMP2L, IMP2H);
			}
			else if (data[0]==CMD_TEMP1) // Envoie les informations de température du premier capteur
			{
				transmission(CMD_TEMP1, TEMP1L, TEMP1H);
				sbiBF(PORTD,2);
				cbiBF(PORTD,3);
				cbiBF(PORTD,4);
			}
			else if (data[0]==CMD_TEMP2) // Envoie les informations de température du deuxième capteur
			{
				transmission(CMD_TEMP2, TEMP2L, TEMP2H);
				cbiBF(PORTD,2);
				sbiBF(PORTD,3);
				cbiBF(PORTD,4);
			}
			else if (data[0]==CMD_TEMP3) // Envoie les informations de température du troisième capteur
			{
				transmission(CMD_TEMP3, TEMP3L, TEMP3H);
				cbiBF(PORTD,2);
				cbiBF(PORTD,3);
				sbiBF(PORTD, 4);
			}
			else if (data[0]==CMD_TEMP4) // Envoie les informations de température du quatrième capteur
			{
				transmission(CMD_TEMP4,TEMP4L, TEMP4H);
			}
			else if (data[0]==CMD_TEMP5) // Envoie les informations de température du cinquième capteur
			{
				transmission(CMD_TEMP5, TEMP5L, TEMP5H);
			}
			else if (data[0]==CMD_TEMP6) // Envoie les informations de température du sixième capteur
			{
				transmission(CMD_TEMP6, TEMP6L, TEMP6H);
			}
			else if (data[0]==CMD_TEMP7) // Envoie les informations de température du septième capteur
			{
				transmission(CMD_TEMP7, TEMP7L, TEMP7H);
			}
			else if (data[0]==CMD_TEMP8)  // Envoie les informations de température du huitième capteur
			{
				transmission(CMD_TEMP8, TEMP8L, TEMP8H);
			}
			else if (data[0]==CMD_PROFONDEUR) // Envoie les informations de pression reçue par le capteur de pression comme indicatif de la profondeur
			{
				transmission(CMD_PROFONDEUR, ADC1L, ADC1H);
			}
			else if (data[0]==CMD_ADC2) // Envoie les informations du deuxième convertisseur ADC
			{
				transmission(CMD_ADC2, ADC2L, ADC2H);
			}
			else if (data[0]==CMD_ADC3) // Envoie les informations du troisième convertisseur ADC
			{
				transmission(CMD_ADC3, ADC3L, ADC3H);
			}
			else if (data[0]==CMD_ADC4) // Envoie les informations du quatrième convertisseur ADC
			{
				transmission(CMD_ADC4, ADC4L, ADC4H);
			}
			else if (data[0]==CMD_SENS_0_POSITIF)
			{
				Sens_0 = 1 ;
				transmission(CMD_SENS_0_POSITIF,Conf_sens0p, 0x00 );
			}
			else if (data[0]==CMD_SENS_0_NEGATIF)
			{
				Sens_0 = 0 ;
				transmission(CMD_SENS_0_NEGATIF,Conf_sens0n, 0x00 );
			}
			else if (data[0]==CMD_SENS_1_POSITIF)
			{
				Sens_1 = 1 ;
				transmission(CMD_SENS_1_POSITIF,Conf_sens1p, 0x00 );
			}
			else if (data[0]==CMD_SENS_1_NEGATIF)
			{
				Sens_1 = 0 ;
				transmission(CMD_SENS_1_NEGATIF, Conf_sens1n, 0x00 );
			}
			else // Signale la réception d'un caractère éronné 
			{
				/*do 
				{
					data_to_transmit[0]=0x0F;
					data_to_transmit[0]=0xF0;
					TRANSMIT_STATUT = send_data_3964r(data_to_transmit,2);
				}while (TRANSMIT_STATUT == 0);*/
			}
			for(decalage=0;decalage<=4;decalage++) // Décale les demandes pour supprimer la première et passer au traitement de la demande suivante
			{
				data[decalage]=data[decalage+1];	
			}
			data[4] = 0x00 ;
		}		
	}
	return 0;	
}


/*************************/
/***** Interruptions *****/
/*************************/

/***** Interruption usart en reception *****/

ISR(USART_RX_vect)
{
	if(fonctionnement_RX==0) // mode d'envoi
	{
		//Si un caractère est reçu, on set le flag_usart à TRUE pour quitter la boucle de getchar_usart
		flag_usart = TRUE;
	}
	else if (fonctionnement_RX==1) // mode de réception
	{
		get_data_3964r(data);
		sbiBF(PORTB,1);	
		data[4]=0x00; // Force le dernier bit des demandes à 0.  Au maximum 4 demandes qui n'ont pas été traitée peuvent être enregistrée.		
	}
}


//***** ADC *****//

/*ISR (ADC_vect)
{
	ADCL_Temp = ADCL;
	ADCH_Temp = ADCH;
	switch (ADC_Choice)
	{
		case 0:
			ADC1L = ADCL_Temp;
			ADC1H = ADCH_Temp;
			break;
		case 1:
			ADC2L = ADCL_Temp;
			ADC2H = ADCH_Temp;
			break;
		case 2:
			ADC3L = ADCL_Temp;
			ADC3H = ADCH_Temp;
			break;
		case 3:
			ADC4L = ADCL_Temp;
			ADC4H = ADCH_Temp;
			break;
		default:
			ADC1L = ADCL_Temp;
			ADC1H = ADCH_Temp;
			break;
	}
	ADCSRA &= ~(1<<ADIE);  // Désactive l'interruption de ADC
}*/


//***** TEMPO_0 20ms *****//

/*ISR (TIMER0_COMPA_vect)
{
	TIMER0_20ms_Stop();
	PCINT0_ON();
}*/


//***** TEMPO_2 20ms *****//

/*ISR (TIMER2_COMPA_vect)									//Tempo 2 est prioritaire sur Tempo 1
{
	TIMER2_20ms_Stop();
	PCINT1_ON();
}*/


//***** INT0 *****//

/*ISR (INT0_vect)											//INT 0 est prioritaire sur INT 1
{
	PCINT0_OFF();

	if (Sens_0 == 1)											
		nbpulse_1 ++;
	else
		nbpulse_1 --;

	TIMER0_20ms_Start();
}*/


//***** INT1 *****//

/*ISR (INT1_vect)
{
	PCINT1_OFF();

	if (Sens_1 == 1)											
		nbpulse_2 ++;
	else
		nbpulse_2 --;

	TIMER2_20ms_Start();							
}*/


/*************************/
/******* Fonctions *******/
/*************************/

/***** Initialisation *****/
void init()							
{
	unsigned char i ;
	cli();							// Désactiver toutes les interruptions
    
	sDDR(DDRB,0); 					// PORTB.0 en sortie
	sDDR(DDRB,1); 					// PORTB.1 en sortie
	sDDR(DDRD,2);
	sDDR(DDRD,3);
	sDDR(DDRD,4);
	cbiBF(PORTB,0);					// Mettre à zéro le portB.0

	sDDR(DDRD,1);					// mettre port TX en sortie
	sbiBF(PORTD,0); 				// mettre pull-up sur RX

	for(i=0;i<=4;i++)				// Initialiser les demandes à 0 qui signifie qu'il n'y a pas de demande de la part de la FoxBoard
	{
		data[i]=0x00;
	}

    i2c_init();              		// Initialisation interface I2C

	init_3964r();					// Initialisation de la communication en protocole 3964 avec la FoxBoard
	ENABLE_RX_INT_USART;			// Autoriser les interruption série RX
	fonctionnement_RX = 1;			// mode de réception

	//ADC_Init();						// Initialisation des ADC
	//ADC_Mux(ADC_Choice);			// Sélectionne le premier canal ADC
	//ADC_Start();					// Lance les conversions des ADC

	//PCINT_Init();					// Initialise les interruptions sur INT0 et INT1
	//TIMER0_20ms_Init();				// Initialise timer 0
	//TIMER2_20ms_Init();				// Initialise timer 2
	//PCINT0_ON();					// Active les interruptions sur INT0
	//PCINT1_ON();					// Active les interruptions sur INT1

	sei();							// Activer toutes les interruptions	
}


/***** Transmission vers FoxBoard *****/
void transmission(char commande, char data_low, char data_high)
{
	if ((data_low!=0xFF)&(data_high!=0xFF)) 						// Si FF pour les deux data, alors le capteur n'est pas connecter
	{
		data_to_transmit[0]=commande;
		data_to_transmit[1]=data_low;								// Charge le byte de poid faible dans le premier byte			
		data_to_transmit[2]=data_high;								// Charge le byte de poid fort dans le deuxième byte
	}
	else															// si le capteur n'est pas connecter, alors on envoie deux octets
	{																//		avec tous les bits à 0
		data_to_transmit[0] = 0 ;
		data_to_transmit[1] = 0 ;
		data_to_transmit[2] = 0 ;
	}
	DISABLE_RX_INT_USART;
	fonctionnement_RX = 0 ; 									// Indique que l'on va se mettre en mode d'envoi de donné vers la Fox
	TRANSMIT_STATUT = send_data_3964r(data_to_transmit,3);			// Envoie les deux bytes en protocole 3964	
	fonctionnement_RX = 1 ;									// Indique que l'on se remet en mode de réception de donnée venant de la Fox
	
	ENABLE_RX_INT_USART;
}
