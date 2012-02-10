/****************************************************************
 *																*
 *	FileName :		ballast_position.h							*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		06/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _BALLAST_POSITION_H_
#define _BALLAST_POSITION_H_

#include "main.h"

#ifdef U_BOAT
#include "adc.h"
#else
#include "external_interrupt.h"
#endif

#include <avr/io.h>
#include <avr/interrupt.h>

void init_ballast_position(void);
unsigned int get_ballast_position1(void);
unsigned int get_ballast_position2(void);

#endif /* _BALLAST_POSITION_H_ */
