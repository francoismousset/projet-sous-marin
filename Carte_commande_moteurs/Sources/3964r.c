/****************************************************************
 *																*
 *	FileName :		3964r.c										*
 *	Rev 	 : 		0.2											*
 *	Project	 :		Sous-marin 2010-2011						*
 *	Date	 :		23/03/11									*
 *	CPU 	 :		Atmel Atmega88								*
 *	Compiler : 		WinAVR										*
 *	Author 	 :		Compère Christopher							*
 *																*
 ****************************************************************/

#include "3964r.h"

//Fonctions privée
char process_bcc_3964r(char[], unsigned char);
char sum_error_3964r(void);

//Set la priorité du périphérique
const unsigned char priority = LOW_PRIORITY;

//Tableau permettant d'identifier les différents erreurs
//Le tableau existe et est rempli mais pas exploité dans le programme
unsigned char tab_error_3964r[NB_ERRORS];

//Initialise les différents composants pour la communication en 3964r
void init_3964r(void)
{
	init_usart(MYUBRR);
	init_timer1();

	//memset permet d'initialiser un tableau avec un valeur par default
	//On place la valeur 0 dans les 5 cellules de tab_error_3964r
	memset(tab_error_3964r,0,5);
}

//Fonction send_data_3964r
//Envoi des données par le protocole 3964 sur le port série
//Paramètres : - data[] => tableau à envoyer par le protocole
//			   - lenght => longueur du tableau data[]
//Valeur de retour : - TRANSMISSION_SUCCESS
//					 - TRANSMISSION_FAILED
//					 - RECEPTION_MODE
char send_data_3964r(char data[], unsigned char lenght)
{
	unsigned char bcc, i, c;
	//Initialisation du tableau tab_error_3964r
	memset(tab_error_3964r,0,5);

	//Pré-calcul du bcc pour la trame 3964 qui sera envoyée
	bcc = process_bcc_3964r(data, lenght);

	do
	{
		//Initialisation des différents flag
		flag_timer1 = FALSE;
		flag_usart	= FALSE;

		//Envoie du caractère STX
		putchar_usart(STX);

		//Démarre le timer avec la valeur de timeout TIMEOUT_MS
		start_timer1(TIMEOUT_MS);
		//Attend de recevoir un caractère
		//Si on a pas reçu de caractère avant le timeout, flag_timer1 se met à TRUE et on continue l'execution du programme
		c = getchar_usart();
		//On arrete le timer1
		stop_timer1();

		//On vérifie le timeout n'a pas été déclenché
		if(flag_timer1 == FALSE)
		{
			//Si le caractère reçu est un DLE
			if(c == DLE)
			{
				//Activation l'interruption de l'usart en reception
				//Si un caracère est reçu durant l'envoie, flag_usart est mis à TRUE
				ENABLE_RX_INT_USART;
				
				//On envoie le contenu du tableau data[]
				//En fonction de la longueur donnée en paramètre
				for(i=0; i<lenght; i++)
				{
					//Si on a pas reçu de caractère
					if(flag_usart == FALSE)
					{
						//Envoi des caractères du tableau data[]
						putchar_usart(data[i]);
						//Traitement du double DLE
						if(data[i] == DLE)
						{
							//Revérification du flag_usart
							if(flag_usart == FALSE)
								//Envoi du 2eme DLE
								putchar_usart(DLE);
							else
								//On sort de la boucle, si on a reçu un caractère
								break;
						}
					}
					//Si on a reçu un caractère on sort de la boucle
					else
						break;
				}
				
				//Vérification du flag_usart	
				if(flag_usart == FALSE)
				{
					//Envoi du DLE pour signifier la fin des données utiles
					putchar_usart(DLE);
					//Vérification du flag_usart
					if(flag_usart == FALSE)
					{
						//Envoi de ETX
						putchar_usart(ETX);
						//Vérification du flag_usart
						if(flag_usart == FALSE)
						{
							//Désactivation de l'interruption de reception usart
							DISABLE_RX_INT_USART;
							
							//Envoi du bcc
							putchar_usart(bcc);

							//Vérification du flag_usart
							if(flag_usart == FALSE)
							{
								//Démarrage du timer1 avec timeout de valeur TIMEOUT_MS
								start_timer1(TIMEOUT_MS);
								//Attend la reception d'un caractère
								c = getchar_usart();
								//Arrete le timer1
								stop_timer1();

								//Vérification que le timeout n'a pas expiré
								if(flag_timer1 == FALSE)
								{
									//Si on a reçu un caractère différent de DLE
									if(c != DLE)
										//Incrémentation du nombre d'erreurs
										tab_error_3964r[1]++;
								}
								else
									//Incrémentation du nombre d'erreurs
									tab_error_3964r[2]++;
							}
							//Si interruption par l'usart
							else
								//Incrémentation du nombre d'erreurs
								tab_error_3964r[3]++;
						}
						//Si interruption par l'usart
						else
						{
							//Désactivation de l'interruption de reception usart
							DISABLE_RX_INT_USART;
							//Incrémentation du nombre d'erreurs
							tab_error_3964r[3]++;
						}
					}
					//Si interruption par l'usart
					else
					{
						//Désactivation de l'interruption de reception usart
						DISABLE_RX_INT_USART;
						//Incrémentation du nombre d'erreurs
						tab_error_3964r[3]++;
					}
				}
				//Si interruption par l'usart
				else
				{
					//Désactivation de l'interruption de reception usart
					DISABLE_RX_INT_USART;
					//Incrémentation du nombre d'erreurs
					tab_error_3964r[3]++;
				}
			}
			//Si le 1er caractère reçu n'est pas un DLE
			else
			{
				//Si le caractère est un STX
				if(c == STX)
				{
					//Vérification du la priorité
					if(priority == LOW_PRIORITY)
						//Renvoi la valeur RECEPTION_MODE pour avertir que le périphérique Maitre veut envoyer
						return RECEPTION_MODE;
					else
 						//flag_timer1 ou flag_usart à TRUE juste pour faire boucler
						flag_timer1 = TRUE;
				}
				//Si le 1er caractère est différent de DLE et STX
				else
					//Incrémentation du nombre d'erreurs
					tab_error_3964r[0]++;
			}
		}
		//Si le périphérique n'a pas répondu au STX
		else
			//Incrémentation du nombre d'erreurs
			tab_error_3964r[4]++;

		//Si la somme des erreurs est supérieur au seuil max
		if(sum_error_3964r() == MAX_ERRORS)
			//retourne une erreur de transmission
			return TRANSMISSION_FAILED;

	//On boucle tant que flag_timer1 ou flag_usart est a TRUE
	}while((flag_timer1 == TRUE) || (flag_usart == TRUE));
	
	//la transmission s'est bien déroulée
	return TRANSMISSION_SUCCESS;
}


