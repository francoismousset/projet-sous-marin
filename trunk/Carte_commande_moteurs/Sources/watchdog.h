/****************************************************************
 *																*
 *	FileName :		watchdog.h									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		07/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _WATCHDOG_H_
#define _WATCHDOG_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/wdt.h>

//Durée de fonctionnement maximum du sous-marin en minute
//Lorsque la durée de fonctionnement a expiré, 
//on reset le programme et le sous-marin remonte automatiquement
#define LIFETIME_MIN	10	//D'après les tests pour 30min désiré, on est plus proche des 33min en réel
#define TIMEOUT_RESET	((LIFETIME_MIN * 60) /8) -1

void init_watchdog(void);

#endif /* _WATCHDOG_H_ */
