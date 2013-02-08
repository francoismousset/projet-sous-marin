/* COM_600_BAUD.h */

/**********************************************************************
*
* File name		 : COM_600_BAUD.h
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

#ifndef _COM_600_BAUD_H_
#define _COM_600_BAUD_H_

//INCLUDE
#include <avr/io.h>

//DEFINE
#define COMSPEED 4	// COMSPEED : 8 = 300baud ; 4 = 600baud ; 2 = 1200baud ; 1 = 2400baud
#define COMSPEEED COMSPEED+COMSPEED
#define COMSP COMSPEED+COMSPEED+COMSPEED+COMSPEED
#define COMSPD COMSPEEED+COMSPEEED+COMSPEEED+COMSPEED

//PROTOTYPE FONCTIONS EXTERNES
void Received_600_baud(void);
void Send_600_baud(void);
unsigned char com_test(void);

#endif /* _COM_600_BAUD_H */
