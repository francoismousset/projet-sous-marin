/* COM_600_BAUD.c */

/**********************************************************************
*
* File name		 : COM_600_BAUD.c
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
#include "COM_600_BAUD.h"
#include "main.h"
#include "TIMER.h"

// VARIABLES
extern unsigned char Compteur_Timer;
unsigned char nbreappel = 0; 
extern unsigned char Sending;
	
unsigned char test;
unsigned char Data_com[8]="";
unsigned char Data_Result=0;
extern unsigned char Index;
extern volatile unsigned char tableau [8];
extern volatile unsigned int valeurf1;
extern volatile unsigned int valeurf2;
extern unsigned char Receiving;
extern unsigned char Data_Received[11];
extern unsigned char Compteur_Data_Received;
unsigned char Receiv_Statut=0;
unsigned char Compteur_Bit=0;
unsigned char Data_Verif[3]="";

// FUNCTIONS

// Permet la réception d'un octet sur PINC0. le nombre de baud dépend de COMSPEED (voir .h)
void Received_600_baud(void)
{
	Compteur_Timer++;
	/********** START BIT **********/
	if(Receiv_Statut==0 || Receiv_Statut==1 || Receiv_Statut==2)
	{
		if(Compteur_Timer==COMSPEED) 
		{
			Compteur_Timer=0;
			Receiv_Statut++;
			Compteur_Bit=0;
			if(((PINC)&(1<<PINC0))!=0)
			{
	 			TIMER0_STOP();
				Receiving=OFF;
				return;
			}
			else asm("nop");
		}
		else asm("nop");
	}

	/********** DATA **********/
	else if(Receiv_Statut==3)
	{
		if(Compteur_Timer==COMSPEEED)
		{
			Compteur_Timer=0;
			Receiv_Statut++;
			if(((PINC)&(1<<PINC0))==0) Data_Verif[0]=0;
			else Data_Verif[0]=1;
		}
	}
	else if(Receiv_Statut==4)
	{
		if(Compteur_Timer==COMSPEED)
		{
			Compteur_Timer=0;
			Receiv_Statut++;
			if(((PINC)&(1<<PINC0))==0) Data_Verif[1]=0;
			else Data_Verif[1]=1;
		}
	}
	else if(Receiv_Statut==5)
	{
		if(Compteur_Timer==COMSPEED)
		{
			Compteur_Timer=0;
			Receiv_Statut++;
			if(((PINC)&(1<<PINC0))==0) Data_Verif[2]=0;
			else Data_Verif[2]=1;
		}
	}
	else asm("nop");
	if(Receiv_Statut==6)
	{
		// Vérification de la valeur du bit et inscription dans le tableau DATA[]
		if(((Data_Verif[0]==0)&&(Data_Verif[1]==0))||((Data_Verif[1]==0)&&(Data_Verif[2]==0))||((Data_Verif[2]==0)&&(Data_Verif[0]==0)))
		{
			Data_com[Compteur_Bit]=0;
		}
		else Data_com[Compteur_Bit]=1;
		// Augmentation du compteur du nombre de bit déjà acquis
		Compteur_Bit++;
		if(Compteur_Bit!=8) Receiv_Statut = 3;
		else Receiv_Statut++;
	}

	/********** STOP BIT **********/
	if(Receiv_Statut==7)
	{
		if(Compteur_Timer==COMSPEEED) 
		{
			Compteur_Timer=0;
			Receiv_Statut++;
			if(((PINC)&(1<<PINC0))==0)
			{
	 			TIMER0_STOP();
				Receiving=OFF;
				return; 
			}
			else asm("nop");
		}
		else asm("nop");
	}
	else if(Receiv_Statut==8 || Receiv_Statut==9)
	{
		if(Compteur_Timer==COMSPEED) 
		{
			Compteur_Timer=0;
			Receiv_Statut++;
			if(((PINC)&(1<<PINC0))==0)
			{
	 			TIMER0_STOP();
				Receiving=OFF;
				return;
			}
			else asm("nop");
		}
		else asm("nop");
	}
	else asm("nop");

	/********** MISE EN FORME, ARRET DU TIMER ET RETOUR **********/
	if(Receiv_Statut==10)
	{
		TIMER0_STOP();
		Data_Result=0;
		if(Data_com[7]==1) Data_Result=Data_Result+128;
		if(Data_com[6]==1) Data_Result=Data_Result+64;
		if(Data_com[5]==1) Data_Result=Data_Result+32;
		if(Data_com[4]==1) Data_Result=Data_Result+16;
		if(Data_com[3]==1) Data_Result=Data_Result+8;
		if(Data_com[2]==1) Data_Result=Data_Result+4;
		if(Data_com[1]==1) Data_Result=Data_Result+2;
		if(Data_com[0]==1) Data_Result=Data_Result+1;
		Receiving=OFF;
		Data_Received[Compteur_Data_Received]=Data_Result;
		Compteur_Data_Received++;
		Receiv_Statut=0;
		return;
	}
	else return;	
}


// Fonction de test qui retourne une valeur
unsigned char com_test(void)
{
	Compteur_Timer = 0;
	TIMER0_START();	// Lance le timer0 
	do
	{
		asm("nop");
	}while(Compteur_Timer!=COMSPEED);
	TIMER0_STOP();
	test++;
	if(test==1) return(0x01);
	else if (test==2) return(0x02);
	else if (test==4) return(0x04);
	else if (test==5) return(0x05);
	else if (test==6) return(0x06);
	else if (test==8) return(0x08);
	else return(0xFF);
}


// permet l'envoi à 600 baud
void Send_600_baud(void)
{
	nbreappel ++;
	if (nbreappel == COMSP && Index <=7)
	{
		if (tableau[Index] == 0)
		{
			OCR1A = valeurf2;
			cbiBF (PORTB, PINB0);
		}
		else
		{
			OCR1A = valeurf1;
			sbiBF (PORTB, PINB0);
		}
		Index ++;
		nbreappel = 0;
	}
	if (nbreappel == COMSP && Index == 8)
	{
		OCR1A = valeurf1;
		sbiBF (PORTB, PINB0);
		Index ++;
		nbreappel = 0;
	}
	if (nbreappel == COMSPD && Index == 9)
	{
		Index = 0;
		Sending = OFF;
		nbreappel = 0;
		TIMER2_STOP();
	}
}
