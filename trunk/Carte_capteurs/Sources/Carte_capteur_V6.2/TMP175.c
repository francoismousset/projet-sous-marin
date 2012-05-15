/* TMP175.c */

/**********************************************************************
*
* File name		 : TMP175.c
* Title 		 : Gestion du capteur de temp�rature TI TMP175
* Author 		 : Micha�l Brogniaux - Copyright (C) 2011
* Created		 : 18/03/2012
* Last revised	 : 09/05/2012
* Version		 : 1.1
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include <util/delay.h>
#include "I2Cmaster.h"
#include "main.h"
#include "TMP175.h"
#include "3964r.h"

/*********************************************************************/
// FUNCTION: char initTMP175(unsigned char addr_mode)
// PURPOSE: Initialisation d'un capteur de T� dont l'adresse I2C est sp�cifi�e
unsigned char initTMP175(unsigned char addr_mode)
{
	unsigned char ret;

    ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	/* Si le capteur n'est pas pr�sent sur le bus I2C */
    if ( ret ) // Si le capteur n'est pas pr�sent sur le bus I2C
	{
        i2c_stop();		// Fin de communication sur le bus I2C
    }
	/* Le capteur est pr�sent sur le bus I2C */
	else 
	{
        i2c_write(CONF_REG); 	// Envoyer commande "Configuration register"
        i2c_write(RES_12);  		// Conversion 12 bits 
		i2c_stop();				// Fin de communication sur le bus I2C
		_delay_ms(15);			// D�lais avant de communiquer � nouveau avec le capteur
	}
	return ret;
}

/*********************************************************************/
// FUNCTION: get_TMP175_Devices(unsigned char addr_mode, char *listTemp)
// PURPOSE: Aqu�rir la T� d'un TMP175 dont l'adresse I2C est sp�cifi�e
unsigned char get_TMP175_Devices(unsigned char addr_mode, char *listTemp)
{
	unsigned char ret;
	
	ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	i2c_stop();
	
	if (!ret)
	{
		i2c_start_wait(addr_mode+I2C_WRITE);    	// Start avec adresse capteur + write bit
												// Et attend que le bus soit lib�r�
    	i2c_write(TEMP_REG);  						// Envoyer commande "Read Temperature"
		i2c_rep_start(addr_mode+I2C_READ);        	// Repeated start avec adresse capteur + write bit

		listTemp[0] = i2c_readAck();	// Sauvegarder les bits de poids fort + Acknowledge
		listTemp[1] = i2c_readNak();	// Sauvegarder les bits de poids faible + Not acknowledge

		i2c_stop();							// Fin de communication sur le bus I2C
	}
	else
	{
		listTemp[0] = 0;
		listTemp[1] = 0;
	}
	return ret ; 	
}

