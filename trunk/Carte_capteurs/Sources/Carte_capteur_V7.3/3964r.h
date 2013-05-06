/****************************************************************
 *																*
 *	FileName :		3964r.h										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
  *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _3964R_H_
#define _3964R_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include "usart.h"
#include "timer1.h"
#include "main.h"

//Défintion du code ASCII pour les caractères non-imprimable
#define STX 0x02 //02
#define ETX 0x03 //03
#define DLE 0x10 //10
#define NAK 0x15 //15
#define NAK1 0x41 //A
#define NAK2 0x42 //B
#define NAK3 0x43 //C
#define NAK4 0x44 //D
#define NAK5 0x45 //E
#define NAK6 0x46 //F

//Définition d'une constante pour la définition de priorité
#define HIGH_PRIORITY 0
#define LOW_PRIORITY 1

//Nombre de tentative max
#define MAX_ERRORS 6
//Taille du tableau d'erreur
#define NB_ERRORS 5
//Définition du timeout (10000 = 10ms)
#define TIMEOUT_MS 400000	//25 ms limite avec la FOXBOARD

//Valeur de retour de la commande d'envoie
#define TRANSMISSION_SUCCESS 0
#define TRANSMISSION_FAILED 1
#define RECEPTION_MODE 2

#define TRUE 0
#define FALSE 1

//Fonctions public
void init_3964r(void);
void get_data_3964r(char[]);
char send_data_3964r(char[], unsigned char);

#endif /* _3964R_H_*/
