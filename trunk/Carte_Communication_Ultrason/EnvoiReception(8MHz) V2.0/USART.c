/* USART0.c */

/**********************************************************************
*
* File name		 : USART0.c
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/


//INCLUDE
#include "USART.h"
#include "main.h"


//DECLARATION DES VARIABLES GLOGALES
char Rx_Buffer[Rx_Buffer_Size+1];
volatile unsigned char Rx_Wr_Index = 0;
unsigned char Rx_Rd_Index = 0;				//Index de Rx en lecture
volatile unsigned char Rx_Counter = 0;
volatile char Rx_Buffer_Overflow = 0;
volatile char Prime_Interrupt;	

char Tx_Buffer[Tx_Buffer_Size+1];
unsigned char Tx_Wr_Index = 0;
unsigned char Tx_Rd_Index = 0;
unsigned char Tx_Counter = 0;
unsigned char Amorce =0;

int UsartReception =0;

//PROTOTYPE FONCTIONS INTERNES


//CONTENU FONCTIONS EXTERNES

unsigned char USART_RX0( void )
{
	/* Wait for data to be received */
	while ( !(UCSR0A & (1<<RXC0)) );
	/* Get and return received data from buffer */
	return UDR0;
}

void USART_TX0(char data)
{
    // UDRE Flag , is the transmit buffer UDR) ready to receive new data ? 
	// if UDRE = 1 the buffer is empty
	while (!(UCSR0A & (1<<UDRE0)));
	// Put data into buffer, sends the data
    UDR0 = data;
}

void USART_TX0_STRING(char *String)
{
	char Continue = TRUE;
	while (Continue)
	{
		if (*String == 0) Continue = FALSE;
		USART_TX0(*String++);
	}
}

void USART0_Init_9600(void)
{
	// fréquence horloge = 1000000 Mhz, Si Baudrate = 9600 alors UBRR = 12
	// voir explication DS p155
	// 1xspeed  U2X = 1  (voir DS p170)
	UCSR0A |= (1<<U2X0);
	// 9600 baud
	UBRR0 = 103; //259;
		// Configuration en émission / réception (DS p172), on utilise l'interruption en RX
	UCSR0B = (1<<RXCIE0)|(1<<TXCIE0)|(0<<UDRIE0)|(1<<RXEN0)|(1<<TXEN0)|(0<<UCSZ02)|(0<<RXB80)|(0<<TXB80);
	// Async. mode, 8 bits, 1 bit de stop, pas de contrôle de parité (voir DS p172)
   	UCSR0C |= (0<<UMSEL01)|(0<<UMSEL00)|(0<<UPM01)|(0<<UPM00)|(0<<USBS0)|(1<<UCSZ01)|(1<<UCSZ00)|(0<<UCPOL0);
	
}

void Enable_Interrupt_On_RX0(void)
{
	sbiBF(UCSR0B,RXCIE0);
}

void Disable_Interrupt_On_RX0(void)
{
	cbiBF(UCSR0B,RXCIE0);
}

// initialise les buffer usart
void Init_Buffers_USART(void)
{
	unsigned char i;
	for (i = 0; i< Tx_Buffer_Size+1; i++) Tx_Buffer[i] = 0;		// On fait une boucle et toutes les variables à 0
	for (i = 0; i< Rx_Buffer_Size+1; i++) Rx_Buffer[i] = 0;
}

// fonction qui va chercher une valeur dans le buffer rx
char getchar_Buffer(void)
{
	char c=' ';
	//while (Rx_Counter == 0);
	if(Rx_Counter == 0) return(0xFF);
	c = Rx_Buffer[Rx_Rd_Index];
	if (++Rx_Rd_Index > Rx_Buffer_Size) Rx_Rd_Index = 0;
	if (Rx_Counter)
	{
		Rx_Counter--;
	}
	return c;
}

// Ecrire une string dans le buffer (relais activé ou désactivé)
void Buffer_USART_Tx_String(char *String)	
{
	char Continue = TRUE;
	while (Continue)
	{
		if(*String==0) Continue = FALSE;
		else putchar_Buffer(*String++);
	}
}

// mettre un caractère dans le buffer tx
void putchar_Buffer(char c)
{
	char Ammorce = 0;
	while(Tx_Counter > (Tx_Buffer_Size-1));		//Attendre tant que le buffer est rempli
	if (Tx_Counter ==0) Ammorce = 1;			//Si le buffer est vide il fait ammorcer le processus d'interruptions
	Tx_Buffer[Tx_Wr_Index++] = c;	
	if (Tx_Wr_Index > Tx_Buffer_Size) Tx_Wr_Index = 0;
	Tx_Counter++;
	if (Ammorce)
	{
		Prime_Interrupt =1;						// Cette variable va être utilisé dans l'interruption (ammorce est local)						
		UDR0 = c;								// On amorce
	} 
}

/********************/
/*INTERRUPTION*/
/********************/

ISR(USART_RX_vect)  // interruption qui enregistre une nouvelle valeur dans le buffer rx
{
	
	Rx_Buffer[Rx_Wr_Index] = UDR0;
	if (++Rx_Wr_Index > Rx_Buffer_Size) Rx_Wr_Index = 0;
	if (++Rx_Counter > Rx_Buffer_Size)
	{
		Rx_Counter = Rx_Buffer_Size;
		Rx_Buffer_Overflow = 1;
	}
}

ISR(USART_TX_vect) // interruption pour envoyer le caractère suivant du buffer
{
	if(Tx_Counter != 0)
	{
		if(Prime_Interrupt == 1)			// Mise à 1 dans la fonction putchar
		{
			Prime_Interrupt = 0;
			if(++Tx_Rd_Index > Tx_Buffer_Size) Tx_Rd_Index = 0;
			Tx_Counter--;
		}
		if(Tx_Counter != 0)
		{
			UDR0 = Tx_Buffer[Tx_Rd_Index];
			if(++Tx_Rd_Index > Tx_Buffer_Size) Tx_Rd_Index = 0;
			Tx_Counter--;
		}
	}
}
