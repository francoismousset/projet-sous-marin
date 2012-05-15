/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : Projet sous-marin
				   Carte capteur
* Author 		 : Echevin Beno�t & Micha�l Brogniaux
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
#include "watchdog.h"
#include "DS7505.h"
#include "SHT21.h"
#include "gestion_T.h"
#include "gestion_H.h"


/***** Variables globales *****/
unsigned char bufUSART_RX = 0;						// Buffer contenant l'octet re�u sur RX
char tempHum;
char listTemp [3], tempResult[1];			// Tableau
char data [5];											// Tableau des informations re�ues								
char numero_capteur;									// Indique le num�ro du capteur

unsigned char decalage;									// Utilis� pour d�caler les demandes de la FoxBoard lorsqu'une r�ponse a �t� r�alis�
unsigned char fonctionnement_RX;						// Permet de d�terminer si l'interruption sur le RX est du � la r�ception d'une commande de la FoxBoard
														//		ou � une v�rification lors de l'envoi de donn� vers celle-ci.
unsigned char TRANSMIT_STATUT ;
char data_to_transmit [2] ;								// Tableau des informations � envoyer 

char ADC_Choice = 0;

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
	unsigned char dev1_access, dev2_access, dev3_access, dev4_access, dev5_access, dev6_access, dev7_access, dev8_access, dev9_access;						// Indique si les informations ont bien �t� prise du capteur

	init();									// Initialisations globales
	
	dev1_access = initDS7505(ADD1_DS7505);	// Initialiser le capteur de T� n�1
	dev2_access = initDS7505(ADD2_DS7505);	// Initialiser le capteur de T� n�2
	dev3_access = initDS7505(ADD3_DS7505);	// Initialiser le capteur de T� n�3
	dev4_access = initDS7505(ADD4_DS7505);	// Initialiser le capteur de T� n�4
	dev5_access = initDS7505(ADD5_DS7505);	// Initialiser le capteur de T� n�5
	dev6_access = initDS7505(ADD6_DS7505);	// Initialiser le capteur de T� n�6
	dev7_access = initDS7505(ADD7_DS7505);	// Initialiser le capteur de T� n�7
	dev8_access = initDS7505(ADD8_DS7505);	// Initialiser le capteur de T� n�8
	dev9_access = initSHT21(ADD1_SHT21);	// Initialiser le capteur d'%RH n�1


	/* boucle infinie */
	for(;;)
	{	
		if( data[0] != 0x00 ) // Envoie des informations � la foxboard
		{
			switch(data[0])
			{
				case CMD_INCLINAISON : // Envoie les informations d'inclinaisons du sous-marin
					transmission(CMD_INCLINAISON, ACCL, ACCH);
					break;

				case CMD_HYGROMETRE1 : // Envoie les informations d'humidit� du premier capteur hygrom�trique
					dev9_access = get_SHT21_Devices(ADD1_SHT21, listTemp);
					tempHum = convertHum(listTemp);
					HUM1H = tempHum;
					HUM1L = 0;
					
					transmission(CMD_HYGROMETRE1, HUM1L, HUM1H);
					break;

				case CMD_HYGROMETRE2 : // Envoie les informations d'humidit� du deuxi�me capteur hygrom�trique
					transmission(CMD_HYGROMETRE2, HUM2L, HUM2H);
					break;

				case CMD_BALLAST : // Envoie les informations de la position du ballast
					transmission(CMD_BALLAST, IMP1L, IMP1H);
					break;

				case CMD_SYSTEME_BALLAST : // Envoie les informations de la position du chariot portant le ballast
					transmission(CMD_SYSTEME_BALLAST, IMP2L, IMP2H);
					break;

				case CMD_TEMP1 : // Envoie les informations de temp�rature du premier capteur
					dev1_access = get_DS7505_Devices(ADD1_DS7505, listTemp); // R�cup�rer T� capteur n�1
					convertTemp(listTemp, tempResult);
					TEMP1H = tempResult[0];
					TEMP1L = tempResult[1];
					transmission(CMD_TEMP1, TEMP1L, TEMP1H);
					break;

				case CMD_TEMP2 : // Envoie les informations de temp�rature du deuxi�me capteur
					dev2_access = get_DS7505_Devices(ADD2_DS7505, listTemp); // R�cup�rer T� capteur n�2					
					convertTemp(listTemp, tempResult);
					TEMP2H = tempResult[0];
					TEMP2L = tempResult[1];
					transmission(CMD_TEMP2, TEMP2L, TEMP2H);
					break;

				case CMD_TEMP3 : // Envoie les informations de temp�rature du troisi�me capteur
					dev3_access = get_DS7505_Devices(ADD3_DS7505, listTemp); // R�cup�rer T� capteur n�3					
					convertTemp(listTemp, tempResult);
					TEMP3H = tempResult[0];
					TEMP3L = tempResult[1];
					transmission(CMD_TEMP3, TEMP3L, TEMP3H);
					break;

				case CMD_TEMP4 : // Envoie les informations de temp�rature du quatri�me capteur
					dev4_access = get_DS7505_Devices(ADD4_DS7505, listTemp); // R�cup�rer T� capteur n�3					
					convertTemp(listTemp, tempResult);
					TEMP4H = tempResult[0];
					TEMP4L = tempResult[1];
					transmission(CMD_TEMP4,TEMP4L, TEMP4H);
					break;

				case CMD_TEMP5 : // Envoie les informations de temp�rature du cinqui�me capteur
					dev5_access = get_DS7505_Devices(ADD5_DS7505, listTemp); // R�cup�rer T� capteur n�3					
					convertTemp(listTemp, tempResult);
					TEMP5H = tempResult[0];
					TEMP5L = tempResult[1];
					transmission(CMD_TEMP5, TEMP5L, TEMP5H);
					break;

				case CMD_TEMP6 : // Envoie les informations de temp�rature du sixi�me capteur
					dev6_access = get_DS7505_Devices(ADD6_DS7505, listTemp); // R�cup�rer T� capteur n�3					
					convertTemp(listTemp, tempResult);
					TEMP6H = tempResult[0];
					TEMP6L = tempResult[1];
					transmission(CMD_TEMP6, TEMP6L, TEMP6H);
					break;

				case CMD_TEMP7 : // Envoie les informations de temp�rature du septi�me capteur
					dev7_access = get_DS7505_Devices(ADD7_DS7505, listTemp); // R�cup�rer T� capteur n�3					
					convertTemp(listTemp, tempResult);
					TEMP7H = tempResult[0];
					TEMP7L = tempResult[1];
					transmission(CMD_TEMP7, TEMP7L, TEMP7H);
					break;

				case CMD_TEMP8 :  // Envoie les informations de temp�rature du huiti�me capteur
					dev8_access = get_DS7505_Devices(ADD8_DS7505, listTemp); // R�cup�rer T� capteur n�3					
					convertTemp(listTemp, tempResult);
					TEMP8H = tempResult[0];
					TEMP8L = tempResult[1];
					transmission(CMD_TEMP8, TEMP8L, TEMP8H);
					break;
				
				case CMD_PROFONDEUR : // Envoie les informations de pression re�ue par le capteur de pression comme indicatif de la profondeur
					StartADC(0);
					ReadADC(listTemp);
					ADC1L = listTemp[0];
					ADC1H = listTemp[1];
					transmission(CMD_PROFONDEUR, ADC1L, ADC1H);
					break;

				case CMD_ADC2 : // Envoie les informations du deuxi�me convertisseur ADC
					StartADC(1);
					ReadADC(listTemp);
					ADC2L = listTemp[0];
					ADC2H = listTemp[1];
					transmission(CMD_ADC2, ADC2L, ADC2H);
					break;

				case CMD_ADC3 : // Envoie les informations du troisi�me convertisseur ADC
					StartADC(2);
					ReadADC(listTemp);
					ADC3L = listTemp[0];
					ADC3H = listTemp[1];
					transmission(CMD_ADC3, ADC3L, ADC3H);
					break;

				case CMD_ADC4 : // Envoie les informations du quatri�me convertisseur ADC
					StartADC(3);
					ReadADC(listTemp);
					ADC4L = listTemp[0];
					ADC4H = listTemp[1];
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
			}

			for(decalage=0;decalage<=4;decalage++) // D�cale les demandes pour supprimer la premi�re et passer au traitement de la demande suivante
			{
				data[decalage]=data[decalage+1];	
			}
			data[4] = 0x00 ;
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
	if(fonctionnement_RX==0) // mode d'envoi
	{
		//Si un caract�re est re�u, on set le flag_usart � TRUE pour quitter la boucle de getchar_usart
		flag_usart = TRUE;
	}
	else if (fonctionnement_RX==1) // mode de r�ception
	{
		get_data_3964r(data);	
		data[4]=0x00; // Force le dernier bit des demandes � 0.  Au maximum 4 demandes qui n'ont pas �t� trait�e peuvent �tre enregistr�e.		
	}
}

/*************************/
/******* Fonctions *******/
/*************************/

/***** Initialisation *****/
void init()							
{
	unsigned char i ;
	cli();							// D�sactiver toutes les interruptions

	sDDR(DDRD,1);					// mettre port TX en sortie
	sbiBF(PORTD,0); 				// mettre pull-up sur RX

	for(i=0;i<=4;i++)				// Initialiser les demandes � 0 qui signifie qu'il n'y a pas de demande de la part de la FoxBoard
	{
		data[i]=0x00;
	}

    i2c_init();              		// Initialisation interface I2C

	init_3964r();					// Initialisation de la communication en protocole 3964 avec la FoxBoard
	ENABLE_RX_INT_USART;			// Autoriser les interruption s�rie RX
	fonctionnement_RX = 1;			// mode de r�ception

	init_watchdog();				// Initilise les reset

	InitADC();						// Initialise les ADC

	sei();							// Activer toutes les interruptions	
}


/***** Transmission vers FoxBoard *****/
void transmission(char commande, char data_low, char data_high)
{
	data_to_transmit[0]=commande;
	data_to_transmit[1]=data_high;								// Charge le byte de poid faible dans le premier byte			
	data_to_transmit[2]=data_low;								// Charge le byte de poid fort dans le deuxi�me byte

	DISABLE_RX_INT_USART;
	fonctionnement_RX = 0 ; 									// Indique que l'on va se mettre en mode d'envoi de donn� vers la Fox
	TRANSMIT_STATUT = send_data_3964r(data_to_transmit,3);			// Envoie les deux bytes en protocole 3964	
	fonctionnement_RX = 1 ;									// Indique que l'on se remet en mode de r�ception de donn�e venant de la Fox
	
	ENABLE_RX_INT_USART;
}
