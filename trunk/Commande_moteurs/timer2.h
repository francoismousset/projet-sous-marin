/****************************************************************
 *																*
 *	FileName :		timer2.h									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		27/02/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Complier : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _TIMER2_H_
#define _TIMER2_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include "usart.h"

void init_timer2(void);
void enable_int_timer2(void);
void disable_int_timer2(void);


#endif /* _TIMER2_H */
