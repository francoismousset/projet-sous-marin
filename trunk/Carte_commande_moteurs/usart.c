/****************************************************************
 *																*
 *	FileName :		usart.c										*
 *	Rev 	 : 		0.2											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "usart.h"

//Initialisation de l'usart
void init_usart(unsigned int ubrr)
{
	/*Set baud rate */
	UBRR0H = (unsigned char)(ubrr>>8);
	UBRR0L = (unsigned char)ubrr;
	/*Double speed*/
	UCSR0A = (1<<U2X0);
	/*Enable receiver and transmitter */
	UCSR0B |= (1<<TXEN0) | (1<<RXEN0);
	/* Set frame format: 8data, 1stop bit */
	UCSR0C = (3<<UCSZ00);

	flag_usart = FALSE;
}

//Permet l'envoi d'un caractère
void putchar_usart(char c)
{
	/* Wait for empty transmit buffer */
	while (!( UCSR0A & (1<<UDRE0)));
	/* Put data into buffer, sends the data */
	UDR0 = c;
}

//Permet la reception d'un caractère
char getchar_usart(void)
{
	/* Wait for data to be received */
	//Si le flag_timer1 est différent de FALSE, on sort de la boucle
	while ((!(UCSR0A & (1<<RXC0))) && (flag_timer1 == FALSE));
	/* Get and return received data from buffer */
	return UDR0;
}

//Permet d'écrire une chaine de caractère sur l'usart
void puts_usart(char string[])
{
	unsigned char i;

	for(i=0; i<strlen(string); i++)
		putchar_usart(string[i]);
}

//Permet de recevoir une chaine de caractère sur l'usart
void gets_usart(char string[], unsigned char len)
{
	unsigned char i;
	
	for(i=0; i<len; i++)
		string[i] = getchar_usart();
}

//Interruption usart en reception
ISR(USART_RX_vect)
{
	//Si un caractère est reçu, on set le flag_usart à TRUE pour quitter la boucle de getchar_usart
	flag_usart = TRUE;
}
