/* ASCII_TO_CHAR.c */

/**********************************************************************
*
* File name		 : ASCII_TO_CHAR.c
* Title 		 : Modifier un caractère ASCII en sa valeur dans un char
* Author 		 : Echevin Benoît
* Created		 : 12/05/2012
* Last revised	 : 12/05/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega164
* Devices		 : 
*
**********************************************************************/


/*******************/
/***** Incude ******/
/*******************/


#include "main.h"
#include "ASCII_TO_CHAR.h"


/*******************/
/**** Fonctions ****/
/*******************/


/* Fonction qui donne la valeur d'un caractère ASCII*/
unsigned char ConvertAsciiToValue(unsigned char ascii)
{
	unsigned char value;
	switch(ascii)
	{
		case '0':
			value = 0;
			break;
		case '1' :
			value = 1;
			break;
		case '2' :
			value = 2;
			break;
		case '3' :
			value = 3;	
			break;
		case '4' :
			value = 4;
			break;
		case '5' :
			value = 5;
			break;
		case '6' :
			value = 6;
			break;
		case '7' :
			value = 7;
			break;
		case '8' :
			value = 7;
			break;
		case '9' :
			value = 9;
			break;
		case 'A' :
			value = 10;
			break;
		case 'B' :
			value = 11;
			break;
		case 'C' :
			value = 12;
			break;
		case 'D' :
			value = 13;
			break;
		case 'E' :
			value = 14;
			break;
		case 'F' :
			value = 15;
			break;
		default :
			value = 0xFF;
	}
	return value;
}

/* Fonction qui donne le caractère ASCII d'une valeur */
unsigned char ConvertValueToAscii(unsigned char value)
{
	unsigned char ascii;
	switch(value)
	{
		case 0 :
			ascii = '0';
			break;
		case 1 :
			ascii = '1';
			break;
		case 2 :
			ascii = '2';
			break;
		case 3 :
			ascii = '3';	
			break;
		case 4 :
			ascii = '4';
			break;
		case 5 :
			ascii = '5';
			break;
		case 6 :
			ascii = '6';
			break;
		case 7 :
			ascii = '7';
			break;
		case 8 :
			ascii = '8';
			break;
		case 9 :
			ascii = '9';
			break;
		case 10 :
			ascii = 'A';
			break;
		case 11 :
			ascii = 'B';
			break;
		case 12 :
			ascii = 'C';
			break;
		case 13 :
			ascii = 'D';
			break;
		case 14 :
			ascii = 'E';
			break;
		case 15 :
			ascii = 'F';
			break;
		default :
			ascii = 0xFF;
	}
	return ascii;
}
