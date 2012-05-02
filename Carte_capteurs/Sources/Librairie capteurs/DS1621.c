/* DS1621.c */

/**********************************************************************
*
* File name		 : DS1621.c
* Title 		 : Gestion du capteur de temp�rature Maxim DS1621
* Author 		 : Micha�l Brogniaux - Copyright (C) 2011
* Created		 : 07/03/2012
* Last revised	 : 08/03/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include <util/delay.h>
#include "I2Cmaster.h"
#include "main.h"
#include "DS1621.h"

/*********************************************************************/
// FUNCTION: char initDS1631(unsigned char addr_mode)
// PURPOSE: Initialisation d'un capteur de T� dont l'adresse I2C est sp�cifi�e
unsigned char initDS1631(unsigned char addr_mode)
{
	unsigned char ret;

    ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	/* Si le capteur n'est pas pr�sent sur le bus I2C */
    if ( ret ) // Si le capteur n'est pas pr�sent sur le bus I2C
	{
        i2c_stop();		// Fin de communication sur le bus I2C
        sbiBF(PORTB,1); // Allumer LED si erreur
    }
	/* Le capteur est pr�sent sur le bus I2C */
	else 
	{
        i2c_write(ACCESS_CFG);  // Envoyer commande "Access Config"
        i2c_write(POL);  		// Envoyer commande "Output polarity active high, continuous conversion" 
		i2c_stop();				// Fin de communication sur le bus I2C
		_delay_ms(15);			// D�lais avant de communiquer � nouveau avec le capteur

		i2c_start_wait(addr_mode+I2C_WRITE);    // Start avec adresse capteur + write bit
												// Et attend que le bus soit lib�r�
		i2c_write(START_CNV);   // Envoyer commande "Start Convert Temp"
		i2c_stop(); 			// Fin de communication sur le bus I2C
		_delay_ms(11);			// D�lais avant de communiquer � nouveau avec le capteur
	}
	return ret;
}

/*********************************************************************/
// FUNCTION: get_DS1631_Devices(unsigned char addr_mode, char *listTemp)
// PURPOSE: Aqu�rir la T� d'un DS1621 dont l'adresse I2C est sp�cifi�e
void get_DS1631_Devices(unsigned char addr_mode, char *listTemp)
{
    i2c_start_wait(addr_mode+I2C_WRITE);    	// Start avec adresse capteur + write bit
												// Et attend que le bus soit lib�r�
    i2c_write(RD_TEMP);  		// Envoyer commande "Read Temperature"
	i2c_rep_start(addr_mode+I2C_READ);        	// Repeated start avec adresse capteur + write bit

	if(addr_mode == ADD1_DS1621)		// Si il s'agit du capteur de T� n�1
	{
		listTemp[0] = i2c_readAck();	// Sauvegarder les bits de poids fort + Acknowledge
		listTemp[1] = i2c_readNak();	// Sauvegarder les bits de poids faible + Not acknowledge
	}
	else if (addr_mode == ADD2_DS1621)  // Si il s'agit du capteur de T� n�2
	{
		listTemp[2] = i2c_readAck();	// Sauvegarder les bits de poids fort + Acknowledge
		listTemp[3] = i2c_readNak();	// Sauvegarder les bits de poids faible + Not acknowledge
	}
	else if (addr_mode == ADD3_DS1621)	// Si il s'agit du capteur de T� n�3
	{
		listTemp[4] = i2c_readAck();	// Sauvegarder les bits de poids fort + Acknowledge
		listTemp[5] = i2c_readNak();	// Sauvegarder les bits de poids faible + Not acknowledge
	}
	else
	{	
		asm("nop"); 					// Ne rien faire en cas d'erreur
	}
    i2c_stop();							// Fin de communication sur le bus I2C
}
