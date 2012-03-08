/* uart.h */

/**********************************************************************
*
* File name		 : uart.c
* Title 		 : Communication série avec buffer d'envoi
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 8/11/2011
* Last revised	 : 07/03/2012
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#define FOSC 8000000				// Clock Speed
#define BAUD 9600					// Baude rate
#define MYUBRR FOSC/16/BAUD-1

#define ASCII_CARAC_DEG 	167 	// Symbole "degre" : °
#define CARAC_NEG			"-"		// Symbole "moins" : -
#define CARAC_C				"C"		// Lettre : C
#define CARAC_VIDE 			" "		// Espace vide
#define NEW_PAGE		 	"\f"	// Nouvelle page
#define CARRIAGE_RETURN 	"\r"	// Retour chariot
#define	BELL				"\a"	// Sonnerie

/*********************************************************************/
// FUNCTION: USART_Init( unsigned int )
// PURPOSE: Initialisation du port série
void USART_Init( unsigned int ubrr);

/*********************************************************************/
// FUNCTION: USART_Transmit( unsigned char )
// PURPOSE: Envoyer un caractère
void USART_Transmit( unsigned char data );

/*********************************************************************/
// FUNCTION: USART_Receive( void )
// PURPOSE: Reçevoir un caractère
unsigned char USART_Receive( void );

/*********************************************************************/
// FUNCTION: USART_TX_String(char)
// PURPOSE: Envoyer une chaine de caractère
void USART_TX_String(char *String);

/*********************************************************************/
// FUNCTION: Enable_Interrupt_On_RX()
// PURPOSE: Activer l'interruption sur RX
void Enable_Interrupt_On_RX();

/*********************************************************************/
// FUNCTION: Disable_Interrupt_On_RX()
// PURPOSE: Désactiver l'interruption sur RX
void Disable_Interrupt_On_RX();
