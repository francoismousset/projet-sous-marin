/* ADC.h*/

/**********************************************************************
*
* File name		 : ADC.h
* Title 		 : Gestion des ADC
* Author 		 : Benoît Echevin
* Created		 : 07/05/2012
* Last revised	 : 10/05/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

// DEFINITION
#define CHANNEL0 	0x20 // 0010 0000
#define CHANNEL1	0x21 // 0010 0001
#define CHANNEL2	0X22 // 0010 0010
#define CHANNEL3	0x23 // 0010 0011

// FONCTIONS
void InitADC(void);
void ClearFlagADC(void);
void ReadADC(char EnregistrementADC[]);
void StartADC(unsigned char multiplexeur);
