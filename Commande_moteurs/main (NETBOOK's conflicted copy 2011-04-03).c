/****************************************************************
 *																*
 *	FileName :		main.c										*
 *	Rev 	 : 		0.1											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		25/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Complier : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "main.h"
#include "usart.h"

int main(void)
{
	char str_cmd[SIZE_MSG];
	unsigned int position;

	init_main();

	while(1)
	{
		get_data_3964r(str_cmd);

		switch(str_cmd[0])
		{
			case 'K':	//Vitesse moteur 0
				if(str_cmd[2] != 0)
				{
					if(str_cmd[1] == 0)
						rotation_motor1(CLOCKWISE);
					else
						rotation_motor1(COUNTERCLOCKWISE);
					
					set_speed_motor1(str_cmd[2]);
					enable_motor1(TRUE);		
				}
				else
					enable_motor1(FALSE);
				break;

			case 'M':	//Vitesse moteur 1
				if(str_cmd[2] != 0)
				{
					if(str_cmd[1] == 0)
						rotation_motor2(CLOCKWISE);
					else
						rotation_motor2(COUNTERCLOCKWISE);
					
					set_speed_motor2(str_cmd[2]);
					enable_motor2(TRUE);
				}
				else
					enable_motor2(FALSE);
				break;

			case 'G':	//Requete position ballast0

				//Uniformiser la valeur adc et external interrupt !!!
				position = get_ballast_position1();

				str_cmd[2] = position & 0xFF00;
				position >>= 8;
				str_cmd[1] = position & 0xFF00;

				send_data_3964r(str_cmd);

				break;

			case 'J':	//Requete position ballast1

				//Uniformiser la valeur adc et external interrupt !!!
				position = get_ballast_position2();

				str_cmd[2] = position & 0xFF00;
				position >>= 8;
				str_cmd[1] = position & 0xFF00;

				send_data_3964r(str_cmd);

				break;

			default:
				break;		
		}
	}
	return 42; //http://fr.wikipedia.org/wiki/La_grande_question_sur_la_vie,_l%27univers_et_le_reste
}

void init_main(void)
{
	init_3964r();
	init_motor_driver(); //Attention le moteur vide le ballast avec FC mais interruption pas activée
	init_ballast_position();
	sei();
}
