/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : I2C Bus Tester
				   Projet sous-marin
				   Programme carte de test bus I2C & capteurs
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 02/03/2012
* Last revised	 : 05/02/2013
* Version		 : 1.2.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : Capteurs I2C (DS7505, SHT21)
*
**********************************************************************/

/***** Liste des includes *****/
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "uart.h"
#include "car.h"
#include "main.h"
#include "I2Cmaster.h"
#include "DS7505.h"
//#include "DS1621.h"
#include "SHT21.h"
#include "gestion_H.h"
#include "gestion_T.h"

/***** Variables globales *****/
unsigned char bufUSART_RX = NULL;		// Buffer contenant l'octet reçu sur RX
unsigned char dev1_DS7505_access, dev2_DS7505_access, dev3_DS7505_access, dev4_DS7505_access;
unsigned char dev5_DS7505_access, dev6_DS7505_access, dev7_DS7505_access, dev8_DS7505_access;
unsigned char dev1_SHT21_access;
unsigned char dev1_DS1621_access; 		// Contient l'état de connexion des capteur
unsigned char dev_num = 0;				// Numéro de capteur de T°
char listTemp [2], listHum[3], tempResult[2], tempStr[5], humResult, humStr[2];// Tableau des températures



/*****************************************************************/
/*********************** Programme principal *********************/
/*****************************************************************/

