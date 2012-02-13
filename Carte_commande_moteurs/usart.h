/****************************************************************
 *																*
 *	FileName :		usart.h										*
 *	Rev 	 : 		0.2											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _USART_H_
#define _USART_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include <string.h>
#include "timer1.h"

//Sélection du baudrate (9600bps)
#define BAUD	9600
#define MYUBRR	F_CPU/8/BAUD-1

#define TRUE	0
#define FALSE	1

//Active ou désactive l'interruption usart
#define ENABLE_RX_INT_USART		UCSR0B |= (1<<RXCIE0)
#define DISABLE_RX_INT_USART	UCSR0B &= 0b01111111

//Fonctions public
void init_usart(unsigned int);
void putchar_usart(char);
char getchar_usart(void);

void puts_usart(char[]);
void gets_usart(char[], unsigned char);

//Variable globale public
volatile unsigned char flag_usart;

#endif /* _USART_H_ */
