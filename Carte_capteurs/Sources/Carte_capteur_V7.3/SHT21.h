/* SHT21.h */

/**********************************************************************
*
* File name		 : SHT21.h
* Title 		 : Gestion du capteur d'humidit� SHT21
* Author 		 : Micha�l Brogniaux - Copyright (C) 2011
* Created		 : 30/03/2012
* Last revised	 : 02/02/2013
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef SHT21_H
#define SHT21_H

/***** SHT21 Address devices *****/
#define ADD1_SHT21  	 0x80      			// Device address of SHT21 n�1, 1000000x

/***** SHT21 Command*****/
#define TRIG_T    	 	0b11100011       	// Trigger Temperature measurement (hold master)
#define TRIG_RH    	 	0b11100101       	// Trigger Relative Humidity measurement (hold master)
#define TRIG_T_NH    	0b11110011       	// Trigger Temperature measurement (no hold master)
#define TRIG_NH    	 	0b11110101        	// Trigger Relative Humidity measurement (no hold master)
#define W_USER_REG 	 	0b11100110        	// Write user register 
#define R_USER_REG 	 	0b11100111         	// Read user register 
#define SOFT_RESET      0b11111110  		// Soft reset
 
/***** SHT21 User register *****/
#define BAT_END      		0b01000000          // END of battery
#define EN_HEATER      		0b00000100          // Enable on-chip heater 
#define DIS_OTP      		0b00000010          // Disable OTP Reload 

/***** SHT21 Resolution *****/
#define RES_RH_8       		0b00000011      	// Conversion sur 8 bits + Disable OTP Reload 
#define RES_RH_10       	0b10000010      	// Conversion sur 10 bits + Disable OTP Reload 
#define RES_RH_11       	0b10000011      	// Conversion sur 11 bits + Disable OTP Reload 
#define RES_RH_12       	0b00000010      	// Conversion sur 12 bits + Disable OTP Reload

/*********************** D�claration des fonctions *************************/

/*********************************************************************/
// FUNCTION: unsigned char SHT21_SoftReset(unsigned char addr_mode)
// PURPOSE: Soft reset du capteur d'humit� SHT21
unsigned char SHT21_SoftReset(unsigned char addr_mode);

/*********************************************************************/
// FUNCTION: char initSHT21(unsigned char addr_mode)
// PURPOSE: Initialisation d'un SHT21 dont l'adresse I2C est sp�cifi�e
unsigned char initSHT21(unsigned char addr_mode); 

/*********************************************************************/
// FUNCTION: get_SHT21_Devices(unsigned char addr_mode, char *listHum)
// PURPOSE: Acqu�rir l'humidit� relative d'un SHT21 dont l'adresse
// I2C est sp�cifi�e
unsigned char get_SHT21_Devices(unsigned char addr_mode, char *listHum);

#endif
