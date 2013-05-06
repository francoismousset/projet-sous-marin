/* gestion_A.c */

/**********************************************************************
*
* File name		 : gestion_A.c
* Title 		 : Gestion de la conversion de la pression
* Author 		 : Benoît Echevin - Copyright (C) 2013
* Created		 : 22/03/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_A.h"

/*********************************************************************/
// FUNCTION: convertTemp(char *tempMes, char *tempResult)
// PURPOSE: Convertir la valeur de T° brute, en valeur exploitable
void convertAcc(char *tempMes, char *tempResult)		
{
	int temp = 0;
	if(tempMes[0]!=0) temp = tempMes[0]/64 + tempMes[1]*4;
	else temp = tempMes[1]*4;
	temp = temp*1.0683-321.4286; //(((((((3.3 * temp) / 1023)*33/(33+18)) - 1.5 )* 1000) / 420) * 90);
	if(temp>=0) 
	{
		tempResult[0]=temp;
		tempResult[1]=(temp>>8);
	}
	else
	{
		temp = 0-temp;
		tempResult[0]=temp;
		tempResult[1]=(temp>>8)+128;
	}
}
