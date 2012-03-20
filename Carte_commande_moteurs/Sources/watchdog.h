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
//on reset le programme et le sous-marin remonte automatiquement
#define LIFETIME_MIN	10	//D'apr�s les tests pour 30min d�sir�, on est plus proche des 33min en r�el
#define TIMEOUT_RESET	((LIFETIME_MIN * 60) /8) -1

void init_watchdog(void);

#endif /* _WATCHDOG_H_ */
