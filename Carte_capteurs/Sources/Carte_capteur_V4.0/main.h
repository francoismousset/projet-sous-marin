/* main.h */

/**********************************************************************
*
* File name		 : main.h
* Title 		 : Projet sous-marin
				   Test de communication I2C et capteurs
* Author 		 : Echevin Benoît
* Created		 : 02/03/2012
* Last revised	 : 20/04/2012
* Version		 : 4.0
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : 3x DS1621 on I2C bus
*
**********************************************************************/

#ifndef MAIN_H
#define MAIN_H


/* DEFINE */
//#define NULL 0
#define BOOL    char
#define nbre_max_capteur 3

#define RECEPTION 	1
#define ENVOI		0

/* Liste des commandes pour la communication entre FoxBoard et carte capteur */
	// Capteur de température
#define CMD_TEMP1				0x40
#define CMD_TEMP2				0x41
#define CMD_TEMP3				0x42
#define CMD_TEMP4				0x43
#define CMD_TEMP5				0x44
#define CMD_TEMP6				0x45
#define CMD_TEMP7				0x46
#define CMD_TEMP8				0x47
	// Convertisseur ADC
#define CMD_PROFONDEUR			0x50
#define CMD_ADC2				0x51
#define CMD_ADC3				0x52
#define	CMD_ADC4				0x53
	// Accéléromètre
#define CMD_INCLINAISON 		0x60
	// Hygromètre
#define CMD_HYGROMETRE1			0x70
#define CMD_HYGROMETRE2			0x71
	// Compteur impulsionnel
#define CMD_BALLAST				0x80
#define CMD_SYSTEME_BALLAST		0x81
	// Sens des moteurs
#define CMD_SENS_0_POSITIF		0x90
#define CMD_SENS_0_NEGATIF		0x91
#define CMD_SENS_1_POSITIF		0x92
#define CMD_SENS_1_NEGATIF		0x93
	// Confirmation de la réception des commandes sur le sens des moteurs
#define Conf_sens0p				0xA0
#define Conf_sens0n				0xA1
#define Conf_sens1p				0xA2
#define Conf_sens1n				0xA3


/* Macro definitions */
#define sDDR(ddr,bit)  (ddr |= (1<<bit))   		// Set I/O bit in port
#define sbiBF(port,bit)  (port |= (1<<bit))   	// Set bit in port
#define cbiBF(port,bit)  (port &= ~(1<<bit))  	// Clear bit in port
#define sbiR(reg,bit) (reg |= (1<<bit)) 		// Set bit in register
#define cbiR(reg,bit)  (reg &= ~(1<<bit))  		// Clear bit in register


/*********************** Déclaration des fonctions *************************/

void init();		// Initialisations globales
void transmission(char commande, char data_low, char data_high); 	// Transmission de deux bytes en protocole 3964

#endif /* MAIN_H */
