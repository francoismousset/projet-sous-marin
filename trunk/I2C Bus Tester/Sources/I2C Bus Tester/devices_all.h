/* devices_all.h */

/**********************************************************************
*
* File name		 : devices_all.h
* Title 		 : Gestion de mat�riel connect� sur le bus I2C
* Author 		 : Micha�l Brogniaux - Copyright (C) 2013
* Created		 : 10/03/2013
* Last revised	 : 10/03/2013
* Version		 : 1.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
*
**********************************************************************/

#ifndef devices_all_H
#define devices_all_H

/***** Address of general I2C devices *****/
#define ADD_MIN  	0      			// Low address, 0000000x
#define ADD_MAX  	254     		// High address, 1111111x


/*********************************************************************/
// FUNCTION: void welcomeMsg()
// PURPOSE: Affiche un message de bienvenue sur le terminale
void welcomeMsg();

/*********************************************************************/
// FUNCTION: void init_sensors()
// PURPOSE: Initialise le capteur d'%H et les 8 capteurs de T�
void init_sensors();

/*********************************************************************/
// FUNCTION: char testDevice(unsigned char addr_mode)
// PURPOSE: Teste la connectivit� d'un composant sur le bus I2C
unsigned char testDevice(unsigned char addr_mode);

/*********************************************************************/
// FUNCTION: void init_sensors()
// PURPOSE: D�tecte tous les capteurs connect� sur le bus I2C
void showDetectedSensor(char address);

/*********************************************************************/
// FUNCTION: void detectSensor_cmd(unsigned char dev_test_access)
// PURPOSE: Envoie une commande pour afficher la connectivit� du
//			capteurs I2C dont l'adresse est sp�cifi�e
void detectSensor_cmd(unsigned char dev_test_access);

/*********************************************************************/
// FUNCTION: void detectAllSensors_cmd()
// PURPOSE: Envoie une commande pour d�tecter et afficher la connectivit�
//			 de tous les capteurs connect�s sur le bus I2C
void detectAllSensors_cmd();

/*********************************************************************/
// FUNCTION: void unknown_cmd()
// PURPOSE: Affiche/envoie un message/code d'erreur si commande erron�e
void unknown_cmd();

/*********************************************************************/
// FUNCTION: void debug_cmd()
// PURPOSE: Permet d'activer/d�sactiver le mode de d�bogage(terminale)
void debug_cmd();
/*********************************************************************/
// FUNCTION: void temp_cmd(unsigned char dev_num, char *listTemp)
// PURPOSE: Conversion valeur brute T� en valeur d�cimale/ASCII
void temp_cmd(unsigned char dev_num, char *listTemp);

/*********************************************************************/
// FUNCTION: void hum_cmd(char *listHum)
// PURPOSE: Conversion valeur brute %H en valeur d�cimale/ASCII
void hum_cmd(char *listHum);

/*********************************************************************/
// FUNCTION: void hexaToAscii(unsigned char n)
// PURPOSE: Conversion d'une valeur hexa en ASCII et afficher sur terminale
void hexaToAscii(unsigned char n);

#endif
