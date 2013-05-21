/****************************************************************
 *																*
 *	FileName :		watchdog.c									*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		24/05/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/


//FUSE : ne pas programmer WDTON !!!
 
#include "watchdog.h"

volatile unsigned int timeout = TIMEOUT_RESET;

void init_watchdog(void)
{
	cli();

	//reset watchdog
	wdt_reset();
	//set up WDT Interrupt Mode
	WDTCSR = (1<<WDCE)|(1<<WDE);
	//Start watchdog timer with 8s prescaller
	WDTCSR = (1<<WDIE)|(1<<WDP3)|(1<<WDP0);

	sei();
}

ISR(WDT_vect)
{
	cli();
	if(timeout != 0)
	{
		//reset watchdog
		wdt_reset();
		//set up WDT Interrupt Mode
		WDTCSR = (1<<WDCE)|(1<<WDE);
		//Start watchdog timer with 8s prescaller
		WDTCSR = (1<<WDIE)|(1<<WDP3)|(1<<WDP0);
		
		timeout--;
	}
	else
	{
		//reset watchdog
		wdt_reset();
		//set up WDT Reset Mode
		WDTCSR = (1<<WDCE)|(1<<WDE);
		//Reset Mode
		WDTCSR = (1<<WDE);
	}
	sei();
}
