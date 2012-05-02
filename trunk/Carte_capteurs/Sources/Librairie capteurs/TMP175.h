/* TMP175.h */

/**********************************************************************
*
* File name		 : TMP175.b
* Title 		 : Gestion du capteur de température TI TMP175
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 18/03/2012
* Last revised	 : 18/03/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef TMP175_H
#define TMP175_H

/***** TMP175 Address devices *****/
#define ADD1_TMP175  	0x90      			// Device address of TMP175 n°1, 10010000
#define ADD2_TMP175  	0x92      			// Device address of TMP175 n°2, 10010010
#define ADD3_TMP175  	0x94      			// Device address of TMP175 n°3, 10010100

/***** TMP175 Pointer Register Byte *****/
#define TEMP_REG    	 0b00000000         // Temperature register
#define CONF_REG    	 0b00000001         // Configuration register
#define TLOW_REG    	 0b00000010         // T° low register
#define THIGH_REG    	 0b00000011         // T° high register

/***** TMP175 Configuration bits *****/
#define OS       		0b10000000          // ONE-SHOT measurement
#define R1        		0b01000000          // CONVERTER RESOLUTION 1
#define R0        		0b00100000          // CONVERTER RESOLUTION 0
#define F1        		0b00010000          // Fault 1
#define F0       		0b00001000          // Fault 0
#define POL        		0b00000100          // POLARITY
#define TM        		0b00000010          // THERMOSTAT MODE
#define ST		   		0b00000001          // SHUTDOWN MODE

/***** TMP175 Resolution *****/
#define RES_9       	0b00000000      	// Conversion sur 9 bits
#define RES_10       	0b00100000      	// Conversion sur 10 bits
#define RES_11       	0b01000000      	// Conversion sur 11 bits
#define RES_12       	0b01100000      	// Conversion sur 12 bits


/*********************** Déclaration des fonctions *************************/

/*********************************************************************/
// FUNCTION: char initDS1631(unsigned char addr_mode)
// PURPOSE: Initialisation d'un TMP175 dont l'adresse I2C est spécifiée
unsigned char initTMP175(unsigned char addr_mode); 

/*********************************************************************/
// FUNCTION: get_DS1631_Devices(unsigned char addr_mode, char *listTemp)
// PURPOSE: Aquérir la T° d'un TMP175 dont l'adresse I2C est spécifiée
void get_TMP175_Devices(unsigned char addr_mode, char *listTemp);


#endif
