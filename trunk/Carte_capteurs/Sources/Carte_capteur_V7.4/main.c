/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : Projet sous-marin
				   Carte capteur
* Author 		 : Echevin Benoît & Michaël Brogniaux
* Created		 : 02/03/2012
* Last revised	 : 10/05/2012
* Version		 : 6.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : 8x DS7505 on I2C bus
*
**********************************************************************/

/***** Liste des includes *****/
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "3964r.h"
#include "main.h"
#include "I2Cmaster.h"
#include "usart.h"

#include "timer1.h"
#include "ADC.h"
//#include "watchdog.h"
#include "DS7505.h"
#include "SHT21.h"
#include "gestion_T.h"
#include "gestion_H.h"
#include "gestion_P.h"
#include "gestion_A.h"


/***** Variables globales *****/
unsigned char bufUSART_RX = 0;						// Buffer contenant l'octet reçu sur RX
char tempHum;
char listTemp [3], Result[1];			// Tableau
char data [DATADIMENSION];											// Tableau des informations reçues								
int datanumber = 0;
char numero_capteur;									// Indique le numéro du capteur

unsigned char decalage;									// Utilisé pour décaler les demandes de la FoxBoard lorsqu'une réponse a été réalisé
unsigned char fonctionnement_RX;						// Permet de déterminer si l'interruption sur le RX est du à la réception d'une commande de la FoxBoard
														//		ou à une vérification lors de l'envoi de donné vers celle-ci.
unsigned char TRANSMIT_STATUT ;
char data_to_transmit [2] ;								// Tableau des informations à envoyer 

char ADC_Choice = 0;

unsigned char Sens_0 = 1;
unsigned char Sens_1 = 1;

char ADC1L, ADC1H, ADC2L, ADC2H, ADC3L, ADC3H,
		ADC4L, ADC4H, IMP1L, IMP1H, IMP2L, IMP2H,
		ACCL, ACCH, HUM1L, HUM1H, HUM2L, HUM2H,
		TEMP1L, TEMP1H, TEMP2L, TEMP2H, TEMP3L, TEMP3H, 
		TEMP4L, TEMP4H, TEMP5L, TEMP5H, TEMP6L, TEMP6H, 
		TEMP7L, TEMP7H, TEMP8L, TEMP8H, ADCL_Temp, ADCH_Temp;

int ProfInit;

volatile char NEED_RECEIVED = FALSE;
unsigned int i;
unsigned int NombreDePassage = 50;

volatile char debug = FALSE; // false = liaison série avec 3964 // true = liasion série simple



/*****************************************************************/
/*********************** Programme principal *********************/
/*****************************************************************/

