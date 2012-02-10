/****************************************************************
 *																*
 *	FileName :		3964r.c										*
 *	Rev 	 : 		0.2											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Comp�re Christopher							*
 *																*
 ****************************************************************/

#include "3964r.h"

//Fonctions priv�e
char process_bcc_3964r(char[], unsigned char);
char sum_error_3964r(void);

//Set la priorit� du p�riph�rique
const unsigned char priority = LOW_PRIORITY;

//Tableau permettant d'identifier les diff�rents erreurs
//Le tableau existe et est rempli mais pas exploit� dans le programme
unsigned char tab_error_3964r[NB_ERRORS];

//Initialise les diff�rents composants pour la communication en 3964r
void init_3964r(void)
{
	init_usart(MYUBRR);
	init_timer1();

	//memset permet d'initialiser un tableau avec un valeur par default
	//On place la valeur 0 dans les 5 cellules de tab_error_3964r
	memset(tab_error_3964r,0,5);
}

//Fonction send_data_3964r
//Envoi des donn�es par le protocole 3964 sur le port s�rie
//Param�tres : - data[] => tableau � envoyer par le protocole
//			   - lenght => longueur du tableau data[]
//Valeur de retour : - TRANSMISSION_SUCCESS
//					 - TRANSMISSION_FAILED
//					 - RECEPTION_MODE
char send_data_3964r(char data[], unsigned char lenght)
{
	unsigned char bcc, i, c;
	//Initialisation du tableau tab_error_3964r
	memset(tab_error_3964r,0,5);

	//Pr�-calcul du bcc pour la trame 3964 qui sera envoy�e
	bcc = process_bcc_3964r(data, lenght);

	do
	{
		//Initialisation des diff�rents flag
		flag_timer1 = FALSE;
		flag_usart	= FALSE;

		//Envoie du caract�re STX
		putchar_usart(STX);

		//D�marre le timer avec la valeur de timeout TIMEOUT_MS
		start_timer1(TIMEOUT_MS);
		//Attend de recevoir un caract�re
		//Si on a pas re�u de caract�re avant le timeout, flag_timer1 se met � TRUE et on continue l'execution du programme
		c = getchar_usart();
		//On arrete le timer1
		stop_timer1();

		//On v�rifie le timeout n'a pas �t� d�clench�
		if(flag_timer1 == FALSE)
		{
			//Si le caract�re re�u est un DLE
			if(c == DLE)
			{
				//Activation l'interruption de l'usart en reception
				//Si un carac�re est re�u durant l'envoie, flag_usart est mis � TRUE
				ENABLE_RX_INT_USART;
				
				//On envoie le contenu du tableau data[]
				//En fonction de la longueur donn�e en param�tre
				for(i=0; i<lenght; i++)
				{
					//Si on a pas re�u de caract�re
					if(flag_usart == FALSE)
					{
						//Envoi des caract�res du tableau data[]
						putchar_usart(data[i]);
						//Traitement du double DLE
						if(data[i] == DLE)
						{
							//Rev�rification du flag_usart
							if(flag_usart == FALSE)
								//Envoi du 2eme DLE
								putchar_usart(DLE);
							else
								//On sort de la boucle, si on a re�u un caract�re
								break;
						}
					}
					//Si on a re�u un caract�re on sort de la boucle
					else
						break;
				}
				
				//V�rification du flag_usart	
				if(flag_usart == FALSE)
				{
					//Envoi du DLE pour signifier la fin des donn�es utiles
					putchar_usart(DLE);
					//V�rification du flag_usart
					if(flag_usart == FALSE)
					{
						//Envoi de ETX
						putchar_usart(ETX);
						//V�rification du flag_usart
						if(flag_usart == FALSE)
						{
							//D�sactivation de l'interruption de reception usart
							DISABLE_RX_INT_USART;
							
							//Envoi du bcc
							putchar_usart(bcc);

							//V�rification du flag_usart
							if(flag_usart == FALSE)
							{
								//D�marrage du timer1 avec timeout de valeur TIMEOUT_MS
								start_timer1(TIMEOUT_MS);
								//Attend la reception d'un caract�re
								c = getchar_usart();
								//Arrete le timer1
								stop_timer1();

								//V�rification que le timeout n'a pas expir�
								if(flag_timer1 == FALSE)
								{
									//Si on a re�u un caract�re diff�rent de DLE
									if(c != DLE)
										//Incr�mentation du nombre d'erreurs
										tab_error_3964r[1]++;
								}
								else
									//Incr�mentation du nombre d'erreurs
									tab_error_3964r[2]++;
							}
							//Si interruption par l'usart
							else
								//Incr�mentation du nombre d'erreurs
								tab_error_3964r[3]++;
						}
						//Si interruption par l'usart
						else
						{
							//D�sactivation de l'interruption de reception usart
							DISABLE_RX_INT_USART;
							//Incr�mentation du nombre d'erreurs
							tab_error_3964r[3]++;
						}
					}
					//Si interruption par l'usart
					else
					{
						//D�sactivation de l'interruption de reception usart
						DISABLE_RX_INT_USART;
						//Incr�mentation du nombre d'erreurs
						tab_error_3964r[3]++;
					}
				}
				//Si interruption par l'usart
				else
				{
					//D�sactivation de l'interruption de reception usart
					DISABLE_RX_INT_USART;
					//Incr�mentation du nombre d'erreurs
					tab_error_3964r[3]++;
				}
			}
			//Si le 1er caract�re re�u n'est pas un DLE
			else
			{
				//Si le caract�re est un STX
				if(c == STX)
				{
					//V�rification du la priorit�
					if(priority == LOW_PRIORITY)
						//Renvoi la valeur RECEPTION_MODE pour avertir que le p�riph�rique Maitre veut envoyer
						return RECEPTION_MODE;
					else
 						//flag_timer1 ou flag_usart � TRUE juste pour faire boucler
						flag_timer1 = TRUE;
				}
				//Si le 1er caract�re est diff�rent de DLE et STX
				else
					//Incr�mentation du nombre d'erreurs
					tab_error_3964r[0]++;
			}
		}
		//Si le p�riph�rique n'a pas r�pondu au STX
		else
			//Incr�mentation du nombre d'erreurs
			tab_error_3964r[4]++;

		//Si la somme des erreurs est sup�rieur au seuil max
		if(sum_error_3964r() == MAX_ERRORS)
			//retourne une erreur de transmission
			return TRANSMISSION_FAILED;

	//On boucle tant que flag_timer1 ou flag_usart est a TRUE
	}while((flag_timer1 == TRUE) || (flag_usart == TRUE));
	
	//la transmission s'est bien d�roul�e
	return TRANSMISSION_SUCCESS;
}


