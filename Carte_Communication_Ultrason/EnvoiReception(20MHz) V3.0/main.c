/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin & Philippe Wauthy
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

/********************/
// INCLUDE
/********************/

#include "main.h"

/********************/
// VARIABLES
/********************/

unsigned char Receiving = OFF;
unsigned char Need_Receiving = OFF;
unsigned char Sending = OFF;
unsigned char Data_Received[11]="";
unsigned char Compteur_Data_Received = 0;
unsigned char Compteur_Timer = 0;
extern volatile unsigned char Rx_Counter;
unsigned int valeurf1 = 222;
unsigned int valeurf2 = 284;
unsigned char tableau [8] = {0};
unsigned char c = ' ';
unsigned char Index = 0;
volatile unsigned char RX600INTREQUEST=OFF;
volatile unsigned char TX600INTREQUEST=OFF;
unsigned char data;

/********************/
// MAIN FUNCTION
/********************/

int main(void)
{
	unsigned char k;
	init();
	Buffer_USART_Tx_String("End Init \r");
	while(1)
	{		
		if(Need_Receiving==ON)
		{
			if( ((PINC)&(1<<PINC0))==0 )
			{
				if(Receiving==OFF && Compteur_Data_Received!=10)
				{
					Receiving = ON;	// indique que la récéption est en cour
					Compteur_Timer = 0;
					TIMER0_START();	// Lance le timer0 
				}
				else asm("nop");
			}
			else asm("nop");	
			Need_Receiving=OFF;	
		}
		if(RX600INTREQUEST==ON)
		{
			Received_600_baud(); // permet de gérer le nombre d'incrémentation du timer 0 en mode de réception de donnée
			RX600INTREQUEST=OFF;
		}
		if(TX600INTREQUEST==ON)
		{
			Send_600_baud(); // permet de gérer le nombre d'incrémentation du timer 0 en mode d'envoi de donnée
			TX600INTREQUEST=OFF;
		}
		if(Compteur_Data_Received != 0) 
		{
			putchar_Buffer(Data_Received[0]);
			for(k=0;k<=10;k++) 
			{
				Data_Received[k]=Data_Received[k+1];
			}
			Data_Received[10]=0x00;
			Compteur_Data_Received--;
		}
		if (Rx_Counter != 0 && Sending == 0)
		{
			c = getchar_Buffer ();
			chartobit (c, tableau);
			
			Sending = ON;
			TCNT2 = 0;

			OCR1A = valeurf2;
			TIMER2_START();
			Index = 0;
			cbiBF (PORTB, PINB0);
		}
	}
}

/********************/
// INTERRUPTS
/********************/

// Interruption lors d'un changement de niveau sur le port d'entrée
ISR(PCINT1_vect)
{
	if((Receiving==OFF) && (((PINC)&(1<<PINC0))==0) ) Need_Receiving=ON;
}

// Interruption à la fin du timer
ISR(TIMER0_COMPA_vect)
{
	if(Receiving == ON) RX600INTREQUEST=ON;
	else asm("nop");
}

// Anti-rebond : masque PCIE2 retiré pendant 26 ms
ISR (TIMER2_COMPA_vect)			
{
	if (Sending == ON) TX600INTREQUEST=ON;
	else asm("nop");
}

/********************/
// FUNCTIONS
/********************/

// Fonction d'initialisation
void init(void)
{
	unsigned char i;
	for(i=0;i<=5;i++) Data_Received[i] = 0x00;

	cli();							// Désactiver toutes les interruptions

	DDRD = 0b10000110;				// config pour BP1 2 3 et 4 (BP = bouton poussoir)
	sbiBF (PORTD, PORTD3);			// BP0
	sbiBF (PORTD, PORTD4);			// BP1
	sbiBF (PORTD, PORTD5);			// BP2
	sbiBF (PORTD, PORTD6);			// BP3
	sDDR(DDRD,1);					// mettre port TX en sortie
	sbiBF(PORTD,0); 				// mettre pull-up sur RX
	sbiBF(PORTC,0); 				// mettre pull-up sur RX
	sDDR(DDRC,1); 					// mettre port en sortie
	DDRB = 0b00111111;  			// PORTB.6et7 en entrée (quartz)
	sbiBF (PORTB, PINB0);				// communication usart à 600baud non modulé

	USART0_Init_9600();				// initialise le port série 
	Init_Buffers_USART ();			// initialise les buffers de la communication série

	init_pcint();					// initialise les interruptions externes

	TIMER0_INIT();					// initialise le timer 0
	TIMER1_INIT ();					// initialiser le timer 1
	TIMER2_INIT ();					// initialiser le timer 2

	sei();
}

// conversion d'un caractère en tableau avec les valeurs des bits de ce caractère
void chartobit (unsigned char car, volatile unsigned char tab [])
{
    int i = 0;
    
    if ((car & 0x80))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x40))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x20))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x10))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x08))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x04))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x02))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
    if ((car & 0x01))
    {
        tab [7-i] = 1;
    }
    else
    {
        tab [7-i] = 0;
    }
    i++;
}
