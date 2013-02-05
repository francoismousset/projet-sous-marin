/* DS1621.h */

/**********************************************************************
*
* File name		 : DS1621.c
* Title 		 : Gestion du capteur de température Maxim DS1621
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 07/03/2012
* Last revised	 : 08/03/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

//#ifndef MAIN_H
//#define MAIN_H

/***** DS1621 address devices *****/
#define ADD1_DS1621  	0x90      			// Device address of DS1621 n°1, 10010000
#define ADD2_DS1621  	0x92      			// Device address of DS1621 n°2, 10010010
#define ADD3_DS1621  	0x94      			// Device address of DS1621 n°3, 10010100

/***** DS1621 Registers & Commands *****/
#define RD_TEMP    	 	0xAA                // Read temperature register
#define ACCESS_TH  		0xA1                // Access high temperature register
#define ACCESS_TL  		0xA2                // Access low temperature register
#define ACCESS_CFG 		0xAC                // Access configuration register
#define RD_CNTR    		0xA8                // Read counter register
#define RD_SLOPE   		0xA9                // Read slope register
#define START_CNV  		0xEE                // Start temperature conversion
#define STOP_CNV   		0X22                // Stop temperature conversion

/***** DS1621 configuration bits *****/
#define DONE       		0b10000000          // Conversion is done
#define THF        		0b01000000          // High temp flag
#define TLF        		0b00100000          // Low temp flag
#define NVB        		0b00010000          // Non-volatile memory is busy
#define POL        		0b00000010          // Output polarity (1 = high, 0 = low)
#define ONE_SHOT   		0b00000001          // 1 = one conversion; 0 = continuous conversion


/*********************** Déclaration des fonctions *************************/

/*********************************************************************/
// FUNCTION: char initDS1621(unsigned char addr_mode)
// PURPOSE: Initialisation d'un DS1621 dont l'adresse I2C est spécifiée
unsigned char initDS1621(unsigned char addr_mode); 

/*********************************************************************/
// FUNCTION: get_DS1621_Devices(unsigned char addr_mode, char *listTemp)
// PURPOSE: Aquérir la T° d'un DS1621 dont l'adresse I2C est spécifiée
unsigned char get_DS1621_Devices(unsigned char addr_mode, char *listTemp);


//#endif
