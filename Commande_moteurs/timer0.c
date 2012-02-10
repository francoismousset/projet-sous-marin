/****************************************************************
 *																*
 *	FileName :		timer0.c									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		18/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "timer0.h"

//Génère le PWM sur les sorties OC0A ET OC0B
void init_pwm(void)
{
	//Config Timer 0
	DDRD |= (1<<DDD5) | (1<<DDD6);	//OC0A OC0B
	TCCR0A |= /*(1<<COM0A0) |*/ (1<<COM0A1) /*| (1<<COM0B0)*/ | (1<<COM0B1) | (1<<WGM01) | (1<<WGM00);  //Fast-PWM mode 3
	TCCR0B |= (1<<CS00);   //Run - No-prescaler
}
