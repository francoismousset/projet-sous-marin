/****************************************************************
 *																*
 *	FileName :		timer1.h									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _TIMER1_H_
#define _TIMER1_H_

#include <avr/io.h>
#include <avr/interrupt.h>

#define TRUE 0
#define FALSE 1

void init_timer1(void);
void start_timer1(unsigned int);
void stop_timer1(void);

volatile unsigned char flag_timer1;

#endif /* _TIMER1_H */
