/* DS1621.c */

/**********************************************************************
*
* File name		 : DS1621.c
* Title 		 : Gestion du capteur de température Maxim DS1621
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
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
// FUNCTION: char initDS1621(unsigned char addr_mode)
// PURPOSE: Initialisation d'un capteur de T° dont l'adresse I2C est spécifiée
unsigned char initDS1621(unsigned char addr_mode)
{
	unsigned char ret;

    ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	/* Si le capteur n'est pas présent sur le bus I2C */
    if ( ret ) // Si le capteur n'est pas présent sur le bus I2C
	{
        i2c_stop();		// Fin de communication sur le bus I2C
        sbiBF(PORTB,1); // Allumer LED si erreur
    }
	/* Le capteur est présent sur le bus I2C */
	else 
	{
        i2c_write(ACCESS_CFG);  // Envoyer commande "Access Config"
        i2c_write(POL);  		// Envoyer commande "Output polarity active high, continuous conversion" 
		i2c_stop();				// Fin de communication sur le bus I2C
		_delay_ms(15);			// Délais avant de communiquer à nouveau avec le capteur

		i2c_start_wait(addr_mode+I2C_WRITE);    // Start avec adresse capteur + write bit
												// Et attend que le bus soit libéré
		i2c_write(START_CNV);   // Envoyer commande "Start Convert Temp"
		i2c_stop(); 			// Fin de communication sur le bus I2C
		_delay_ms(11);			// Délais avant de communiquer à nouveau avec le capteur
	}
	return ret;
}

/*********************************************************************/
// FUNCTION: get_DS1621_Devices(unsigned char addr_mode, char *listTemp)
// PURPOSE: Aquérir la T° d'un DS1621 dont l'adresse I2C est spécifiée
unsigned char get_DS1621_Devices(unsigned char addr_mode, char *listTemp)
{
	unsigned char ret;
	ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	i2c_stop();	

	if (!ret)/* Si le capteur est présent sur le bus I2C */
	{
		i2c_start_wait(addr_mode+I2C_WRITE);    	// Start avec adresse capteur + write bit

    	i2c_write(RD_TEMP);  						// Envoyer commande "Read Temperature"
		i2c_rep_start(addr_mode+I2C_READ);        	// Repeated start avec adresse capteur + write bit

		listTemp[0] = i2c_readAck();	// Sauvegarder les bits de poids fort + Acknowledge
		listTemp[1] = i2c_readNak();	// Sauvegarder les bits de poids faible + Not acknowledge

		i2c_stop();							// Fin de communication sur le bus I2C

    }
	else/* Le capteur n'est pas présent sur le bus I2C */
	{
		listTemp[0] = 0;				// Mettre à zéro l'octet de poids fort
		listTemp[1] = 0;				// Mettre à zéro l'octet de poids faible
	}
	return ret ;						// Fin de communication sur le bus I2C
}
