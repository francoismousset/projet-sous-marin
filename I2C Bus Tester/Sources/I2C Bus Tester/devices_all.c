/* devices_all.c */

/**********************************************************************
*
* File name		 : devices_all.c
* Title 		 : Gestion d'un composant connecté sur le bus I2C
* Author 		 : Michaël Brogniaux - Copyright (C) 2013
* Created		 : 10/03/2013
* Last revised	 : 06/05/2013
* Version		 : 1.0.3
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#include "I2Cmaster.h"
#include "devices_all.h"
#include "uart.h"
#include "car.h"
#include "DS7505.h"
//#include "DS1621.h"
#include "SHT21.h"
#include "gestion_H.h"
#include "gestion_T.h"
#include "main.h"

char debug_mode = FALSE;
static const char HEX_DIGITS[16] = "0123456789ABCDEF";

/*********************************************************************/
// FUNCTION: void welcomeMsg()
// PURPOSE: Affiche un message de bienvenue sur le terminale
void welcomeMsg()
{
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		USART_TX_Msg(MSG_WELCOME);
		USART_TX_Msg(MSG_YEAR);
		USART_TX_CRNL();				// Nouvelle ligne, retour chariot
	}
	else
	asm("nop"); 	// Ne rien faire
}

/*********************************************************************/
// FUNCTION: void init_sensors()
// PURPOSE: Initialise le capteur d'%H et les 8 capteurs de T°
void init_sensors()
{
	unsigned char dev_test_access;

	/***** Capteur T° n°1 *****/
	dev_test_access = initDS7505(ADD1_DS7505);	// Initialiser le capteur de T° n°1
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n1"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n1"CONN_MSG);
		}
	}
	/***** Capteur T° n°2 *****/
	dev_test_access = initDS7505(ADD2_DS7505);	// Initialiser le capteur de T° n°2
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n2"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n2"CONN_MSG);
		}
	}
	/***** Capteur T° n°3 *****/
	dev_test_access = initDS7505(ADD3_DS7505);	// Initialiser le capteur de T° n°3
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n3"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n3"CONN_MSG);
		}
	}
	/***** Capteur T° n°4 *****/
	dev_test_access = initDS7505(ADD4_DS7505);	// Initialiser le capteur de T° n°4
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n4"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n4"CONN_MSG);
		}
	}
	/***** Capteur T° n°5 *****/
	dev_test_access = initDS7505(ADD5_DS7505);	// Initialiser le capteur de T° n°5
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n5"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n5"CONN_MSG);
		}
	}
	/***** Capteur T° n°6 *****/
	dev_test_access = initDS7505(ADD6_DS7505);	// Initialiser le capteur de T° n°6
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n6"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n6"CONN_MSG);
		}
	}
	/***** Capteur T° n°7 *****/
	dev_test_access = initDS7505(ADD7_DS7505);	// Initialiser le capteur de T° n°7
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n7"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n7"CONN_MSG);
		}
	}
	/***** Capteur T° n°8 *****/
	dev_test_access = initDS7505(ADD8_DS7505);	// Initialiser le capteur de T° n°8
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("DS7505 n8"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("DS7505 n8"CONN_MSG);
		}
	}
	/***** Capteur %H n°1 *****/
	dev_test_access = initSHT21(ADD1_SHT21);
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_Msg("SHT21"ERROR_MSG);
		}
		else
		{
			USART_TX_Msg("SHT21"CONN_MSG);
		}
	}

	/*
	dev1_DS1621_access = initDS1621(ADD1_DS1621);
	if(dev1_DS1621_access)
	{
		USART_TX_Msg("DS1621 n1"ERROR_MSG);
	}
	else
	{
		USART_TX_Msg("DS1621 n1"CONN_MSG);
	} */
}

/*********************************************************************/
// FUNCTION: char testDevice(unsigned char addr_mode)
// PURPOSE: Teste la connectivité d'un composant sur le bus I2C
unsigned char testDevice(unsigned char addr_mode)
{
	unsigned char ret;

    ret = i2c_start(addr_mode+I2C_WRITE);       // Start avec adresse capteur + write bit
	/* Si le capteur n'est pas présent sur le bus I2C */
	i2c_stop();		// Fin de communication sur le bus I2C
 
	return ret;
}
/*********************************************************************/
// FUNCTION: void init_sensors()
// PURPOSE: Affiche tous les capteurs connecté sur le bus I2C
void showDetectedSensor(char address)
{
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		USART_TX_String(" Sensor found at address ");	
		hexaToAscii(address);
		USART_TX_CRNL();				// Nouvelle ligne, retour chariot
	}
	else
	{
		USART_Transmit(STX);
		USART_Transmit(1); // Longueur octet données utiles
		USART_Transmit(address); // Renvoie l'adresse du capteur détecté				
		USART_Transmit(ETX);
	}
}

/*********************************************************************/
// FUNCTION: void detectSensor_cmd(unsigned char dev_test_access)
// PURPOSE: Envoie une commande pour afficher la connectivité du
//			capteurs I2C dont l'adresse est spécifiée
void detectSensor_cmd(unsigned char dev_test_access)
{
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		if(dev_test_access)
		{
			USART_TX_String(" Sensor not connected !!! ");	
			USART_TX_CRNL();				// Nouvelle ligne, retour chariot
		}
		else
		{
			USART_TX_String(" Sensor connected. ");	
			USART_TX_CRNL();				// Nouvelle ligne, retour chariot
		}
	}
	else
	{
		if(dev_test_access)
		{
			USART_Transmit(0xFF); // Correspond à un problème d'accès
		}
		else
		{
			USART_Transmit(0xFE); // Aucun problème d'accès
		}
	}
}

