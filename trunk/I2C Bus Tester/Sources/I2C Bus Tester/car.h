/* car.h */

/**********************************************************************
*
* File name		 : car.h
* Title 		 : Caractères et messages
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 03/02/2013
* Last revised	 : 05/02/2013
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef car_H
#define car_H

/**********************************************************************/
#define DEG_CAR				167 	// Symbole "degre" : °
#define NEG_CAR				'-'		// Symbole "moins" : -
#define C_CAR				'C'		// Lettre : C
#define COMMA_CAR			','		// Virgule
#define DOT_CAR				'.'		// Point
#define SPACE_CAR 			' '		// Espace
#define PERCENT_CAR 		'%'		// Pourcent
#define NEW_PAGE		 	'\f'	// Nouvelle page
#define NEW_LINE		 	'\n'	// Retour à la ligne
#define CARRIAGE_RETURN 	'\r'	// Retour à la ligne
#define	BELL				'\a'	// Sonnerie
#define CR_NL				""		// Sans caractère (pour CR et NL)
#define MSG_WELCOME			" /== Welcome in the I2C bus tester software ==\\ "
#define MSG_YEAR			"     MA2EN 2012-2013 Hrd v1.1 - Sft v1.2.2"
#define ERROR_MSG			" connection error !!!"
#define	CONN_MSG			" connected."
/**********************************************************************/

#endif