//Fonction get_data_3964r
//Recoi des donn�es sur le protocole 3964 par le port s�rie
//Param�tres : - data[] => tableau qui va recevoir les donn�es par le protocole
//Valeur de retour : Aucune
void get_data_3964r(char data[])
{
	unsigned char c, prev_c, i, bcc, flag_error, flag_dle[3];

	do
	{
		//Initialisation des variables
		i = 0;
		prev_c = 0;
		flag_timer1 = FALSE;
		flag_error	= FALSE;
		//Initialise le tableau flag_dle avec la valeur FALSE
		memset(flag_dle,FALSE,3);
	
		//On attend de recevoir un caract�re
		c = getchar_usart();

		//Si on re�oi un STX
		if(c == STX)
		{
			//Calcul du bcc
			bcc = STX;

			//On r�pond DLE
			putchar_usart(DLE);

			//D�but de la boucle de r�ception
			do
			{
				//D�marrage du timer avec la valeur de timeout TIMEOUT_MS
				start_timer1(TIMEOUT_MS);
				//Attend de recoir un caract�re
				//Passage � l'instruction suivant si le timeout est d�clench� (flag_timer1 == TRUE)
				c = getchar_usart();
				//Stop le timer1
				stop_timer1();

				//Si le timeout n'a pas expir�
				if(flag_timer1 == FALSE)
				{
					//Calcul du bcc					
					bcc ^= c;

					//Machine d'�tat pour le contr�le des double DLE
					//Cette machine d'�tat permet de diff�rencier 
					//les doubles DLE et le DLE de terminaison des donn�es utiles.

					//Si le caract�re pr�c�dent est diff�rent d'un DLE et que le caract�re re�u est un DLE
					if((prev_c != DLE) && (c == DLE))
					{
						//Mise � jour des �tats
						flag_dle[0] = TRUE;
						flag_dle[1] = FALSE;
						flag_dle[2] = FALSE;
					}
					else
					{
						//Si on est en pr�sence d'un double DLE
						if((prev_c == DLE) && (c == DLE))
						{
							//V�rification d'�tat (1er passage)
							if(flag_dle[1] == FALSE)
							{
								//Mise � jour des �tats
								flag_dle[0] = FALSE;
								flag_dle[1] = TRUE;
								flag_dle[2] = FALSE;
								
								//Place la valeur DLE dans le tabeau data
								data[i] = DLE;
								//Incr�mentation de l'indice du tableau
								i++;
							}
							//Si 3 DLE cons�cutifs
							else
							{
								//Mise � jour des �tats
								flag_dle[0] = TRUE;
								flag_dle[1] = FALSE;
								flag_dle[2] = FALSE;
							}
						}
						//Si le caract�re actuelle ou le pr�c�dent est diff�rents de DLE
						else
						{
							//Si le caract�re pr�sent est diff�rent de DLE mais que le pr�c�dent est un DLE
							if((prev_c == DLE) && (c != DLE))
							{
								//Mise � jour des �tats
								flag_dle[1] = FALSE;
								flag_dle[2] = TRUE;
								
								//Place la valeur c dans le tabeau data
								data[i] = c;
								//Incr�mentation de l'indice du tableau
								i++;
							}

							else
							{
								//Mise � jour des �tats
								flag_dle[0] = FALSE;
								flag_dle[1] = FALSE;
								flag_dle[2] = FALSE;
								
								//Place la valeur c dans le tabeau data
								data[i] = c;
								//Incr�mentation de l'indice du tableau
								i++;
							}
						}
					}
					//Sauvegarde de la valeur actuelle dans la variable du caract�re pr�c�dent
					prev_c = c;
				}
				//Si le timeout a expir�
				else
				{
					//Envoi du caract�re NAK
					putchar_usart(NAK);
					//Sort de la boucle de reception
					break;
				}
			//On continue de recevoir des caract�res tant que on a pas d�terminer le DLE de terminaison
			}while(!((flag_dle[0] == TRUE) && (flag_dle[2] == TRUE)));

			//Si le timeout n'a pas expir�
			if(flag_timer1 == FALSE)
			{
				//Si le caract�re dernier apr�s le DLE est ETX
				if(c == ETX)
				{
					//D�marrage du timer1 avec valeur de timeout TIMEOUT_MS
					start_timer1(TIMEOUT_MS);
					//Attend de recevoir un caract�re sur le port s�rie
					c = getchar_usart();
					//Arret du timeout
					stop_timer1();
					
					//Si le timeout n'a pas expir�
					if(flag_timer1 == FALSE)
					{
						//Si le bcc re�u est �gale au bcc calcul�
						if(c == bcc)
							//Envoi d'un DLE
							putchar_usart(DLE);
						//Si �chec de DLE
						else
						{
							//Envoi un NAK
							putchar_usart(NAK);
							flag_error = TRUE;
						}
						
					}
					//Si timeout expir�
					else
					{
						//Envoi un NAK
						putchar_usart(NAK);
						flag_error = TRUE;
					}

				}
				//Si le caract�re apr�s le DLE n'est pas ETX
				else
				{
					//Envoi un NAK
					putchar_usart(NAK);
					flag_error = TRUE;
				}
			}
			//Si le timeout a expir�
			else
			{
				//Envoi un NAK
				putchar_usart(NAK);
				flag_error = TRUE;
			}
		}
		//Si le 1er caract�re de la trame n'est pas STX
		else
		{
			//Envoi un NAK
			putchar_usart(NAK);
			flag_error = TRUE;
		}
	//On continue la reception tant que le flag_timer1 ou le flag_error est � TRUE
	}while((flag_timer1 == TRUE) || (flag_error == TRUE));
}

//Fonction process_bcc_3964r
//Permet de pr�-calculer le bcc avant l'envoi d'une trame
//Param�tres : - data[] => tableau � envoyer par le protocole
//			   - lenght => longueur du tableau data[]
//Valeur de retour : - le bcc pr�-calcul�
char process_bcc_3964r(char data[], unsigned char lenght)
{
	unsigned char bcc = 0, i;

	bcc ^= STX;
	for(i=0; i<lenght; i++)
	{
		bcc ^= data[i];
		//On compte un double DLE
		if(data[i] == DLE)
			bcc ^= DLE;
	}
	bcc ^= DLE;
	bcc ^= ETX;

	return bcc;
}

//Fonction sum_error_3964r
//Permet de compter le nombre d'erreur qui s'est produit pendant l'�mission
//Param�tres : Aucun
//Valeur de retour : - le nombre d'erreur produite
char sum_error_3964r(void)
{
	unsigned char sum, i;

	for(i=0, sum=0; i<NB_ERRORS; i++)
		sum += tab_error_3964r[i];

	return sum;
}
