/* gestion_T.c */

/**********************************************************************
*
* File name		 : gestion_T.c
* Title 		 : Gestion de la conversion de la température
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 07/05/2012
* Last revised	 : 03/02/2013
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_T.h"
#include "car.h"

/*********************************************************************/
// FUNCTION: convertTemp(char *tempMes, char *tempResult)
// PURPOSE: Convertir la valeur de T° brute, en valeur exploitable
void convertTemp(char *tempMes, char *tempResult)		
{
	//unsigned int tempNeg = 0;
	unsigned int temp_fraction = 0, temp_Lpol = 0; //tempHLpol = 0;
	char temp_whole =0 ;
	/******* Vérifier si la température est négative *******/
    if (tempMes[0] & 0x80) // Si température négative (1000.0000.0000.0000)
    {
		temp_Lpol = 0b10000000; // Bit 8 à 1 pour signaler la température négative
        temp_whole = ~tempMes[0] + 1;                     // Inverser la valeur et incrémenter de 1 (complément à 2
		//temp_whole = tempMes >> RES_SHIFT ;			// Extraire la valeur de la température, sans bits de signe
    }
	else // Si température positive
	{	
		temp_whole = tempMes[0];
		//temp_whole = tempMes >> RES_SHIFT ;			// Extraire la valeur de la température, sans bits de signe
		temp_Lpol = 0b00000000; // Bit 8 à 0 pour signaler la température positive
	}

    /******* Extraire les décimales *******/
    temp_fraction = tempMes[1] & 0xC0;             // Masquage, garder le bit 7 et 6
	switch (temp_fraction)
	{
		case 0b00000000 :
			temp_Lpol =  temp_Lpol + 0 ;
			break;
			
		case 0b01000000 :
			temp_Lpol =  temp_Lpol + 25 ;
			break;
			
		case 0b10000000 :
			temp_Lpol = temp_Lpol + 50 ;
			break;
			
		case 0b11000000 :
			temp_Lpol =  temp_Lpol + 75 ;
			break;
	}
	tempResult[0] = temp_whole;		// Sauver les unités de température
	tempResult[1] = temp_Lpol;		// Sauver les décimales et le signe (+/-)
}

/*********************************************************************/
// FUNCTION: stringTemp(char *tempResult, char *tempStr)
// PURPOSE: Convertir la valeur de T° exploitable en caractères
void stringTemp(char *tempResult, char *tempStr)
{
	tempStr[1] = (tempResult[0]/10)+48;
	tempStr[2] = (tempResult[0]%10)+48;

	switch(tempResult[1]& 0b01111111)
	{
		case 0 :
			tempStr[3] = '0';
			tempStr[4] = '0';
			break;
		case 25 :
			tempStr[3] = '2';
			tempStr[4] = '5';
			break;
		case 50 :
			tempStr[3] = '5';
			tempStr[4] = '0';
			break;
		case 75 :
			tempStr[3] = '7';
			tempStr[4] = '5';
			break;
		default:
			tempStr[3] = '%';
			tempStr[4] = '%';
	}
	
	tempStr[0] = tempResult[1] & 0b10000000;
	if(tempStr[0] == 0b10000000)
	{
		tempStr[0] = NEG_CAR;
	}
	else
	{
		tempStr[0] = SPACE_CAR;
	}
}
