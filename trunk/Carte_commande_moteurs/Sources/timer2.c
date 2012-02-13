/****************************************************************
 *																*
 *	FileName :		timer2.c									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		27/02/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Complier : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "timer2.h"

void init_timer2(void)
{
	OCR2A = 150;
	TIMSK2 |= (1<<OCIE2A);	//Activation de l'interruption
	TCCR2A |= (1<<WGM21);	//CTC
	TCCR2B |= (1<<CS20);	//Run - No prescaler
}

void enable_int_timer2(void)
{
	TIMSK2 |= (1<<OCIE2A);
}

void disable_int_timer2(void)
{
	TIMSK2 &= 0b11111101;
}

ISR(TIMER2_COMPA_vect)
{
//	usart_tx();
}
