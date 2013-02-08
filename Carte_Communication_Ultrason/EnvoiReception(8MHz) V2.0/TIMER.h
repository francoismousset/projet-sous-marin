/* TIMER.h */

/**********************************************************************
*
* File name		 : TIMER.h
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

#ifndef _TIMER_H_
#define _TIMER_H_

//INCLUDE
#include <avr/io.h>

//DEFINE


//PROTOTYPE FONCTIONS EXTERNES
void TIMER0_STOP(void);
void TIMER0_START(void);
void TIMER0_INIT(void);
void TIMER1_INIT(void);
void TIMER2_INIT(void);
void TIMER2_STOP(void);
void TIMER2_START(void);

#endif /* _TIMER_H */
