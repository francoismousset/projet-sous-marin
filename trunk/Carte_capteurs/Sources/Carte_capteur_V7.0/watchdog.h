/****************************************************************
 *																*
 *	FileName :		watchdog.h									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		07/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Comp�re Christopher							*
 *																*
 ****************************************************************/

#ifndef _WATCHDOG_H_
#define _WATCHDOG_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/wdt.h>

//Dur�e de fonctionnement maximum du sous-marin en minute
//Lorsque la dur�e de fonctionnement a expir�, 
//on reset le programme
#define LIFETIME_MIN	1	
#define TIMEOUT_RESET	((LIFETIME_MIN * 60) /8) -1

void init_watchdog(void);

#endif /* _WATCHDOG_H_ */
