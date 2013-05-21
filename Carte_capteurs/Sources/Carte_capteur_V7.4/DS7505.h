/* DS7505.h */

/**********************************************************************
*
* File name		 : DS7505.h
* Title 		 : Gestion du capteur de température Maxim DS7505
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 30/03/2012
* Last revised	 : 09/05/2012
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef DS7505_H
#define DS7505_H

/***** DS7505 Address devices *****/
#define ADD1_DS7505  	0x90      			// Device address of DS7505 n°1, 1001000x
#define ADD2_DS7505  	0x92      			// Device address of DS7505 n°2, 1001001x
#define ADD3_DS7505  	0x94      			// Device address of DS7505 n°3, 1001010x
#define ADD4_DS7505  	0x96      			// Device address of DS7505 n°4, 1001011x
#define ADD5_DS7505  	0x98      			// Device address of DS7505 n°5, 1001100x
#define ADD6_DS7505  	0x9A      			// Device address of DS7505 n°6, 1001101x
#define ADD7_DS7505  	0x9C      			// Device address of DS7505 n°7, 1001110x
#define ADD8_DS7505  	0x9E      			// Device address of DS7505 n°3, 1001111x

/***** DS7505 Pointer Register Byte *****/
#define TEMP_REG    	 0b00000000         // Temperature register
#define CONF_REG    	 0b00000001         // Configuration register
#define THYST_REG    	 0b00000010         // 
#define TOS_REG    	 	 0b00000011         //

/***** DS7505 Configuration register bits *****/
#define NVB       		0b10000000          // NV Memory Status
#define R1        		0b01000000          // CONVERTER RESOLUTION 1
#define R0        		0b00100000          // CONVERTER RESOLUTION 0
#define F1        		0b00010000          // Thermostat Fault Tolerance Bit 1 
#define F0       		0b00001000          // Thermostat Fault Tolerance Bit 0
#define POL        		0b00000100          // Thermostat Output (O.S.) Polarity 
#define TM        		0b00000010          // THERMOSTAT OPERATING MODE
#define SD		   		0b00000001          // SHUTDOWN MODE

/***** DS7505 Resolution *****/
#define RES_9       	0b00000000      	// Conversion sur 9 bits
#define RES_10       	0b00100000      	// Conversion sur 10 bits
#define RES_11       	0b01000000      	// Conversion sur 11 bits
#define RES_12       	0b01100000      	// Conversion sur 12 bits


/*********************** Déclaration des fonctions *************************/

/*********************************************************************/
// FUNCTION: char initDS7505(unsigned char addr_mode)
// PURPOSE: Initialisation d'un DS7505 dont l'adresse I2C est spécifiée
unsigned char initDS7505(unsigned char addr_mode); 

/*********************************************************************/
// FUNCTION: get_DS7505_Devices(unsigned char addr_mode, char *listTemp)
// PURPOSE: Aquérir la T° d'un DS7505 dont l'adresse I2C est spécifiée
unsigned char get_DS7505_Devices(unsigned char addr_mode, char *listTemp);

#endif
