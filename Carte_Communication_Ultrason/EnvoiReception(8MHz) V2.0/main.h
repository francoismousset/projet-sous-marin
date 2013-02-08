/* main.h */

/**********************************************************************
*
* File name		 : main.h
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

#ifndef _MAIN_H_
#define _MAIN_H_

// INCLUDE
#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdlib.h>
#include <stdint.h>
#include <avr/pgmspace.h>
#include <util/delay.h>
#include <inttypes.h>

#include "USART.h"
#include "COM_600_BAUD.h"
#include "TIMER.h"
#include "USART.h"
#include "INT.h"
#include "ASCII_TO_CHAR.h"

// DEFINE
#define sDDR(ddr,bit) (ddr |= (1<<bit))   		// Set I/O bit in port
#define sbiBF(port,bit) (port |= (1<<bit))   	// Set bit in port
#define cbiBF(port,bit) (port &= ~(1<<bit))  	// Clear bit in port
#define sbiR(reg,bit) (reg |= (1<<bit)) 		// Set bit in register
#define cbiR(reg,bit) (reg &= ~(1<<bit))  		// Clear bit in register
#define TRUE 1
#define FALSE 0
#define ON 1
#define OFF 0

// FUNCTIONS
void init(void);
void chartobit (unsigned char car, volatile unsigned char tab []);
void End_Init(void);

#endif /* _MAIN_H */