//Fonction get_data_3964r
//Recoi des données sur le protocole 3964 par le port série
//Paramètres : - data[] => tableau qui va recevoir les données par le protocole
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
	
		//On attend de recevoir un caractère
		c = getchar_usart();

		//Si on reçoi un STX
		if(c == STX)
		{
			//Calcul du bcc
			bcc = STX;

			//On répond DLE
			putchar_usart(DLE);

			//Début de la boucle de réception
			do
			{
				//Démarrage du timer avec la valeur de timeout TIMEOUT_MS
				start_timer1(TIMEOUT_MS);
				//Attend de recoir un caractère
				//Passage à l'instruction suivant si le timeout est déclenché (flag_timer1 == TRUE)
				c = getchar_usart();
				//Stop le timer1
				stop_timer1();

				//Si le timeout n'a pas expiré
				if(flag_timer1 == FALSE)
				{
					//Calcul du bcc					
					bcc ^= c;

					//Machine d'état pour le contrôle des double DLE
					//Cette machine d'état permet de différencier 
					//les doubles DLE et le DLE de terminaison des données utiles.

					//Si le caractère précédent est différent d'un DLE et que le caractère reçu est un DLE
					if((prev_c != DLE) && (c == DLE))
					{
						//Mise à jour des états
						flag_dle[0] = TRUE;
						flag_dle[1] = FALSE;
						flag_dle[2] = FALSE;
					}
					else
					{
						//Si on est en présence d'un double DLE
						if((prev_c == DLE) && (c == DLE))
						{
							//Vérification d'état (1er passage)
							if(flag_dle[1] == FALSE)
							{
								//Mise à jour des états
								flag_dle[0] = FALSE;
								flag_dle[1] = TRUE;
								flag_dle[2] = FALSE;
								
								//Place la valeur DLE dans le tabeau data
								data[i] = DLE;
								//Incrémentation de l'indice du tableau
								i++;
							}
							//Si 3 DLE consécutifs
							else
							{
								//Mise à jour des états
								flag_dle[0] = TRUE;
								flag_dle[1] = FALSE;
								flag_dle[2] = FALSE;
							}
						}
						//Si le caractère actuelle ou le précédent est différents de DLE
						else
						{
							//Si le caractère présent est différent de DLE mais que le précédent est un DLE
							if((prev_c == DLE) && (c != DLE))
							{
								//Mise à jour des états
								flag_dle[1] = FALSE;
								flag_dle[2] = TRUE;
								
								//Place la valeur c dans le tabeau data
								data[i] = c;
								//Incrémentation de l'indice du tableau
								i++;
							}

							else
							{
								//Mise à jour des états
								flag_dle[0] = FALSE;
								flag_dle[1] = FALSE;
								flag_dle[2] = FALSE;
								
								//Place la valeur c dans le tabeau data
								data[i] = c;
								//Incrémentation de l'indice du tableau
								i++;
							}
						}
					}
					//Sauvegarde de la valeur actuelle dans la variable du caractère précédent
					prev_c = c;
				}
				//Si le timeout a expiré
				else
				{
					//Envoi du caractère NAK
					putchar_usart(NAK);
					//Sort de la boucle de reception
					break;
				}
			//On continue de recevoir des caractères tant que on a pas déterminer le DLE de terminaison
			}while(!((flag_dle[0] == TRUE) && (flag_dle[2] == TRUE)));

			//Si le timeout n'a pas expiré
			if(flag_timer1 == FALSE)
			{
				//Si le caractère dernier après le DLE est ETX
				if(c == ETX)
				{
					//Démarrage du timer1 avec valeur de timeout TIMEOUT_MS
					start_timer1(TIMEOUT_MS);
					//Attend de recevoir un caractère sur le port série
					c = getchar_usart();
					//Arret du timeout
					stop_timer1();
					
					//Si le timeout n'a pas expiré
					if(flag_timer1 == FALSE)
					{
						//Si le bcc reçu est égale au bcc calculé
						if(c == bcc)
							//Envoi d'un DLE
							putchar_usart(DLE);
						//Si échec de DLE
						else
						{
							//Envoi un NAK
							putchar_usart(NAK);
							flag_error = TRUE;
						}
						
					}
					//Si timeout expiré
					else
					{
						//Envoi un NAK
						putchar_usart(NAK);
						flag_error = TRUE;
					}

				}
				//Si le caractère après le DLE n'est pas ETX
				else
				{
					//Envoi un NAK
					putchar_usart(NAK);
					flag_error = TRUE;
				}
			}
			//Si le timeout a expiré
			else
			{
				//Envoi un NAK
				putchar_usart(NAK);
				flag_error = TRUE;
			}
		}
		//Si le 1er caractère de la trame n'est pas STX
		else
		{
			//Envoi un NAK
			putchar_usart(NAK);
			flag_error = TRUE;
		}
	//On continue la reception tant que le flag_timer1 ou le flag_error est à TRUE
	}while((flag_timer1 == TRUE) || (flag_error == TRUE));
}

//Fonction process_bcc_3964r
//Permet de pré-calculer le bcc avant l'envoi d'une trame
//Paramètres : - data[] => tableau à envoyer par le protocole
//			   - lenght => longueur du tableau data[]
//Valeur de retour : - le bcc pré-calculé
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
//Permet de compter le nombre d'erreur qui s'est produit pendant l'émission
//Paramètres : Aucun
//Valeur de retour : - le nombre d'erreur produite
char sum_error_3964r(void)
{
	unsigned char sum, i;

	for(i=0, sum=0; i<NB_ERRORS; i++)
		sum += tab_error_3964r[i];

	return sum;
}
