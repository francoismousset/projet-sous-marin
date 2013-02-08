/* USART0.h */

/**********************************************************************
*
* File name		 : USART0.h
* Title 		 : COM_ULTRASON
* Author 		 : Benoît Echevin
* Created		 : 29/01/2013
* Last revised	 : 
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega 88
*
**********************************************************************/

#ifndef _USART0_H_
#define _USART0_H_

//INCLUDE
#include <avr/io.h>

//DEFINE
#define Rx_Buffer_Size	100
#define Tx_Buffer_Size	100

//PROTOTYPE FONCTIONS EXTERNES
unsigned char USART_RX0(void);
void USART_TX0(char data);
void USART0_Init_9600(void);
void Enable_Interrupt_On_RX0(void);
void Disable_Interrupt_On_RX0(void);
void USART_TX0_STRING(char *String);
void Init_Buffers_USART(void);
char getchar_Buffer(void);
void putchar_Buffer(char c);
void Buffer_USART_Tx_String(char *String);


#endif /* _USART0_H */
