/* main.h */

/**********************************************************************
*
* File name		 : main.h
* Title 		 : I2C Bus Tester
				   Projet sous-marin
				   Programme carte de test bus I2C & capteurs
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 02/03/2012
* Last revised	 : 18/02/2013
* Version		 : 1.2.2
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : Capteurs I2C (DS7505, SHT21)
*
**********************************************************************/

#ifndef MAIN_H
#define MAIN_H

/* DEFINE */
#define TRUE 1
#define FALSE 0
#define NULL 0
#define BOOL    char

/* Macro definitions */
#define sDDR(ddr,bit)  		(ddr |= (1<<bit))   	// Set I/O bit in port
#define sbiBF(port,bit)  	(port |= (1<<bit))   	// Set bit in port
#define cbiBF(port,bit)  	(port &= ~(1<<bit))  	// Clear bit in port
#define sbiR(reg,bit) 		(reg |= (1<<bit)) 		// Set bit in register
#define cbiR(reg,bit)  		(reg &= ~(1<<bit))  	// Clear bit in register


/*********************** Déclaration des fonctions *************************/

void init();		// Initialisations globales

#endif /* MAIN_H */
