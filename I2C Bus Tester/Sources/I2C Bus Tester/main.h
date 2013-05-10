/* main.h */

/**********************************************************************
*
* File name		 : main.h
* Title 		 : I2C Bus Tester
				   Projet sous-marin
				   Programme carte de test bus I2C & capteurs
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 02/03/2012
* Last revised	 : 06/05/2013
* Version		 : 1.2.11
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

/* List of commands */
#define T1_CMD '1'
#define T2_CMD '2'
#define T3_CMD '3'
#define T4_CMD '4'
#define T5_CMD '5'
#define T6_CMD '6'
#define T7_CMD '7'
#define T8_CMD '8'
#define H1_CMD '9'

#define T1_DETECT_CMD 'a'
#define T2_DETECT_CMD 'b'
#define T3_DETECT_CMD 'c'
#define T4_DETECT_CMD 'd'
#define T5_DETECT_CMD 'e'
#define T6_DETECT_CMD 'f'
#define T7_DETECT_CMD 'g'
#define T8_DETECT_CMD 'h'
#define H1_DETECT_CMD 'i'
#define ALL_DETECT_CMD 'j'

//#define SEND_I2C_CMD 'k'

#define DEBUG_CMD 'x'
#define RX_BUFFER 20

/*********************** Déclaration des fonctions *************************/

void init();		// Initialisations globales
void init_sensors(); // Initialisation des capteurs
void showDetectedSensor(char address); //Détection de tous les capteurs

#endif /* MAIN_H */
