/* gestion_P.c */

/**********************************************************************
*
* File name		 : gestion_T.c
* Title 		 : Gestion de la conversion de la pression
* Author 		 : Benoît Echevin - Copyright (C) 2013
* Created		 : 18/03/2013
* Last revised	 : 22/03/2013
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_P.h"

/*********************************************************************/
// FUNCTION: convertTemp(char *tempMes, char *tempResult)
// PURPOSE: Convertir la valeur de T° brute, en valeur exploitable
void convertPressure(char *tempMes, char *tempResult, int InitialProfondeur)		
{
	int temp = 0;
	if(tempMes[0]==0 && tempMes[1]==0) { tempResult[0]=0; tempResult[1]=0; return; }
	else if(tempMes[0]!=0) temp = tempMes[0]/64 + tempMes[1]*4;
	else temp = tempMes[1]*4;
	temp = (temp*2.4927-InitialProfondeur);//(((temp/1023*3.3)*(18+33)/33) / 20 * 1000 *10);
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
