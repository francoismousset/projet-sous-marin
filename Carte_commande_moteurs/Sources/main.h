/****************************************************************
 *																*
 *	FileName :		main.h										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		06/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _MAIN_H_
#define _MAIN_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include "motor_driver.h"
#include "ballast_position.h"
#include "3964r.h"
#include "watchdog.h"

//Constante à commenter en fonction du sous-marin (U_BOAT ou nouveau sous-marin)
//#define U_BOAT

//Taille du tableau à envoyer à la FOXBOARD
#define SIZE_MSG 3

void init_main(void);

#endif /* _MAIN_H_ */