int main(void)
{
	/***** Variables locales *****/
	//
	init();									// Initialisations globales
	USART_TX_Msg(MSG_WELCOME);
	USART_TX_Msg(MSG_YEAR);
	USART_TX_CRNL();				// Nouvelle ligne, retour chariot

	/* Capteur T° n°1 */
	dev1_DS7505_access = initDS7505(ADD1_DS7505);	// Initialiser le capteur de T° n°1
	if(dev1_DS7505_access)
	{
		USART_TX_Msg("DS7505 n1"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n1"CONN_MSG);
	}

	/* Capteur T° n°2 */
	dev2_DS7505_access = initDS7505(ADD2_DS7505);	// Initialiser le capteur de T° n°2
	if(dev2_DS7505_access)
	{
		USART_TX_Msg("DS7505 n2"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n2"CONN_MSG);
	}

	/* Capteur T° n°3 */
	dev3_DS7505_access = initDS7505(ADD3_DS7505);	// Initialiser le capteur de T° n°3
	if(dev3_DS7505_access)
	{
		USART_TX_Msg("DS7505 n3"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n3"CONN_MSG);
	}

	/* Capteur T° n°4 */
	dev4_DS7505_access = initDS7505(ADD4_DS7505);	// Initialiser le capteur de T° n°4
	if(dev4_DS7505_access)
	{
		USART_TX_Msg("DS7505 n4"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n4"CONN_MSG);
	}

	/* Capteur T° n°5 */
	dev5_DS7505_access = initDS7505(ADD5_DS7505);	// Initialiser le capteur de T° n°5
	if(dev5_DS7505_access)
	{
		USART_TX_Msg("DS7505 n5"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n5"CONN_MSG);
	}

	/* Capteur T° n°6 */
	dev6_DS7505_access = initDS7505(ADD6_DS7505);	// Initialiser le capteur de T° n°6
	if(dev6_DS7505_access)
	{
		USART_TX_Msg("DS7505 n6"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n6"CONN_MSG);
	}

	/* Capteur T° n°7 */
	dev7_DS7505_access = initDS7505(ADD7_DS7505);	// Initialiser le capteur de T° n°7
	if(dev7_DS7505_access)
	{
		USART_TX_Msg("DS7505 n7"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n7"CONN_MSG);
	}

	/* Capteur T° n°8 */
	dev8_DS7505_access = initDS7505(ADD8_DS7505);	// Initialiser le capteur de T° n°8
	if(dev8_DS7505_access)
	{
		USART_TX_Msg("DS7505 n8"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS7505 n8"CONN_MSG);
	}

	/* Capteur %H n°1 */
	dev1_SHT21_access = initSHT21(ADD1_SHT21);
	if(dev1_SHT21_access)
	{
		USART_TX_Msg("SHT21"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("SHT21"CONN_MSG);
	}

	/*
	dev1_DS1621_access = initDS1621(ADD1_DS1621);
	if(dev1_DS1621_access)
	{
		USART_TX_Msg("DS1621 n1"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS1621 n1"CONN_MSG);
	} */


	/* boucle infinie */
	for(;;)
	{
		sbiBF(PORTB,0);
		_delay_ms(200);
		cbiBF(PORTB,0);
		_delay_ms(200);
	}
	return 0;	
}

/*****************************/
/******* Interruptions *******/
/*****************************/				

//*********** Interruption sur l'entrée de l'USART (RX) ************//
ISR(USART_RX_vect)
{
	bufUSART_RX = UDR0;		// Mettre dans le buffer l'octet reçu sur RX

	switch (bufUSART_RX)
	{
		/* Si demande d'envoyer la T° du capteur n°1 */
		case '1':	
			dev1_DS7505_access = get_DS7505_Devices(ADD1_DS7505, listTemp); // Récupérer T° capteur n°1
			//dev1_DS1621_access = get_DS1621_Devices(ADD1_DS1621, listTemp);	
			dev_num = 1;		
			break;
		/* Si demande d'envoyer la T° du capteur n°2 */
		case '2' :
			dev2_DS7505_access = get_DS7505_Devices(ADD2_DS7505, listTemp); // Récupérer T° capteur n°2
			dev_num = 2;
			break;
		/* Si demande d'envoyer la T° du capteur n°3 */
		case '3' :
			dev3_DS7505_access = get_DS7505_Devices(ADD3_DS7505, listTemp); // Récupérer T° capteur n°3
			dev_num = 3;
			break;
		/* Si demande d'envoyer la T° du capteur n°4 */
		case '4' :
			dev4_DS7505_access = get_DS7505_Devices(ADD4_DS7505, listTemp); // Récupérer T° capteur n°4
			dev_num = 4;
			break;
		/* Si demande d'envoyer la T° du capteur n°5 */
		case '5' :
			dev5_DS7505_access = get_DS7505_Devices(ADD5_DS7505, listTemp); // Récupérer T° capteur n°5
			dev_num = 5;
			break;
		/* Si demande d'envoyer la T° du capteur n°6 */
		case '6' :
			dev6_DS7505_access = get_DS7505_Devices(ADD6_DS7505, listTemp); // Récupérer T° capteur n°6
			dev_num = 6;
			break;
		/* Si demande d'envoyer la T° du capteur n°7 */
		case '7' :
			dev7_DS7505_access = get_DS7505_Devices(ADD7_DS7505, listTemp); // Récupérer T° capteur n°7
			dev_num = 7;
			break;
		/* Si demande d'envoyer la T° du capteur n°8 */
		case '8' :
			dev8_DS7505_access = get_DS7505_Devices(ADD8_DS7505, listTemp); // Récupérer T° capteur n°8
			dev_num = 8;
			break;
		case 'h' :
			dev1_SHT21_access = get_SHT21_Devices(ADD1_SHT21, listHum);
			break;
	}

	/* Convertion capteurs T° */
	if((bufUSART_RX >= 49) & (bufUSART_RX <= 56))
	{
		convertTemp(listTemp, tempResult);
		stringTemp(tempResult, tempStr);
	
		USART_Transmit('T');
		USART_Transmit(DEG_CAR);
		USART_TX_String("C Sensor ");
		USART_Transmit(dev_num+48);
		USART_TX_String(" : ");
		USART_Transmit(tempStr[0]);
		USART_Transmit(tempStr[1]);	
		USART_Transmit(tempStr[2]);	
		USART_Transmit(DOT_CAR);
		USART_Transmit(tempStr[3]);	
		USART_Transmit(tempStr[4]);
		USART_TX_CRNL();				// Nouvelle ligne, retour chariot

		listTemp[0] = 0;		// Reset température mesurée
		listTemp[1] = 0;
	}

	/* Convertion capteurs %H */
	else if(bufUSART_RX >= 'h')
	{
		humResult = convertHum(listHum);
		stringHum(humResult, humStr);

		USART_Transmit(PERCENT_CAR);
		USART_Transmit('H');
		USART_TX_String(" Sensor : ");
		USART_Transmit(humStr[0]);
		USART_Transmit(humStr[1]);	
		USART_TX_CRNL();				// Nouvelle ligne, retour chariot

		listHum[0] = 0;		// Reset Humidité mesurée
		listHum[1] = 0;
		listHum[2] = 0;		
	}
	else
	{
		asm("nop"); 	// Ne rien faire en cas d'erreur
	}
}

/*************************/
/******* Fonctions *******/
/*************************/

/***** Initialisation *****/
void init()							
{
	cli();							// Désactiver toutes les interruptions
    
	sDDR(DDRB,0); 					// PORTB.0 en sortie
	sDDR(DDRB,1); 					// PORTB.1 en sortie
	cbiBF(PORTB,0);					// Mettre à zéro le portB.0

    i2c_init();              		// Initialisation interface I2C

	USART_Init(MYUBRR);				// Initialisation de la communication série
	Enable_Interrupt_On_RX();		// Autoriser les interruption série RX

	sei();							// Activer toutes les interruptions	
}
