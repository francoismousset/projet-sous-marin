/****************************************************************
 *																*
 *	FileName :		external_interrupt.h						*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		18/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _EXTERNAL_INTERRUPT_H_
#define _EXTERNAL_INTERRUPT_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include "motor_driver.h"

void init_external_interrupt(void);
unsigned int get_position1(void);
unsigned int get_position2(void);

#endif /* _EXTERNAL_INTERRUPT_H_ */
