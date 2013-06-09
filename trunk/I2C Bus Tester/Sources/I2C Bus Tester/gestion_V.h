/* gestion_V.h */

/**********************************************************************
*
* File name		 : gestion_V.h
* Title 		 : Gestion de la conversion de la tension
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 31/05/2012
* Last revised	 : 31/05/2013
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef gestion_V_H
#define gestion_V_H

/*********************************************************************/
// FUNCTION: void stringVolt(char *VoltResult, char *VoltStr)
// PURPOSE: Convertir la valeur de la tension exploitable
//			en caractères
void stringVolt(char *VoltResult, char *VoltStr);

#endif

