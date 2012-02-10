/****************************************************************
 *																*
 *	FileName :		external_interrupt.c						*
 *	Rev 	 : 		0.2											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		18/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "external_interrupt.h"

//Constante DEBUG_EXT_INT à décommenter pour compiler en mode debugging au niveau interruption externe
//Permet de visualiser le nombre d'impulsion sur le port série
//#define DEBUG_EXT_INT

#ifdef DEBUG_EXT_INT
#include <stdlib.h>
#include "usart.h"

char tab_debug[10];
#endif

//Compteur d'impulsion de la fourche optique
volatile unsigned int nb_impuls_wheel1;
volatile unsigned int nb_impuls_wheel2;

//Configuration des interruptions externe INT0 et INT1
void init_external_interrupt(void)
{
	//External INT0 INTT1 (Rising edge)
	EICRA |= (1<<ISC11) | (1<<ISC10) | (1<<ISC01) | (1<<ISC00);
	EIMSK |= (1<<INT1) | (1<<INT0);

	nb_impuls_wheel1 = 0;
	nb_impuls_wheel2 = 0;
}

//Retourne le nombre d'impulsion du ballast 1
unsigned int get_position1(void)
{
	return nb_impuls_wheel1;
}

//Retourne le nombre d'impulsion du ballast 2
unsigned int get_position2(void)
{
	return nb_impuls_wheel2;
}


ISR(INT0_vect)
{
	if(get_rotation_motor1() == COUNTERCLOCKWISE)
		nb_impuls_wheel1++;
	else
		nb_impuls_wheel1--;
	
#ifdef DEBUG_EXT_INT
	itoa(nb_impuls_wheel1,tab_debug,10);
	puts_usart("Position ballast 1 : ");
	puts_usart(tab_debug);
	putchar_usart(0x0d);
	putchar_usart(0x0a);
#endif
}

ISR(INT1_vect)
{
	if(get_rotation_motor2() == COUNTERCLOCKWISE)
		nb_impuls_wheel2++;
	else
		nb_impuls_wheel2--;

#ifdef DEBUG_EXT_INT
	itoa(nb_impuls_wheel2,tab_debug,10);
	puts_usart("Position ballast 2 : ");
	puts_usart(tab_debug);
	putchar_usart(0x0d);
	putchar_usart(0x0a);
#endif
}
