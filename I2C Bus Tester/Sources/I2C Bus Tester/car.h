/* car.h */

/**********************************************************************
*
* File name		 : car.h
* Title 		 : Caract�res et messages
* Author 		 : Micha�l Brogniaux - Copyright (C) 2013
* Created		 : 03/02/2013
* Last revised	 : 06/05/2013
* Version		 : 1.1.5
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef car_H
#define car_H

/**********************************************************************/
#define DEG_CAR				167 	// Symbole "degre" : �
#define NEG_CAR				'-'		// Symbole "moins" : -
#define C_CAR				'C'		// Lettre : C
#define COMMA_CAR			','		// Virgule
#define DOT_CAR				'.'		// Point
#define SPACE_CAR 			' '		// Espace
#define PERCENT_CAR 		'%'		// Pourcent
#define NEW_PAGE		 	'\f'	// Nouvelle page
#define NEW_LINE		 	'\n'	// Retour � la ligne
#define CARRIAGE_RETURN 	'\r'	// Retour � la ligne
#define	BELL				'\a'	// Sonnerie
#define CR_NL				""		// Sans caract�re (pour CR et NL)
#define MSG_WELCOME			" /== Welcome in the I2C bus tester software ==\\ "
#define MSG_YEAR			" \\== MA2EN 2012-2013  Hrd v1.3b - Sft v1.2.12 ==/"
#define ERROR_MSG			" connection error !!!"
#define	CONN_MSG			" connected."
#define STX					0x02	// Start of header
#define ETX					0x03	// End of header
/**********************************************************************/

#endif
