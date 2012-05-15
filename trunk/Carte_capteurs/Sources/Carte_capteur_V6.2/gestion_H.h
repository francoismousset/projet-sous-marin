/* gestion_H.h */

/**********************************************************************
*
* File name		 : gestion_H.c
* Title 		 : Gestion de la conversion de l'humidité relative
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 07/05/2012
* Last revised	 : 11/05/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef gestion_H_H
#define gestion_H_H

#define RES_SHIFT 	8 
#define RES_MAX 	256 

/*********************************************************************/
// FUNCTION: unsigned char convertHum(char *humMes)	
// PURPOSE: Convertir la valeur d'humidité brute, en valeur exploitable
unsigned char convertHum(char *humMes);	

#endif