/*********************************************************************/
// FUNCTION: void detectAllSensors_cmd()
// PURPOSE: Envoie une commande pour détecter et afficher la connectivité
//			 de tous les capteurs connectés sur le bus I2C
void detectAllSensors_cmd()
{
	unsigned char dev_test_access;
	char add;
	if (debug_mode) USART_TX_Msg(" --- Beginning of sensor detection --- ");
	for (add=ADD_MIN; add<ADD_MAX; add+=2)
	{		
		dev_test_access = testDevice(add);
		if(!dev_test_access)
		{
			showDetectedSensor(add);
		}
	}
	if (debug_mode) USART_TX_Msg(" --- End of sensor detection --- ");
}

/*********************************************************************/
// FUNCTION: void unknown_cmd()
// PURPOSE: Affiche/envoie un message/code d'erreur si commande erronée
void unknown_cmd()
{
	if(debug_mode) // Afficher msgs si debug mode activé
	{
		// Msg afficher si commade inconnue
		USART_TX_Msg(" Unknown command ! ");
	}	
	else
	{	
		USART_Transmit(0x00); // Code retourné si commande inconnue
	}
}

/*********************************************************************/
// FUNCTION: void debug_cmd()
// PURPOSE: Permet d'activer/désactiver le mode de débogage(terminale)
void debug_cmd()
{
	if(debug_mode)
	{
		debug_mode = FALSE;
	}
	else
	{
		debug_mode = TRUE;
		welcomeMsg();					// Afficher le message de bienvenue
		init_sensors();
	}
}

/*********************************************************************/
// FUNCTION: void temp_cmd(unsigned char dev_num, char *listTemp)
// PURPOSE: Conversion valeur brute T° en valeur décimale/ASCII
void temp_cmd(unsigned char dev_num, char *listTemp, char command, char dev_access)
{
	char tempResult[2], tempStr[5];

	convertTemp(listTemp, tempResult); // Convertir les données brutes en données exploitables

	if(debug_mode) // Afficher msgs si debug mode activé
	{
			stringTemp(tempResult, tempStr); // Convertir la T° sous forme d'entiers en caractères

		USART_Transmit('T');
		USART_Transmit(DEG_CAR);
		USART_TX_String("C Sensor ");
		USART_Transmit(dev_num+48);
		USART_TX_String(" : ");
		USART_Transmit(tempStr[0]);
		USART_Transmit(tempStr[1]);	
		USART_Transmit(tempStr[2]);	
		USART_Transmit(DOT_CAR);
		USART_Transmit(tempStr[3]);	
		USART_Transmit(tempStr[4]);
		USART_TX_CRNL();				// Nouvelle ligne, retour chariot
	}
	else
	{	
		if(dev_access)
		{
			tempResult[0] = 0xFF;
			tempResult[1] = 0xFF;
		}
		else
		{
			asm("nop");
		}
		USART_Transmit(STX);
		USART_Transmit(3); // Longueur octet données utiles
		USART_Transmit(command);
		USART_Transmit(tempResult[0]);
		USART_Transmit(tempResult[1]);
		USART_Transmit(ETX);
	}

	listTemp[0] = 0;				// Reset mém tampon T° mesurée
	listTemp[1] = 0;
}

/*********************************************************************/
// FUNCTION: void hum_cmd(char *listHum)
// PURPOSE: Conversion valeur brute %H en valeur décimale/ASCII
void hum_cmd(char *listHum, char command, char dev_access)
{
	char humResult, humStr[2], hum2;
	/*
	if(!dev_access)
	{
		humResult = convertHum(listHum);// Convertir les données brutes en données exploitables
		hum2 = 0x00;
	}
	else
	{
		humResult = 0xFF;
		hum2 = 0xFF;
	}*/
	humResult = convertHum(listHum);// Convertir les données brutes en données exploitables

	if(debug_mode) // Afficher msgs si debug mode activé
	{
		stringHum(humResult, humStr);

		USART_Transmit(PERCENT_CAR);
		USART_Transmit('H');
		USART_TX_String(" Sensor : ");
		USART_Transmit(humStr[0]);
		USART_Transmit(humStr[1]);	
		USART_TX_CRNL();				// Nouvelle ligne, retour chariot
	}
	else
	{	
		if(dev_access)
		{
			humResult = 0xFF;
			hum2 = 0xFF;
		}
		else
		{
			hum2 = 0x00;
		}
		USART_Transmit(STX);
		USART_Transmit(3); // Longueur octet données utiles
		USART_Transmit(command);
		USART_Transmit(humResult);
		USART_Transmit(hum2);
		USART_Transmit(ETX);
	}
			
	listHum[0] = 0;					// Reset mém %H mesurée
	listHum[1] = 0;
	listHum[2] = 0;		
}

/*********************************************************************/
// FUNCTION: void hexaToAscii(unsigned char n)
// PURPOSE: Conversion d'une valeur hexa en ASCII et afficher sur terminale
void hexaToAscii(unsigned char n)
{
	char tmp[3];
	int i;

	// Convert the given number to an ASCII hexadecimal representation.
	tmp[2] = '\0';
	for (i = 1; i >= 0; i--)
	{
	tmp[i] = HEX_DIGITS[n & 0xF];
	n >>= 4;
	}
	// Transmit the resulting string with the given USART.
	USART_TX_String(tmp);
}
