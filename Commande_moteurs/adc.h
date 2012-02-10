/****************************************************************
 *																*
 *	FileName :		adc.h										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		25/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _ADC_H_
#define _ADC_H_

#include <avr/io.h>

void init_adc(void);
unsigned int get_value_ADC0(void);
unsigned int get_value_ADC1(void);

#endif /* _ADC_H_ */
