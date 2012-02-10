/****************************************************************
 *																*
 *	FileName :		adc.c										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		25/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "adc.h"

unsigned int conv_ADC(void);

void init_adc(void)
{
	ADMUX |= (1<<REFS0);// | (1<<ADLAR);	//Ajustement à gauche
	ADCSRA |= (1<<ADEN) | (1<<ADPS2) | (1<<ADPS1); //Activation ADC et prescaler
}

unsigned int conv_ADC(void)
{
	ADCSRA |= (1<<ADSC);		 //Start Converstion
	while(!(ADCSRA & (1<<ADIF)));//Attend fin de convertion
	ADCSRA |= (0<<ADIF);		 //Rearme l'ADC

	//return ADCH;
	return ADCL + (ADCH<<8);
}

unsigned int get_value_ADC0(void)
{
	ADMUX &= 0b11111110;
	return conv_ADC();
}

unsigned int get_value_ADC1(void)
{
	ADMUX |= (1<<MUX0);
	return conv_ADC();
}
