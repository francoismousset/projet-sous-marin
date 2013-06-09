/* main.c */

/**********************************************************************
*
* File name		 : main.c
* Title 		 : I2C Bus Tester
				   Projet sous-marin
				   Programme carte de test bus I2C & capteurs
* Author 		 : Michaël Brogniaux - Copyright (C) 2011
* Created		 : 02/03/2012
* Last revised	 : 31/05/2013
* Version		 : 1.2.12
* Compliler		 : AVR Studio 4.18.716 - WinAVR-20100110
* MCU			 : Atmel ATmega88
* Devices		 : Capteurs I2C (DS7505, SHT21)
*
* Revisions Log :
*		V1.2.0  - First release of I2C Bus Tester software
*		V1.2.1  - Other T° sensor were added
*		V1.2.2  - Reading error for Humidity value was corrected
*		V1.2.3  - Debug mode added
*		V1.2.4  - T° and %H device access detection added
*		V1.2.5  - Add the function to test all I2C address automaticaly,
*			    - Clean main() funtion
*		V1.2.6  - Clean all main()function in devices_all.c file
*			    - Hexa to ASCII function Added
*		V1.2.7  - Frame format : STX|sensor address|high value|low value
*		V1.2.8  - Frame format : STX|sensor command|high value|low value
*		V1.2.9  - Rx buffer added
*		V1.2.10 - Fix bug for sensor T7
*		V1.2.11 - Frame format : STX|lenght|sensor address|high value|low value|ETX
*				- 			   : STX|lenght|sensor address|ETX
*		V1.2.12 - Add "gestion_A", Add "gestion_D", Add "gestion_V"
**********************************************************************/

/***** Liste des includes *****/
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "main.h"
#include "I2Cmaster.h"
#include "uart.h"
#include "car.h"
#include "devices_all.h"
#include "DS7505.h"
//#include "DS1621.h"
#include "SHT21.h"

/***** Variables globales *****/
//unsigned char bufUSART_RX = NULL;		// Buffer contenant l'octet reçu sur RX
//unsigned char dev1_DS7505_access, dev2_DS7505_access, dev3_DS7505_access, dev4_DS7505_access;
//unsigned char dev5_DS7505_access, dev6_DS7505_access, dev7_DS7505_access, dev8_DS7505_access;
//unsigned char dev1_SHT21_access;
unsigned char dev_test_access;
volatile char RX_flag = FALSE;
volatile char buf_RX [RX_BUFFER];
volatile char i = 0;
char j = 0;
volatile char nbRead = 0;

char listTemp[2], listHum[3], listVolt[2];//, tempResult[2], tempStr[5], humResult, humStr[2];// Tableau des températures
char listAngle, listDepth;

/*****************************************************************/
/*********************** Programme principal *********************/
/*****************************************************************/

