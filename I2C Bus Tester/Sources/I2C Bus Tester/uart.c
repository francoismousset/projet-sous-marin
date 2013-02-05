/* usart.c */

/**********************************************************************
*
* File name		 : uart.c
* Title 		 : Communication série avec buffer d'envoi
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 8/11/2011
* Last revised	 : 02/02/2013
* Version		 : 1.2
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

//#include <stdlib.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include "uart.h"
#include "main.h"
#include "car.h"

/*********************************************************************/
// FUNCTION: USART_Init( unsigned int )
// PURPOSE: Initialisation du port série
void USART_Init( unsigned int ubrr)
{
	/*Set baud rate */
	//UBRR0H = (unsigned char)(ubrr>>8);
	//UBRR0L = (unsigned char)ubrr;
UBRR0L = 53;
	/*Enable receiver and transmitter */
	UCSR0B |= (1<<TXEN0)|(1<<RXEN0);

	/* Set frame format:  1 bit stop, 8 bits, no parity, asynchronous */
	UCSR0C |= (3<<UCSZ00);			
}

/*********************************************************************/
// FUNCTION: USART_Transmit( unsigned char )
// PURPOSE: Envoyer un caractère
void USART_Transmit( unsigned char data )
{
	/* Wait for empty transmit buffer to be empty by checking the UDREn Flag */
	while ( !( UCSR0A & (1<<UDRE0)) );  
								
	/* Put data into buffer, sends the data */
	UDR0 = data;
}

/*********************************************************************/
// FUNCTION: USART_Receive( void )
// PURPOSE: Reçevoir un caractère
unsigned char USART_Receive( void )
{
	/* Wait for data to be received */
	while ( !(UCSR0A & (1<<RXC0)) );
	
	/* Get and return received data from buffer */
	return UDR0;
}

/*********************************************************************/
// FUNCTION: USART_TX_String(char)
// PURPOSE: Envoyer une chaine de caractère
void USART_TX_String(char *String)
{
	char Continue = TRUE;
	while (Continue)
	{
		if (*String == 0) Continue = FALSE;
		USART_Transmit(*String++);
	}
}

/*********************************************************************/
// FUNCTION: USART_TX_CRNL()
// PURPOSE: Envoyer Retour à la ligne (CARRIAGE_RETURN) et
//			nouvelle page (NEW_PAGE)
void USART_TX_CRNL()
{
	USART_Transmit(CARRIAGE_RETURN);
	USART_Transmit(NEW_LINE);
}

/*********************************************************************/
// FUNCTION: USART_TX_Msg(char *String)
// PURPOSE: Envoyer une chaine de caractère avec retour à la ligne
//			(CARRIAGE_RETURN) et nouvelle page (NEW_PAGE)

void USART_TX_Msg(char *String)
{
	USART_TX_String(String);
	USART_TX_CRNL();
}


/*********************************************************************/
// FUNCTION: Enable_Interrupt_On_RX()
// PURPOSE: Activer l'interruption sur RX
void Enable_Interrupt_On_RX()
{
	sbiBF(UCSR0B,RXCIE0); // Autotriser les interruption sur Rx lorsqu'une donnée est reçue
}

/*********************************************************************/
// FUNCTION: Disable_Interrupt_On_RX()
// PURPOSE: Désactiver l'interruption sur RX
void Disable_Interrupt_On_RX()
{
	cbiBF(UCSR0B,RXCIE0); // Désactiver les interruption sur Rx lorsqu'une donnée est reçue
}
