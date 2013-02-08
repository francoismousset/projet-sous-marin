/* INT.h */

/**********************************************************************
*
* File name		 : INT.h
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

#ifndef _INT_H_
#define _INT_H_

//INCLUDE
#include <avr/io.h>

//DEFINE


//PROTOTYPE FONCTIONS EXTERNES
void init_pcint(void);
void INT_BP(void);

#endif /* _INT_H */
