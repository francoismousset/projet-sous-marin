/* TIMER.c */

/**********************************************************************
*
* File name		 : TIMER.c
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin & Philippe Wauthy
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/


//INCLUDE
#include "TIMER.h"
#include "main.h"

// FUNCTIONS

// Arrete le timer et remet le compteur à 0
void TIMER0_STOP(void)
{
	TCCR0B = 0x00;
	TCNT0 = 0x00;
}

// Met le compteur à 0 et lance le timer
void TIMER0_START(void)
{
	TCNT0 = 0x00;
	TCCR0B = (0<<CS02)|(1<<CS01)|(0<<CS00); // prescale de 8. => interruption toutes les 105*8*0.125=105µs
}

// Initialise le timer
void TIMER0_INIT(void)
{
	// mode CTC
	TCCR0A = (1<<WGM01)|(0<<WGM00);
	//TCCR0B = (0<<WGM02);
	// Activer les interruptions
	TIMSK0 = (1<<OCIE0A);
	// Déclencher interruption à la valeur indiquée.
	OCR0A = 104; // 105-1
}


//fout = fclk/(2*N*(1 + OCR1A)) avec N = préscalaire et Ocr = comparateur

void TIMER1_INIT(void)   //initialise le périphérique du timer1 -> voir datasheet
{


    TCNT1  = 0b00000000;     //début compteur (commence à 0)
    TCCR1A = 0b01000000;     //00 pour dire rien sur OC1A/00: rien sur OCB/00: -/00: wgm11-10-> mode CTC     
    TCCR1B = 0b00001001;     //00:pas utilisé/0: -/01: wgm13-12 ->mode CTC/001: préscalaire de 1

	//mode CTC avec toggle de OC1A (se réalise automatiquement)
	   
    TIMSK1 = 0b00000000;     //00: -/0: pas la capture/00: -/010: interruption sur OCR1A   
    OCR1A  = 249 ;           //on commence à 40kHz -> OCR1A (voir formule) = 249          

}

// Init timer2
void TIMER2_INIT(void)
{
		// mode CTC
	TCCR2A = (1<<WGM21)|(0<<WGM20);
	// Activer les interruptions
	TIMSK2 = (1<<OCIE2A);
	// Déclencher interruption à la valeur indiquée.
	OCR2A = 104; // 105-1
}

// Arrete le timer et remet le compteur à 0
void TIMER2_STOP(void)
{
	TCCR2B = 0x00;
	TCNT2 = 0x00;
}

// Met le compteur à 0 et lance le timer
void TIMER2_START(void)
{
	TCNT2 = 0x00;
	TCCR2B = (0<<CS02)|(1<<CS01)|(0<<CS00); // prescale de 8. => interruption toutes les 105*8*0.125=105µs
}
