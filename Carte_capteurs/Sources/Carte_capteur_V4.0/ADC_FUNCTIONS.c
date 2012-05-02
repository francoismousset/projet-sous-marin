#include "ADC_FUNCTIONS.h"
#include <avr/io.h>


void ADC_Init(void)
{
	ADMUX |= (1<<REFS0);									//AVCC comme reference, ADC0 par défault
	ADCSRA |= (1<<ADEN)|(1<<ADPS2)|(1<<ADPS0);				//ADC ENable, ADC interrupt enable, perscaler 32
															//ADCSRB = 0  Free running mode
	DIDR0 |= (1<<ADC5D)|(1<<ADC4D);							//Disable PIN ADC4 et 5
}

void ADC_Start(void)
{
	ADCSRA |= (1<<ADSC);									//Start conversion
}

void ADC_Stop(void)
{
	ADCSRA &= ~(1<<ADSC);									//Stop conversion
}

void ADC_Mux(char channel)
{
	switch (channel)
	{
		case 0:
			ADMUX = 0b01100000;
			break;
		case 1:
			ADMUX = 0b01100001;
			break;
		case 2:
			ADMUX = 0b01100010;
			break;
		case 3:
			ADMUX = 0b01100011;
			break;
		default:
			ADMUX = 0b01100000;
			break;
	}
}


