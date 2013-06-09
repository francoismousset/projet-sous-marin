/* gestion_A.c */

/**********************************************************************
*
* File name		 : gestion_A.c
* Title 		 : Gestion de la conversion de l'angle
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 31/05/2012
* Last revised	 : 31/05/2013
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_A.h"

/*********************************************************************/
// FUNCTION: stringAng(char AngResult, char *AngStr)
// PURPOSE: Convertir la valeur de l'angle exploitable
//			en caractères
void stringAng(char AngResult, char *AngStr)
{
	AngStr[0] = (AngResult/10)+48;
	AngStr[1] = (AngResult%10)+48;
}