int main(void)
{
	/***** Variables locales *****/
	unsigned char dev1_access, dev2_access, dev3_access, dev4_access, dev5_access, dev6_access, dev7_access, dev8_access, dev9_access;						// Indique si les informations ont bien été prise du capteur

	init();									// Initialisations globales
	
	dev1_access = initDS7505(ADD1_DS7505);	// Initialiser le capteur de T° n°1
	dev2_access = initDS7505(ADD2_DS7505);	// Initialiser le capteur de T° n°2
	dev3_access = initDS7505(ADD3_DS7505);	// Initialiser le capteur de T° n°3
	dev4_access = initDS7505(ADD4_DS7505);	// Initialiser le capteur de T° n°4
	dev5_access = initDS7505(ADD5_DS7505);	// Initialiser le capteur de T° n°5
	dev6_access = initDS7505(ADD6_DS7505);	// Initialiser le capteur de T° n°6
	dev7_access = initDS7505(ADD7_DS7505);	// Initialiser le capteur de T° n°7
	dev8_access = initDS7505(ADD8_DS7505);	// Initialiser le capteur de T° n°8
	dev9_access = initSHT21(ADD1_SHT21);	// Initialiser le capteur d'%RH n°1	


	/* boucle infinie */
	for(;;)
	{	
		if(NEED_RECEIVED == TRUE) 
		{
			get_data_3964r(data);
			data[DATADIMENSION-1]=0x00; // Force le dernier bit des demandes à 0.  Au maximum 4 demandes qui n'ont pas été traitée peuvent être enregistrée.	
			NEED_RECEIVED = FALSE;
		}
		if( data[0] != 0x00 ) // Envoie des informations à la foxboard
		{
			switch(data[0])
			{
				case CMD_HYGROMETRE1 : // Envoie les informations d'humidité du premier capteur hygrométrique
					dev9_access = get_SHT21_Devices(ADD1_SHT21, listTemp);
					if(dev9_access) {HUM1H=0xFF; HUM1L=0xFF;}
					else tempHum = convertHum(listTemp);
					HUM1H = tempHum;
					HUM1L = 0;					
					transmission(CMD_HYGROMETRE1, HUM1L, HUM1H);
					break;

				case CMD_HYGROMETRE2 : // Envoie les informations d'humidité du deuxième capteur hygrométrique
					HUM2H=0xFF; 
					HUM2L=0xFF;
					transmission(CMD_HYGROMETRE2, HUM2L, HUM2H);
					break;

				case CMD_BALLAST : // Envoie les informations de la position du ballast
					IMP1H=0xFF; 
					IMP1L=0xFF;
					transmission(CMD_BALLAST, IMP1L, IMP1H);
					break;

				case CMD_SYSTEME_BALLAST : // Envoie les informations de la position du chariot portant le ballast
					IMP2H=0xFF; 
					IMP2L=0xFF;
					transmission(CMD_SYSTEME_BALLAST, IMP2L, IMP2H);
					break;

				case CMD_TEMP1 : // Envoie les informations de température du premier capteur
					dev1_access = get_DS7505_Devices(ADD1_DS7505, listTemp); // Récupérer T° capteur n°1
					if(dev1_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP1H = Result[0];
					TEMP1L = Result[1];
					transmission(CMD_TEMP1, TEMP1L, TEMP1H);
					break;

				case CMD_TEMP2 : // Envoie les informations de température du deuxième capteur
					dev2_access = get_DS7505_Devices(ADD2_DS7505, listTemp); // Récupérer T° capteur n°2					
					if(dev2_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP2H = Result[0];
					TEMP2L = Result[1];
					transmission(CMD_TEMP2, TEMP2L, TEMP2H);
					break;

				case CMD_TEMP3 : // Envoie les informations de température du troisième capteur
					dev3_access = get_DS7505_Devices(ADD3_DS7505, listTemp); // Récupérer T° capteur n°3					
					if(dev3_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP3H = Result[0];
					TEMP3L = Result[1];
					transmission(CMD_TEMP3, TEMP3L, TEMP3H);
					break;

				case CMD_TEMP4 : // Envoie les informations de température du quatrième capteur
					dev4_access = get_DS7505_Devices(ADD4_DS7505, listTemp); // Récupérer T° capteur n°3					
					if(dev4_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP4H = Result[0];
					TEMP4L = Result[1];
					transmission(CMD_TEMP4,TEMP4L, TEMP4H);
					break;

				case CMD_TEMP5 : // Envoie les informations de température du cinquième capteur
					dev5_access = get_DS7505_Devices(ADD5_DS7505, listTemp); // Récupérer T° capteur n°3					
					if(dev5_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP5H = Result[0];
					TEMP5L = Result[1];
					transmission(CMD_TEMP5, TEMP5L, TEMP5H);
					break;

				case CMD_TEMP6 : // Envoie les informations de température du sixième capteur
					dev6_access = get_DS7505_Devices(ADD6_DS7505, listTemp); // Récupérer T° capteur n°3					
					if(dev6_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP6H = Result[0];
					TEMP6L = Result[1];
					transmission(CMD_TEMP6, TEMP6L, TEMP6H);
					break;

				case CMD_TEMP7 : // Envoie les informations de température du septième capteur
					dev7_access = get_DS7505_Devices(ADD7_DS7505, listTemp); // Récupérer T° capteur n°3					
					if(dev7_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP7H = Result[0];
					TEMP7L = Result[1];
					transmission(CMD_TEMP7, TEMP7L, TEMP7H);
					break;

				case CMD_TEMP8 :  // Envoie les informations de température du huitième capteur
					dev8_access = get_DS7505_Devices(ADD8_DS7505, listTemp); // Récupérer T° capteur n°3					
					if(dev8_access) {Result[0]=0xFF; Result[1]=0xFF;}
					else convertTemp(listTemp, Result);
					TEMP8H = Result[0];
					TEMP8L = Result[1];
					transmission(CMD_TEMP8, TEMP8L, TEMP8H);
					break;
				
				case CMD_PROFONDEUR : // Envoie les informations de pression reçue par le capteur de pression comme indicatif de la profondeur
					StartADC(0);
					//ReadADC(Result);
					ReadADC(listTemp);
					convertPressure(listTemp, Result, ProfInit);
					ADC1L = Result[0];
					ADC1H = Result[1];
					transmission(CMD_PROFONDEUR, ADC1L, ADC1H);
					break;

				case CMD_ADC2 : // Envoie les informations du deuxième convertisseur ADC
					//ReadADC(Result);
					StartADC(1);
					ReadADC(listTemp);	
					convertAcc(listTemp, Result);				
					ADC2L = Result[0];
					ADC2H = Result[1];
					for(i = 0; i <= NombreDePassage - 2; i++)
					{
						StartADC(1);
						ReadADC(listTemp);	
						convertAcc(listTemp, Result);				
						ADC2L = (ADC2L + Result[0])/2;
					}
					transmission(CMD_ADC2, ADC2L, ADC2H);
					break;

				case CMD_ADC3 : // Envoie les informations du troisième convertisseur ADC
					//ReadADC(Result);
					StartADC(2);
					ReadADC(listTemp);	
					convertAcc(listTemp, Result);				
					ADC3L = Result[0];
					ADC3H = Result[1];
					for(i = 0; i <= NombreDePassage - 2; i++)
					{
						StartADC(2);
						ReadADC(listTemp);	
						convertAcc(listTemp, Result);				
						ADC3L = (ADC3L + Result[0])/2;
					}
					transmission(CMD_ADC3, ADC3L, ADC3H);
					break;
					
				case CMD_INCLINAISON : // Envoie les informations d'inclinaisons du sous-marin
					// ADC1
					StartADC(1);
					ReadADC(listTemp);	
					convertAcc(listTemp, Result);				
					ADC2L = Result[0];
					ADC2H = Result[1];
					for(i = 0; i <= NombreDePassage - 2; i++)
					{
						StartADC(1);
						ReadADC(listTemp);	
						convertAcc(listTemp, Result);				
						ADC2L = (ADC2L + Result[0])/2;
					}
					// ADC2
					StartADC(2);
					ReadADC(listTemp);	
					convertAcc(listTemp, Result);				
					ADC3L = Result[0];
					ADC3H = Result[1];
					for(i = 0; i <= NombreDePassage - 2; i++)
					{
						StartADC(2);
						ReadADC(listTemp);	
						convertAcc(listTemp, Result);				
						ADC3L = (ADC3L + Result[0])/2;
					}
					ACCH = (ADC2H + ADC3H)/2;
					ACCL = (ADC2L + ADC3L)/2;
					transmission(CMD_INCLINAISON, ACCL, ACCH);
					break;

				case CMD_ADC4 : // Envoie les informations du quatrième convertisseur ADC
					StartADC(3);
					//ReadADC(Result);
					ReadADC(listTemp);
					convertAcc(listTemp, Result);
					ADC4L = Result[0];
					ADC4H = Result[1];
					transmission(CMD_ADC4, ADC4L, ADC4H);
					break;

				case CMD_SENS_0_POSITIF :
					Sens_0 = 1 ;
					transmission(CMD_SENS_0_POSITIF,Conf_sens0p, 0x00 );
					break;

				case CMD_SENS_0_NEGATIF :
					Sens_0 = 0 ;
					transmission(CMD_SENS_0_NEGATIF,Conf_sens0n, 0x00 );
					break;

				case CMD_SENS_1_POSITIF :
					Sens_1 = 1 ;
					transmission(CMD_SENS_1_POSITIF,Conf_sens1p, 0x00 );
					break;

				case CMD_SENS_1_NEGATIF :
					Sens_1 = 0 ;
					transmission(CMD_SENS_1_NEGATIF, Conf_sens1n, 0x00 );
					break;

				default :
					asm("nop");
					break;
			}

			for(decalage=0;decalage<=DATADIMENSION-1;decalage++) // Décale les demandes pour supprimer la première et passer au traitement de la demande suivante
			{
				data[decalage]=data[decalage+1];	
			}
			data[DATADIMENSION-1] = 0x00 ;
			datanumber--;
		}
		else
		{
			asm("nop");
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
	if(debug==FALSE)
	{
		if(fonctionnement_RX==0) // mode d'envoi
		{
			//Si un caractère est reçu, on set le flag_usart à TRUE pour quitter la boucle de getchar_usart
			flag_usart = TRUE;
		}
		else if (fonctionnement_RX==1) // mode de réception
		{
			NEED_RECEIVED = TRUE;		
		}
	}
	else
	{	
		data[datanumber] = UDR0;
		datanumber++;
	}
}

/*************************/
/******* Fonctions *******/
/*************************/

/***** Initialisation *****/
void init()							
{
	unsigned char i ;
	cli();							// Désactiver toutes les interruptions

	sDDR(DDRD,1);					// mettre port TX en sortie
	sbiBF(PORTD,0); 				// mettre pull-up sur RX

	for(i=0;i<=DATADIMENSION-1;i++)				// Initialiser les demandes à 0 qui signifie qu'il n'y a pas de demande de la part de la FoxBoard
	{
		data[i]=0x00;
	}

    i2c_init();              		// Initialisation interface I2C

	init_3964r();					// Initialisation de la communication en protocole 3964 avec la FoxBoard
	ENABLE_RX_INT_USART;			// Autoriser les interruption série RX
	fonctionnement_RX = 1;			// mode de réception

	//init_watchdog();				// Initilise les reset

	InitADC();						// Initialise les ADC

	StartADC(0);
	ReadADC(listTemp);
	convertPressure(listTemp, Result, 0);
	ProfInit = Result[0] + Result[1]*256;

	sei();							// Activer toutes les interruptions	
	//transmission(0xFF, Result[0], Result[1]);
}


/***** Transmission vers FoxBoard *****/
void transmission(char commande, char data_low, char data_high)
{
	if(debug==FALSE)
	{
		data_to_transmit[0]=commande;
		data_to_transmit[1]=data_high;								// Charge le byte de poid faible dans le premier byte			
		data_to_transmit[2]=data_low;								// Charge le byte de poid fort dans le deuxième byte

		DISABLE_RX_INT_USART;
		fonctionnement_RX = 0 ; 									// Indique que l'on va se mettre en mode d'envoi de donné vers la Fox
		TRANSMIT_STATUT = send_data_3964r(data_to_transmit,3);			// Envoie les deux bytes en protocole 3964	
		fonctionnement_RX = 1 ;									// Indique que l'on se remet en mode de réception de donnée venant de la Fox
	
		ENABLE_RX_INT_USART;
	}
	else
	{
		putchar_usart(commande);
		putchar_usart(data_low);
		putchar_usart(data_high);
	}
}
