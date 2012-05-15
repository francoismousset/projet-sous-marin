/* gestion_T.h */

/**********************************************************************
*
* File name		 : gestion_T.h
* Title 		 : Gestion de la conversion de la température
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 07/05/2012
* Last revised	 : 09/05/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef gestion_T_H
#define gestion_T_H

#define RES_SHIFT 8 // Nombre de bits à décaler pour les chiffres décimaux

/*********************************************************************/
// FUNCTION: convertTemp(char *tempMes, char *tempResult)
// PURPOSE: Convertir la valeur de T° brute, en valeur exploitable
void convertTemp(char *tempMes, char *tempResult);	

#endif
