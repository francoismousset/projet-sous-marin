/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : Projet sous-marin
				   Test de communication I2C et capteurs
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 02/03/2012
* Last revised	 : 08/03/2012
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : 3x DS1621 on I2C bus
*
**********************************************************************/

/***** Liste des includes *****/
#include <avr/io.h>
#include <avr/interrupt.h>
#include "uart.h"
#include "main.h"
#include "I2Cmaster.h"
#include "DS1621.h"

/***** Variables globales *****/
unsigned char bufUSART_RX = NULL;						// Buffer contenant l'octet reçu sur RX
unsigned char dev1_access, dev2_access, dev3_access; 	// Contient l'état de connexion des capteur
char listTemp [6];										// Tableau des températures

/*****************************************************************/
/*********************** Programme principal *********************/
/*****************************************************************/

int main(void)
{
	/***** Variables locales *****/
	
	init();									// Initialisations globales
	
	dev1_access = initDS1631(ADD1_DS1621);	// Initialiser le capteur de T° n°1
	dev2_access = initDS1631(ADD2_DS1621);	// Initialiser le capteur de T° n°1
	dev3_access = initDS1631(ADD3_DS1621);	// Initialiser le capteur de T° n°1

	/* boucle infinie */
	for(;;)
	{	
		/* Si le capteur de T° n°1 est connecté au bus I2C */
		if(!dev1_access)
		{
			get_DS1631_Devices(ADD1_DS1621, listTemp); // Récupérer T° capteur n°1
		}
		/* Si le capteur de T° n°2 est connecté au bus I2C */
		if(!dev2_access)
		{
			get_DS1631_Devices(ADD2_DS1621, listTemp); // Récupérer T° capteur n°2
		}
		/* Si le capteur de T° n°3 est connecté au bus I2C */
		if(!dev3_access)
		{
			get_DS1631_Devices(ADD3_DS1621, listTemp); // Récupérer T° capteur n°3
		} 		
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

	/* Si demande d'envoyer la T° du capteur n°1 */
	if(bufUSART_RX == 'a')
	{
		USART_TX_String(NEW_PAGE"Demande T capteur 1"CARRIAGE_RETURN"Reponse : ");
										/* Afficher :
											 "Demande T capteur 1
											  Reponse : "
										*/
		USART_Transmit(listTemp[0]);	// Envoyer les bits de poids fort
		USART_Transmit(listTemp[1]);	// Envoyer les bits de poids faible
	}
	/* Si demande d'envoyer la T° du capteur n°2 */
	else if (bufUSART_RX == 'b')
	{
		USART_TX_String(NEW_PAGE"Demande T capteur 2"CARRIAGE_RETURN"Reponse : ");
										/* Afficher :
											 "Demande T capteur 2
											  Reponse : "
										*/
		USART_Transmit(listTemp[2]);	// Envoyer les bits de poids fort
		USART_Transmit(listTemp[3]);	// Envoyer les bits de poids faible
	}
	/* Si demande d'envoyer la T° du capteur n°3 */
	else if (bufUSART_RX == 'c')
	{
		USART_TX_String(NEW_PAGE"Demande T capteur 3"CARRIAGE_RETURN"Reponse : ");
										/* Afficher :
											 "Demande T capteur 3
											  Reponse : "
										*/
		USART_Transmit(listTemp[4]);	// Envoyer les bits de poids fort
		USART_Transmit(listTemp[5]);	// Envoyer les bits de poids faible
	}
	else
	{
		asm("nop"); 	// Ne rien faire en cas d'erreur
	}
	bufUSART_RX = NULL; // Vider la mémoire tampon RX
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
