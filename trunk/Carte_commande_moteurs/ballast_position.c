/****************************************************************
 *																*
 *	FileName :		ballast_position.c							*
 *	Rev 	 : 		0.2											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		06/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "ballast_position.h"

#ifdef U_BOAT
#define ADC_VAL_MIN 1    	  //Valeur renvoyée par l'ADC en position basse
#define ADC_VAL_MAX 1023	  //Valeur renvoyée par l'ADC en position haute
#define ADC_DELTA_VAL (ADC_VAL_MAX - ADC_VAL_MIN)
#else
#define MAX_IMPULSION 115 //Nombre d'impusion max entre 2 fins de course
#endif

//Initialisation de la fonction de mesure de la position du ballast
void init_ballast_position(void)
{
//Pour le U_BOAT utilisation de l'adc
#ifdef U_BOAT
	init_adc();
#else
//Pour le nouveau sous-marin, on utilise la fourche optique en comptant le nombre d'impulsion
	init_external_interrupt();
#endif
}

//Renvoie la position du ballast 1 étalonnée
//Valeur renvoyée entre 0 et 1023 (10bits)
unsigned int get_ballast_position1(void)
{
#ifdef U_BOAT
	return ((((unsigned long)get_value_ADC0() - ADC_VAL_MIN) * 1023) / ADC_DELTA_VAL);
#else
	return (((unsigned long)get_position1() * 1023) / MAX_IMPULSION);
#endif
}

//Renvoie la position du ballast 2 étalonnée
//Valeur renvoyée entre 0 et 1023 (10bits)
unsigned int get_ballast_position2(void)
{
#ifdef U_BOAT
	return ((((unsigned long)get_value_ADC1() - ADC_VAL_MIN) * 1023) / ADC_DELTA_VAL);
#else
	return (((unsigned long)get_position2() * 1023) / MAX_IMPULSION);
#endif
}
