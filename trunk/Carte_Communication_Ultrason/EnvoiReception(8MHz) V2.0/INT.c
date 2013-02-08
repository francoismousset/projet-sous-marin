/* INT.c */

/**********************************************************************
*
* File name		 : INT.c
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin & Philippe Wauthy
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

// INCLUDE
#include <avr/io.h>
#include "main.h"
#include "INT.h"

// FUNCTIONS

/* Initialisation PCINT */
void init_pcint(void)
{
	// Active les interruptions externe pcint1 donc sur PCINT0..23
	PCICR |= (1<<PCIE1);
	// Active les interruptiosn sur PINC0 => PCINT8 ; PINC1 => PCINT9
	PCMSK1 |= (1<<PCINT8);//|(1<<PCINT9);
}

void INT_BP(void)           //initialise le périphérique de int0 -> voir datasheet
{

     //EICRA = 0b00001010;     //0000: -/10: front descendant sur INT1/10: front descendant sur INT0
	 //EIMSK = 0b00000011;     //000000: -/11: interruptions sur INT0 et INT1
	sbiBF (PCICR, PCIE2);
	PCMSK2 = 0b01111000;
}

