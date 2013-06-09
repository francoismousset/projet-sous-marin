/* gestion_D.c */

/**********************************************************************
*
* File name		 : gestion_D.c
* Title 		 : Gestion de la conversion de la profondeur
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 31/05/2012
* Last revised	 : 31/05/2013
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_D.h"

/*********************************************************************/
// FUNCTION: stringDep(char DepResult, char *DepStr)
// PURPOSE: Convertir la valeur de profondeur exploitable
//			en caractères
void stringDep(char DepResult, char *DepStr)
{
	char DepTempo;

	DepStr[0] = (DepResult/100)+48;
	DepTempo = (DepResult%100);
	DepStr[1] = (DepTempo/10)+48;
	DepStr[2] = (DepTempo%10)+48;
}
