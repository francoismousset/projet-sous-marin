/* devices_all.h */

/**********************************************************************
*
* File name		 : devices_all.h
* Title 		 : Gestion de matériel connecté sur le bus I2C
* Author 		 : Michaël Brogniaux - Copyright (C) 2013
* Created		 : 10/03/2013
* Last revised	 : 18/03/2013
* Version		 : 1.0.2
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
// PURPOSE: Initialise le capteur d'%H et les 8 capteurs de T°
void init_sensors();

/*********************************************************************/
// FUNCTION: char testDevice(unsigned char addr_mode)
// PURPOSE: Teste la connectivité d'un composant sur le bus I2C
unsigned char testDevice(unsigned char addr_mode);

/*********************************************************************/
// FUNCTION: void init_sensors()
// PURPOSE: Détecte tous les capteurs connecté sur le bus I2C
void showDetectedSensor(char address);

/*********************************************************************/
// FUNCTION: void detectSensor_cmd(unsigned char dev_test_access)
// PURPOSE: Envoie une commande pour afficher la connectivité du
//			capteurs I2C dont l'adresse est spécifiée
void detectSensor_cmd(unsigned char dev_test_access);

/*********************************************************************/
// FUNCTION: void detectAllSensors_cmd()
// PURPOSE: Envoie une commande pour détecter et afficher la connectivité
//			 de tous les capteurs connectés sur le bus I2C
void detectAllSensors_cmd();

/*********************************************************************/
// FUNCTION: void unknown_cmd()
// PURPOSE: Affiche/envoie un message/code d'erreur si commande erronée
void unknown_cmd();

/*********************************************************************/
// FUNCTION: void debug_cmd()
// PURPOSE: Permet d'activer/désactiver le mode de débogage(terminale)
void debug_cmd();
/*********************************************************************/
// FUNCTION: void temp_cmd(unsigned char dev_num, char *listTemp)
// PURPOSE: Conversion valeur brute T° en valeur décimale/ASCII
void temp_cmd(unsigned char dev_num, char *listTemp, char command, char dev_access);

/*********************************************************************/
// FUNCTION: void hum_cmd(char *listHum)
// PURPOSE: Conversion valeur brute %H en valeur décimale/ASCII
void hum_cmd(char *listHum, char command, char dev_access);

// FUNCTION: void ang_cmd(char listAngle, char command)
// PURPOSE: Conversion valeur brute Angle° en valeur décimale/ASCII
void ang_cmd(char listAngle, char command);

// FUNCTION: void dep_cmd(char listDepth, char command)
// PURPOSE: Conversion valeur brute profondeur(cm) en valeur décimale/ASCII
void dep_cmd(char listDepth, char command);

// FUNCTION: void vol_cmd(char listVolt, char command)
// PURPOSE: Conversion valeur brute tension (V) en valeur décimale/ASCII
void vol_cmd(char *listVolt, char command);

/*********************************************************************/
// FUNCTION: void hexaToAscii(unsigned char n)
// PURPOSE: Conversion d'une valeur hexa en ASCII et afficher sur terminale
void hexaToAscii(unsigned char n);

#endif
