/* SHT21.c */

/**********************************************************************
*
* File name		 : SHT21.c
* Title 		 : Gestion du capteur d'humidité SHT21
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 30/03/2012
* Last revised	 : 30/03/2012
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include <util/delay.h>
#include "I2Cmaster.h"
#include "main.h"
#include "SHT21.h"

/*********************************************************************/
// FUNCTION: char initSHT21(unsigned char addr_mode)
// PURPOSE: Initialisation d'un capteur de T° dont l'adresse I2C est spécifiée
unsigned char initSHT21(unsigned char addr_mode)
{
	unsigned char ret;

    ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	/* Si le capteur n'est pas présent sur le bus I2C */
    if ( ret ) // Si le capteur n'est pas présent sur le bus I2C
	{
        i2c_stop();		// Fin de communication sur le bus I2C
    }
	/* Le capteur est présent sur le bus I2C */
	else 
	{
        i2c_write(W_USER_REG); 	// Envoyer commande "Write user register"
        i2c_write(RES_RH_10);  	// Conversion 10 bits 
		i2c_stop();				// Fin de communication sur le bus I2C
		_delay_ms(15);			// Délais avant de communiquer à nouveau avec le capteur
	}
	return ret;
}

/*********************************************************************/
// FUNCTION: get_SHT21_Devices(unsigned char addr_mode, char *listHum)
// PURPOSE: Aquérir la T° d'un SHT21 dont l'adresse I2C est spécifiée
void get_SHT21_Devices(unsigned char addr_mode, char *listHum)
{
    i2c_start_wait(addr_mode+I2C_WRITE);    	// Start avec adresse capteur + write bit
												// Et attend que le bus soit libéré
    i2c_write(TRIG_T);  						// Envoyer commande "Trigger Temperature measurement (hold master)"
	i2c_rep_start(addr_mode+I2C_READ);        	// Repeated start avec adresse capteur + write bit
	
	// Attente la fin de la conversion A/D, selon la résolution
	if(addr_mode == RES_RH_8)
	{	
		_delay_ms(5);
	}
	else if(addr_mode == RES_RH_10)
	{
		_delay_ms(10);
	}
	else if(addr_mode == RES_RH_11)
	{
		_delay_ms(16);
	}
	else if(addr_mode == RES_RH_12)
	{
		_delay_ms(30);
	}
	else
	{	
		asm("nop"); 					// Ne rien faire en cas d'erreur
	}
	

	if(addr_mode == ADD1_SHT21)		// Si il s'agit du capteur RH n°1
	{
		listHum[0] = i2c_readAck();	// Sauvegarder les bits de poids fort + Acknowledge
		listHum[1] = i2c_readAck();	// Sauvegarder les bits de poids faible + Not acknowledge
		listHum[2] = i2c_readNak(); // CRC checksum
	}
	else
	{	
		asm("nop"); 					// Ne rien faire en cas d'erreur
	}
    i2c_stop();							// Fin de communication sur le bus I2C
}                                                                                                                                                      
