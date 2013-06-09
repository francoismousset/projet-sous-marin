/* gestion_V.c */

/**********************************************************************
*
* File name		 : gestion_V.c
* Title 		 : Gestion de la conversion de la tension
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 31/05/2012
* Last revised	 : 31/05/2013
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_V.h"

/*********************************************************************/
// FUNCTION: void stringVolt(char *VoltResult, char *VoltStr)
// PURPOSE: Convertir la valeur de la tension exploitable
//			en caractères
void stringVolt(char *VoltResult, char *VoltStr)
{
	// Les unités
	VoltStr[0] = (VoltResult[0]/10)+48;
	VoltStr[1] = (VoltResult[0]%10)+48;	
	// Les centièmes
	VoltStr[2] = (VoltResult[1]/10)+48;
	VoltStr[3] = (VoltResult[1]%10)+48;
}
