/****************************************************************
 *																*
 *	FileName :		3964r.h										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
  *	Compiler : 		WinAVR										*
 *	Author 	 :		Comp�re Christopher							*
 *																*
 ****************************************************************/

#ifndef _3964R_H_
#define _3964R_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include "usart.h"
#include "timer1.h"
#include "main.h"

//D�fintion du code ASCII pour les caract�res non-imprimable
#define STX 0x02 //02
#define ETX 0x03 //03
#define DLE 0x10 //10
#define NAK 0x15 //15

//D�finition d'une constante pour la d�finition de priorit�
#define HIGH_PRIORITY 0
#define LOW_PRIORITY 1

//Nombre de tentative max
#define MAX_ERRORS 6
//Taille du tableau d'erreur
#define NB_ERRORS 5
//D�finition du timeout (10000 = 10ms)
#define TIMEOUT_MS 10000	//5 ms limite avec la FOXBOARD

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
