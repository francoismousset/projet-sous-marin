/* ADC.c*/

/**********************************************************************
*
* File name		 : ADC.c
* Title 		 : Gestion des ADC
* Author 		 : Beno�t Echevin
* Created		 : 07/05/2012
* Last revised	 : 10/05/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/


#include "ADC.h"
#include <avr/io.h>

void InitADC(void)
{
	// initialistion Hardware pour ADC0 ADC1 ADC2 ADC3
	//cbiBF(DDRC,0);
	//cbiBF(DDRC,1);
	//cbiBF(DDRC,2);
	//cbiBF(DDRC,3);
	// Selection du voltage de r�f�rence sur AREF, les donn�es seront ajust�es � gauche
	ADMUX |= (0<<REFS1)|(0<<REFS0)|(1<<ADLAR);
	//	Bit 	15		14		13		12		11		10 		9 		8
	//	(0x79) 	ADC9 	ADC8 	ADC7 	ADC6 	ADC5 	ADC4 	ADC3 	ADC2 	ADCH
	//	(0x78) 	ADC1 	ADC0 	� 		� 		�		�		�		�		ADCL
	// Activer l' ADC
	ADCSRA |= (1<<ADEN)|(1<<ADPS2)|(1<<ADPS1)|(1<<ADPS0);
	// Activer conversion
	// ADCSRA |= (1<<ADSC);
	// Digital Input Disable (mise � 1 pour diminuer la puissance et favoriser entr�e analogique)
	//DIDR0 |= (1<<ADC3D)|(1<<ADC2D)|(1<<ADC1D)|(1<<ADC0D);
	
	
}

void ClearFlagADC(void)
{
	// ADC Interrupt Flag => mis � 1 quand conversation termin�e ; forcer � un pour mettre � 0
	ADCSRA |= (1<<ADIF);
	// Clear pour �viter conversion
	ADCSRA &= ~(1<<ADSC);
}

void ReadADC(char EnregistrementADC[])
{
	// Attendre que la conversion soit finie
	while(((ADCSRA)&(1<<ADIF))==0);
	// Enregistre les donn�es
	EnregistrementADC[0] = ADCL;
	EnregistrementADC[1] = ADCH;
}

void StartADC(unsigned char multiplexeur)
{
	// Selection le canal ADC
	if(multiplexeur==0)
	{
		DIDR0 |= (0<<ADC3D)|(0<<ADC2D)|(0<<ADC1D)|(1<<ADC0D);
		ADMUX = CHANNEL0;
	}
	else if(multiplexeur==1)
	{
		DIDR0 |= (0<<ADC3D)|(0<<ADC2D)|(1<<ADC1D)|(0<<ADC0D);
		ADMUX = CHANNEL1;
	}
	else if(multiplexeur==2)
	{
		DIDR0 |= (0<<ADC3D)|(1<<ADC2D)|(0<<ADC1D)|(0<<ADC0D);
		ADMUX = CHANNEL2;
	}
	else if(multiplexeur==3)
	{
		DIDR0 |= (1<<ADC3D)|(0<<ADC2D)|(0<<ADC1D)|(0<<ADC0D);
		ADMUX = CHANNEL3; 
	}
	else asm("nop");	

	// Commence la conversion
	ADCSRA |= (1<<ADSC);
	// desactiver le power reduction register pour adc pour permettre conversion un par un
	PRR &= ~(1<<PRADC);
}
