#include "IMPULSE_FUNCTIONS.h"
#include <avr/io.h>

//************ Description des fonctions ************//

//******** TEMPO_0 20ms *********//

void TIMER0_20ms_Init(void)
{
	TCCR0A |= (1<<WGM01);									//Mode CTC du TIMER0
	OCR0A = 160;											//Correspond à 20ms
	TIMSK0 |= (1<<OCIE0A);									//Interruptions on compare match
}

void TIMER0_20ms_Start(void)
{
	TCCR0B |= (1<<CS02)|(1<<CS00);							//Prescaler 1024
}


void TIMER0_20ms_Stop(void)
{
	TCCR0B &= ~(1<<CS02)&~(1<<CS00);						//Stop Tempo
}

//******** TEMPO_2 20ms *********//

void TIMER2_20ms_Init(void)
{
	TCCR2A |= (1<<WGM01);									//Mode CTC du TIMER2
	OCR2A = 160;											//Correspond à 20ms
	TIMSK2 |= (1<<OCIE2A);									//Interruptions on compare match
}

void TIMER2_20ms_Start(void)
{
	TCCR2B |= (1<<CS02)|(1<<CS00);							//Prescaler 1024
}


void TIMER2_20ms_Stop(void)
{
	TCCR2B &= ~(1<<CS02)&~(1<<CS00);						//Stop Tempo
}

//******** PCINTs *********//

void PCINT_Init(void)
{
	EICRA |= (1<<ISC11)|(1<<ISC10)|(1<<ISC01)|(1<<ISC00); 	//Interrupt on INT1 & INT0 on rising edge
}

void PCINT0_ON(void)
{
	EIMSK |= (1<<INT0);										//Autorise interruptions INT0
}

void PCINT1_ON(void)
{
	EIMSK |= (1<<INT1);										//Autorise interruptions INT1
}

void PCINT0_OFF(void)
{
	EIMSK &= ~(1<<INT0);										//Stop interruptions INT0
}

void PCINT1_OFF(void)
{
	EIMSK &= ~(1<<INT1);										//Stop interruptions INT1
}
