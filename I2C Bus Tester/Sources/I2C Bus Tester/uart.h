/* uart.h */

/**********************************************************************
*
* File name		 : uart.c
* Title 		 : Communication s�rie avec buffer d'envoi
* Author 		 : Micha�l Brogniaux - Copyright (C) 2011
* Created		 : 8/11/2011
* Last revised	 : 02/02/2013
* Version		 : 1.2
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#define FOSC 8000000				// Clock Speed
#define BAUD 9600					// Baude rate
#define MYUBRR FOSC/16/BAUD-1

/*********************************************************************/
// FUNCTION: USART_Init( unsigned int )
// PURPOSE: Initialisation du port s�rie
void USART_Init( unsigned int ubrr);

/*********************************************************************/
// FUNCTION: USART_Transmit( unsigned char )
// PURPOSE: Envoyer un caract�re
void USART_Transmit( unsigned char data );

/*********************************************************************/
// FUNCTION: USART_Receive( void )
// PURPOSE: Re�evoir un caract�re
unsigned char USART_Receive( void );

/*********************************************************************/
// FUNCTION: USART_TX_String(char)
// PURPOSE: Envoyer une chaine de caract�re
void USART_TX_String(char *String);

/*********************************************************************/
// FUNCTION: USART_TX_CRNL()
// PURPOSE: Envoyer Retour � la ligne (CARRIAGE_RETURN) et
//			nouvelle page (NEW_PAGE)
void USART_TX_CRNL();

/*********************************************************************/
// FUNCTION: USART_TX_Msg(char *String)
// PURPOSE: Envoyer une chaine de caract�re avec retour � la ligne
//			(CARRIAGE_RETURN) et nouvelle page (NEW_PAGE)
void USART_TX_Msg(char *String);

/*********************************************************************/
// FUNCTION: Enable_Interrupt_On_RX()
// PURPOSE: Activer l'interruption sur RX
void Enable_Interrupt_On_RX();

/*********************************************************************/
// FUNCTION: Disable_Interrupt_On_RX()
// PURPOSE: D�sactiver l'interruption sur RX
void Disable_Interrupt_On_RX();
