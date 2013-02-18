/* gestion_H.c */

/**********************************************************************
*
* File name		 : gestion_H.c
* Title 		 : Gestion de la conversion de l'humidité relative
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 07/05/2012
* Last revised	 : 18/02/2013
* Version		 : 1.2
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "gestion_H.h"

/*********************************************************************/
// FUNCTION: unsigned char convertHum(char *humMes)	
// PURPOSE: Convertir la valeur d'humidité brute, en valeur exploitable
unsigned char convertHum(char *humMes)		
{
	unsigned long int hum_whole = 0 ;
	unsigned char hum_pourc = 0;
	
	hum_whole = humMes[0] << RES_SHIFT ;		// Décaler de 8 bits vers la gauche du bit de poid fort
	hum_whole = hum_whole + humMes[1];			// Ajouter le bit de poids faible
	hum_whole &= ~0x0003;         				// clear bits [1..0] (status bits)
	
	/******* Formule pour obtenir l'humidité relative *******/
	/* relative  humidity  above  liquid  water  according  to  World Meteorological Organization  (WMO) */
	hum_whole = 125*hum_whole;

	hum_whole = hum_whole/65536; 
	hum_pourc = hum_whole -6;

	if (hum_pourc >= 183)
	{
		hum_pourc = hum_pourc - 130;
	}
	
	return hum_pourc;		// Retourne la valeur de l'humidité relative en %, de 0 à 100
}

/*********************************************************************/
// FUNCTION: stringHum(char humResult, char *humStr)
// PURPOSE: Convertir la valeur de l'humidité relatives exploitable
//			en caractères
void stringHum(char humResult, char *humStr)
{
	humStr[0] = (humResult/10)+48;
	humStr[1] = (humResult%10)+48;
}
