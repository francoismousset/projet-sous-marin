/****************************************************************
 *																*
 *	FileName :		motor_driver.h								*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		26/02/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#ifndef _MOTOR_DRIVER_H_
#define _MOTOR_DRIVER_H_

#include <avr/io.h>
#include <avr/interrupt.h>
#include "timer0.h"

#define TRUE  0
#define FALSE 1
#define CLOCKWISE 1
#define COUNTERCLOCKWISE 0

void init_motor_driver(void);
void enable_motor1(unsigned char);
void enable_motor2(unsigned char);
void rotation_motor1(unsigned char);
void rotation_motor2(unsigned char);
unsigned char get_rotation_motor1(void);
unsigned char get_rotation_motor2(void);
void set_speed_motor1(unsigned char);
void set_speed_motor2(unsigned char);

#endif /* _MOTOR_DRIVER_H_ */
