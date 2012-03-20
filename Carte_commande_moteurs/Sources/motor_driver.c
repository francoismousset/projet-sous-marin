/****************************************************************
 *																*
 *	FileName :		motor_driver.c								*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		18/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

/*
Description des IO
-------------------
FC11 -> PB1 (IN)
FC12 -> PB2 (IN)
FC21 -> PB6 (IN)
FC22 -> PB7 (IN)

INAB1 -> PC2 (OUT)
INAB2 -> PC3 (OUT)

ENAB1 -> PD4 (OUT)
ENAB2 -> PD7 (OUT)
*/

#include "motor_driver.h"

//Constante DEBUG_MOTOR à décommenter pour compiler motor_driver en mode DEBUG
//Le mode DEBUG_MOTOR permet de visualiser le changement d'état des fins de course
//#define DEBUG_MOTOR
#ifdef DEBUG_MOTOR
#include "usart.h"
#endif

//Fonction privée
//Initialisation des registres pour les IO avec la carte de driver moteur
void init_io(void);

//Variables d'états des fins de course
volatile unsigned char fc11 = FALSE;
volatile unsigned char fc12 = FALSE;
volatile unsigned char fc21 = FALSE;
volatile unsigned char fc22 = FALSE;

//Variable de sauvegarde de l'état précédent de PINB
volatile unsigned char prev_PINB;

void init_motor_driver(void)
{
	init_io();
	init_pwm();

	//Moteur 1 = Déplacement du ballast
	//Moteur 2 = Remplissage ballast

	//Vide les ballasts à l'allumage ou après perte d'alimentation
	enable_motor1(TRUE);
	enable_motor2(TRUE);
	rotation_motor1(COUNTERCLOCKWISE);		//Déplacement ballast vers Alim
	//rotation_motor2(COUNTERCLOCKWISE);	//Remplissage ballast
	rotation_motor2(CLOCKWISE);				//Vidage ballast
	set_speed_motor1(255);
	set_speed_motor2(255);

	//Activation des interruptions
//	sei();
	//Attend les ballasts soit vides

//	while((fc11 == FALSE) || (fc21 == FALSE)); //A décommenter en reel !
// 	OU
//	while((fc12 != FALSE) || (fc22 != FALSE)); //A décommenter en reel !

	//while(fc22 != FALSE); //Fin de course Moteur 'M' vidage ballast
	//Désactivation des interruptions
//	cli();

	_delay_ms(10000);
	_delay_ms(10000);

	set_speed_motor1(0);
	rotation_motor1(CLOCKWISE);	//Déplacement ballast vers Foxboard
	_delay_ms(1000);
	set_speed_motor1(255);

	_delay_ms(7700);
	enable_motor1(FALSE);

	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(10000);
	_delay_ms(5000);


	//Désactivation de la sortie des moteurs
	enable_motor2(FALSE);

	//Mise à 0 de la vitesse des moteurs
	set_speed_motor1(0);
	set_speed_motor2(0);
}

void init_io(void)
{
	//OUT : enable motor
	DDRD |= (1<<DDD4) | (1<<DDD7);

	//OUT : Rotation motor
	DDRC |= (1<<DDC2) | (1<<DDC3);

	//IN  : FC motor (Sur interruption PCINT0)
	PCMSK0 |= (1<<PCINT1) | (1<<PCINT2) | (1<<PCINT6) | (1<<PCINT7);
	PCICR |= (1<<PCIE0);

	//Initialisation des fins de course
	if((PINB & 0b00000010) != 0b00000010)
		fc11 = TRUE;
	if((PINB & 0b00000100) != 0b00000100)
		fc12 = TRUE;
	if((PINB & 0b01000000) != 0b01000000)
		fc21 = TRUE;
	if((PINB & 0b10000000) != 0b10000000)
		fc22 = TRUE;

	prev_PINB = PINB;
}

//Fonction d'activation du moteur 1
//Paramètre : TRUE ou FALSE
void enable_motor1(unsigned char value)
{
	if(value == TRUE)
		PORTD |= (1<<PORTD4);
	else
		PORTD &= 0b11101111;
}

//Fonction d'activation du moteur 2
//Paramètre : TRUE ou FALSE
void enable_motor2(unsigned char value)
{
	if(value == TRUE)
		PORTD |= (1<<PORTD7);	
	else
		PORTD &= 0b01111111;
}

