/****************************************************************
 *																*
 *	FileName :		timer1.c									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "timer1.h"

void init_timer1(void)
{
	TCCR1B |= (1<<WGM12);	//CTC
	TIMSK1 |= (1<<OCIE1A);	//Enable OCIE1A

	flag_timer1 = FALSE;
}

//Prescaler 8 => 65536ms MAX
void start_timer1(unsigned int time)
{
	cli();
	OCR1A = time;
	sei();

	TCCR1B |= (1<<CS11);  //start - Prescaler 8
	//TCCR1B |= (1<<CS10) | (1<<CS12);  //start - Prescaler 1024
}

void stop_timer1(void)
{
	TCCR1B &= 0b11111101;
	//TCCR1B &= 0b11111010;

	//Reset timer
	//Obligation d'arreter les interruptions car le timer est un 16bits => 2 instructions (voir datasheet)
	cli();
	TCNT1 = 0;
	sei();
}

ISR(TIMER1_COMPA_vect)
{
	flag_timer1 = TRUE;	//Force à quitter la boucle de getchar_usart();
}
