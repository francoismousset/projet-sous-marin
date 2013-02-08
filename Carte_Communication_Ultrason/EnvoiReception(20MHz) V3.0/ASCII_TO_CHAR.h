/* ASCII_TO_CHAR.h */

/**********************************************************************
*
* File name		 : ASCII_TO_CHAR.h
* Title 		 : Modifier un caract�re ASCII en sa valeur dans un char
* Author 		 : Echevin Beno�t
* Created		 : 12/05/2012
* Last revised	 : 12/05/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega164
* Devices		 : 
*
**********************************************************************/

#ifndef _ASCII_TO_CHAR_h_ // Si pas d'autre d�finition de EEPROM.h
#define _ASCII_TO_CHAR_h_


/* Fonctions*/
unsigned char ConvertAsciiToValue(unsigned char ascii);
unsigned char ConvertValueToAscii(unsigned char value);


#endif /* _ASCII_TO_CHAR_h_ */