int main(void)
{
	/***** Variables locales *****/
	//
	init();						// Initialisations globales
	init_sensors();				// Initialisations des capteurs

	/* boucle infinie */
	for(;;)
	{
		sbiBF(PORTB,0);
		_delay_ms(200);
		cbiBF(PORTB,0);
		_delay_ms(200);

		if(RX_flag == TRUE)	// Si le buffer RX se remplie
		{
			while (nbRead != 0)	// Tant que le nombre d'élément dans le buffer RX ne vaut pas zéro
			{
				switch (buf_RX[i-nbRead]) // Index du buffer selon le nombre d'éléments restants
				{
					/* Si demande d'envoyer la T° du capteur n°1 */
					case T1_CMD:	
						dev_test_access = get_DS7505_Devices(ADD1_DS7505, listTemp); // Récupérer T° capteur n°1
						temp_cmd(1, listTemp, T1_CMD, dev_test_access);
						//dev1_DS1621_access = get_DS1621_Devices(ADD1_DS1621, listTemp);	
						break;
					/* Si demande d'envoyer la T° du capteur n°2 */
					case T2_CMD :
						dev_test_access = get_DS7505_Devices(ADD2_DS7505, listTemp); // Récupérer T° capteur n°2
						temp_cmd(2, listTemp, T2_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer la T° du capteur n°3 */
					case T3_CMD :
						dev_test_access = get_DS7505_Devices(ADD3_DS7505, listTemp); // Récupérer T° capteur n°3
						temp_cmd(3, listTemp, T3_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer la T° du capteur n°4 */
					case T4_CMD :
						dev_test_access = get_DS7505_Devices(ADD4_DS7505, listTemp); // Récupérer T° capteur n°4
						temp_cmd(4, listTemp, T4_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer la T° du capteur n°5 */
					case T5_CMD :
						dev_test_access = get_DS7505_Devices(ADD5_DS7505, listTemp); // Récupérer T° capteur n°5
						temp_cmd(5, listTemp, T5_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer la T° du capteur n°6 */
					case T6_CMD :
						dev_test_access = get_DS7505_Devices(ADD6_DS7505, listTemp); // Récupérer T° capteur n°6
						temp_cmd(6, listTemp, T6_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer la T° du capteur n°7 */
					case T7_CMD :
						dev_test_access = get_DS7505_Devices(ADD7_DS7505, listTemp); // Récupérer T° capteur n°7
						temp_cmd(7, listTemp, T7_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer la T° du capteur n°8 */
					case T8_CMD :
						dev_test_access = get_DS7505_Devices(ADD8_DS7505, listTemp); // Récupérer T° capteur n°8
						temp_cmd(8, listTemp, T8_CMD, dev_test_access);
						break;
					/* Si demande d'envoyer %H du capteur d'humidité */
					case H1_CMD :
						dev_test_access = get_SHT21_Devices(ADD1_SHT21, listHum); // Récuperer %H
						hum_cmd(listHum, H1_CMD, dev_test_access);
						break;
					case A1_CMD :
						ang_cmd(listAngle, A1_CMD);
						break;
					case V1_CMD :
						vol_cmd(listVolt, V1_CMD);
						break;
					case D1_CMD :
						dep_cmd(listDepth, D1_CMD);
						break;
					case DEBUG_CMD :
						debug_cmd();
						break;
					case T1_DETECT_CMD :
						dev_test_access = testDevice(ADD1_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T2_DETECT_CMD :
						dev_test_access = testDevice(ADD2_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T3_DETECT_CMD :
						dev_test_access = testDevice(ADD3_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T4_DETECT_CMD :
						dev_test_access = testDevice(ADD4_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T5_DETECT_CMD :
						dev_test_access = testDevice(ADD5_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T6_DETECT_CMD :
						dev_test_access = testDevice(ADD6_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T7_DETECT_CMD :
						dev_test_access = testDevice(ADD7_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case T8_DETECT_CMD :
						dev_test_access = testDevice(ADD8_DS7505);
						detectSensor_cmd(dev_test_access);
						break;
					case H1_DETECT_CMD :
						dev_test_access = testDevice(ADD1_SHT21);
						detectSensor_cmd(dev_test_access);
						break;
					case ALL_DETECT_CMD :
						detectAllSensors_cmd();
						break;
					case SPECIAL_CMD :
						//testDevice function
						//special command
						break;
					default :
						unknown_cmd(); // Commande inconnue (non assignée)
						//asm("nop"); 	// Ne rien faire en cas d'erreur
				}
				nbRead--; // Décrémenter le nombre d'éléments restants dans le buffer RX
				
			}
			i = 0;				// Remise à zéro de l'index du buffer RX
			//RX_flag = FALSE;	// Mise du flag du RX à zéro
		}

	}
	return 0;	
}

/*****************************/
/******* Interruptions *******/
/*****************************/				

//*********** Interruption sur l'entrée de l'USART (RX) ************//
ISR(USART_RX_vect)
{
	//bufUSART_RX = UDR0;		// Mettre dans le buffer l'octet reçu sur RX
	//static char i=0;
	
	if(i==RX_BUFFER)	// Si le buffer RX est remplis
		i=0;		
	buf_RX[i] = UDR0;
	i++;				// Incrémenter l'index du buffer RX
	nbRead++;			// Incrémenter le nombre d'éléments du buffer RX
	RX_flag = TRUE;		// Signaler que le buffer se remplie
}

/*************************/
/******* Fonctions *******/
/*************************/

/***** Initialisation *****/
void init()							
{
	cli();							// Désactiver toutes les interruptions
    
	sDDR(DDRB,0); 					// PORTB.0 en sortie
	sDDR(DDRB,1); 					// PORTB.1 en sortie
	cbiBF(PORTB,0);					// Mettre à zéro le portB.0

	//initI2C();						// Initialiser le bus I2C
	i2c_init();              		// Initialisation interface I2C

	USART_Init(MYUBRR);				// Initialisation de la communication série
	Enable_Interrupt_On_RX();		// Autoriser les interruption série RX

	sei();							// Activer toutes les interruptions	

	welcomeMsg();					// Afficher le message de bienvenue
}