//Fonction pour définir le sens de rotation du moteur 1
//Paramètre : CLOCKWISE OU COUNTERCLOCKWISE
void rotation_motor1(unsigned char value)
{
	if(value == CLOCKWISE)
		PORTC |= (1<<PORTC2);
	else
		PORTC &= 0b11111011;
}

//Fonction pour définir le sens de rotation du moteur 2
//Paramètre : CLOCKWISE OU COUNTERCLOCKWISE
void rotation_motor2(unsigned char value)
{
	if(value == CLOCKWISE)
		PORTC |= (1<<PORTC3);
	else
		PORTC &= 0b11110111;
}

//Fonction pour obtenir le sens de rotation du moteur 1
//Utile pour incrémenter ou décrémenter la position du ballast en fonction des impulsions
unsigned char get_rotation_motor1(void)
{
	if((PORTC & 0b00000100) == 0b00000100)
		return CLOCKWISE;
	else
		return COUNTERCLOCKWISE;
}

//Fonction pour obtenir le sens de rotation du moteur 2
//Utile pour incrémenter ou décrémenter la position du ballast en fonction des impulsions
unsigned char get_rotation_motor2(void)
{
	if((PORTC & 0b00001000) == 0b00001000)
		return CLOCKWISE;
	else
		return COUNTERCLOCKWISE;
}

//Fonction pour définir la vitesse du moteur 1
//Paramètres : duty_cycle de 0 à 255
void set_speed_motor1(unsigned char duty_cycle)
{
	OCR0A = duty_cycle;
}

//Fonction pour définir la vitesse du moteur 2
//Paramètres : duty_cycle de 0 à 255
void set_speed_motor2(unsigned char duty_cycle)
{
	OCR0B = duty_cycle;
}

//Interruption pour la detection des fins de course
ISR(PCINT0_vect)
{
	//Détermine les changements d'états sur les entrées du PORTB
	switch(prev_PINB ^ PINB)
	{
		//Fin de course fc11 actionné
		case 0b00000010 :
			if(((PINB & 0b00000010) != 0b00000010) && (fc11 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc11 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc11 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc11 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc11 = FALSE;
			}
			break;

		//Fin de course fc12 actionné
		case 0b00000100 :
			
			if(((PINB & 0b00000100) != 0b00000100) && (fc12 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc12 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc12 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc12 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc12 = FALSE;
			}
			break;

		//Fin de course fc21 actionné
		case 0b01000000 :
			if(((PINB & 0b01000000) != 0b01000000) && (fc21 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc21 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc21 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc21 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc21 = FALSE;
			}
			break;

		//Fin de course fc22 actionné
		case 0b10000000 :
			if(((PINB & 0b10000000) != 0b10000000) && (fc22 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc22 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc22 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc22 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc22 = FALSE;
			}
			break;

		//Fin de course fc11 et fc22 actionnés en même temps
		case 0b10000010 :
			if(((PINB & 0b00000010) != 0b00000010) && (fc11 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc11 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc11 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc11 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc11 = FALSE;
			}

			if(((PINB & 0b10000000) != 0b10000000) && (fc22 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc22 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc22 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc22 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc22 = FALSE;
			}
			break;

		//Fin de course fc11 et fc21 actionnés en même temps
		case 0b01000010 :
			if(((PINB & 0b00000010) != 0b00000010) && (fc11 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc11 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc11 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc11 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc11 = FALSE;
			}

			if(((PINB & 0b01000000) != 0b01000000) && (fc21 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc21 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc21 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc21 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc21 = FALSE;
			}
			break;

		//Fin de course fc21 et fc12 actionnés en même temps
		case 0b01000100 :
			if(((PINB & 0b01000000) != 0b01000000) && (fc21 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc21 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc21 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc21 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc21 = FALSE;
			}

			if(((PINB & 0b00000100) != 0b00000100) && (fc12 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc12 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc12 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc12 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc12 = FALSE;
			}
			break;

		//Fin de course fc12 et fc22 actionnés en même temps
		case 0b10000100 :
			if(((PINB & 0b00000100) != 0b00000100) && (fc12 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc12 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc12 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc12 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc12 = FALSE;
			}

			if(((PINB & 0b10000000) != 0b10000000) && (fc22 == FALSE))
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc22 = TRUE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc22 = TRUE;
			}
			else
			{
#ifdef DEBUG_MOTOR
				puts_usart("fc22 = FALSE");
				putchar_usart(0x0d);
				putchar_usart(0x0a);
#endif
				fc22 = FALSE;
			}
			break;
	}
	prev_PINB = PINB;
}
