using System;
using System.Text;
using System.IO.Ports;
using System.Timers;

namespace SerialProtocol3964r
{
    public class SerialPort3964r : SerialPort
    {
        private byte[] STX;
        private byte[] ETX;
        private byte[] DLE;
        private byte[] NAK;

        //Valeur de retour de la commande d'envoi
        private const int TRANSMISSION_RECEPTION_MODE = -1;
        private const int TRANSMISSION_SUCCESS = 0;
        private const int TRANSMISSION_FAILED = 1;

        private const int RECEPTION_SUCCESS = 0;
        private const int RECEPTION_FAILED = 1;


        //Set la priorité du périphérique
        private bool _highPriority;
        //Nombre de tentative max
        private const byte MAX_ERRORS = 6;
        //Taille du tableau d'erreur
        private const byte NB_ERRORS = 5;

        private byte[] tab_error_3964r;

        //private Timer _timer;
        private bool _flag_timer;

        private bool[] _flag_dle;
        private byte[] _data;
        private bool _flag_error;

        public SerialPort3964r(bool isHighPriority)
        {
            STX = new byte[1];
            ETX = new byte[1];
            DLE = new byte[1];
            NAK = new byte[1];

            this._flag_dle = new bool[3];
            this._data = new byte[3];
            this._flag_error = false;

            STX[0] = 0x02;
            ETX[0] = 0x03;
            DLE[0] = 0x10;
            NAK[0] = 0x15;

            _flag_timer = false;

            this._highPriority = isHighPriority;
            tab_error_3964r = new byte[NB_ERRORS];
        }

        public int WriteBytes3964r(ref byte[] str)
        {
            byte[] bcc = new byte[1];//, i;
            int c = 0;

	        //Pré-calcul du bcc pour la trame 3964 qui sera envoyée
	        bcc[0] = process_bcc_3964r(str);

            this.DiscardInBuffer();

            this.tab_error_3964r[0] = 0;
            this.tab_error_3964r[1] = 0;
            this.tab_error_3964r[2] = 0;
            this.tab_error_3964r[3] = 0;
            this.tab_error_3964r[4] = 0;

            Console.WriteLine("\n############################");
            Console.WriteLine("# Transmitting frame 3964r #");
            Console.WriteLine("############################");

	        do
	        {
		        //Initialisation des différents flag
		        //flag_timer1 = FALSE;
		        //flag_usart	= FALSE;
//                _flag_timer = false;
                //this.DiscardInBuffer();    //Reset du buffer du port série

                c = 0;
                _flag_timer = false;
                _flag_error = false;

		        //Envoie du caractère STX
                Console.WriteLine("Tx -> STX");
                this.Write(STX,0,1);

		        //Attend de recevoir un caractère
                try
                {
                    c = this.ReadByte();
                    //this.DiscardInBuffer();
                }
                catch
                {
                    _flag_timer = true;
                }

		        //On vérifie le timeout n'a pas été déclenché
                if (_flag_timer == false)
                {
                    //Si le caractère reçu est un DLE
                    if (c == DLE[0])
                    {
                        Console.WriteLine("Rx <- DLE");
                        //Activation l'interruption de l'usart en reception
                        //Si un caracère est reçu durant l'envoie, flag_usart est mis à TRUE

                        //On envoie le contenu du tableau data[]
                        //En fonction de la longueur donnée en paramètre
                        for (int i = 0; i < str.Length; i++)
                        {
                            //Si on a pas reçu de caractère
                            if (this.BytesToRead == 0)
                            {
                                Console.WriteLine("Tx -> Data " + i.ToString() + " : " + str[i].ToString());
                                //Envoi des caractères du tableau data[]
                                this.Write(str, i, 1);
                                //Traitement du double DLE
                                if (str[i] == DLE[0])
                                {
                                    //Revérification du flag_usart
                                    if (this.BytesToRead == 0)
                                    {
                                        Console.WriteLine("Tx -> DLE (double)");
                                        //Envoi du 2eme DLE
                                        this.Write(DLE, 0, 1);
                                    }
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
                        if (this.BytesToRead == 0)
                        {
                            //Envoi du DLE pour signifier la fin des données utiles
                            this.Write(DLE, 0, 1);
                            Console.WriteLine("Tx -> DLE");
                            //Vérification du flag_usart
                            if (this.BytesToRead == 0)
                            {
                                //Envoi de ETX
                                this.Write(ETX, 0, 1);
                                Console.WriteLine("Tx -> ETX");
                                if (this.BytesToRead == 0)
                                {
                                    Console.WriteLine("Tx -> BCC" + " : " + bcc[0].ToString());
                                    //Envoi du bcc
                                    this.Write(bcc, 0, 1);

                                    //Vérification du flag_usart
                                    if (this.BytesToRead == 0)
                                    {
                                        //Attend la reception d'un caractère
                                        try
                                        {
                                            c = this.ReadByte();
                                            //this.DiscardInBuffer();
                                        }
                                        catch
                                        {
                                            _flag_timer = true;
                                        }

                                        //Vérification que le timeout n'a pas expiré
                                        if (_flag_timer == false)
                                        {
                                            //Si on a reçu un caractère différent de DLE
                                            if (c != DLE[0])
                                            {
                                                //Incrémentation du nombre d'erreurs
                                                tab_error_3964r[1]++;
                                                _flag_timer = true;
                                            }
                                            else
                                                Console.WriteLine("Rx <- DLE");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Timeout error (#2)");
                                            //Incrémentation du nombre d'erreurs
                                            tab_error_3964r[2]++;
                                            _flag_timer = true;
                                        }
                                    }
                                    //Si interruption par l'usart
                                    else
                                    {
                                        Console.WriteLine("Transmission disrupted (#1)");
                                        //Incrémentation du nombre d'erreurs
                                        tab_error_3964r[3]++;
                                        _flag_timer = true;
                                    }
                                }
                                //Si interruption par l'usart
                                else
                                {
                                    Console.WriteLine("Transmission disrupted (#2)");
                                    //Incrémentation du nombre d'erreurs
                                    tab_error_3964r[3]++;
                                    _flag_timer = true;
                                }
                            }
                            //Si interruption par l'usart
                            else
                            {
                                Console.WriteLine("Transmission disrupted (#3)");
                                //Incrémentation du nombre d'erreurs
                                tab_error_3964r[3]++;
                                _flag_timer = true;
                            }
                        }
                        //Si interruption par l'usart
                        else
                        {
                            Console.WriteLine("Transmission disrupted (#4)");
                            //Incrémentation du nombre d'erreurs
                            tab_error_3964r[3]++;
                            _flag_timer = true;
                        }
                    }
                    //Si le 1er caractère reçu n'est pas un DLE
                    else
                    {
                        //Si le caractère est un STX
                        if (c == STX[0])
                        {
                            Console.WriteLine("Rx <- STX");
                            //Vérification du la priorité
                            if (this._highPriority == false)
                            {
                                //Renvoi la valeur RECEPTION_MODE pour avertir que le périphérique Maitre veut envoyer
                                return TRANSMISSION_RECEPTION_MODE;
                                //throw Ex;
                            }
                            else
                            {
                                //flag_timer1 ou flag_usart à TRUE juste pour faire boucler
                                _flag_timer = true;
                            }
                        }
                        //Si le 1er caractère est différent de DLE et STX
                        else
                        {
                            Console.WriteLine("Rx <- not DLE");
                            //Incrémentation du nombre d'erreurs
                            tab_error_3964r[0]++;
                            _flag_timer = true;
                        }
                    }
                }
                //Si le périphérique n'a pas répondu au STX
                else
                {
                    Console.WriteLine("Timeout Error (#1)");
                    //Incrémentation du nombre d'erreurs
                    tab_error_3964r[4]++;
                    _flag_timer = true;
                }

		        //Si la somme des erreurs est supérieur au seuil max
                if (sum_error_3964r() >= MAX_ERRORS)
                {
                    Console.WriteLine("Transmission canceled (Too many errors)");
                    //retourne une erreur de transmission
                    //throw Ex;
                    //return TRANSMISSION_FAILED;
                    _flag_error = true;
                    break;
                }

	        //On boucle tant que flag_timer1 ou flag_usart est a TRUE
	        }while(_flag_timer == true);

	        //la transmission s'est bien déroulée
	        //return TRANSMISSION_SUCCESS;
            if (_flag_error == true)
            {
                Console.WriteLine("Transmission failed !");
                return TRANSMISSION_FAILED;
            }
            else
            {
                Console.WriteLine("Transmission successful !");
                return TRANSMISSION_SUCCESS;
            }
        }

        //Fonction process_bcc_3964r
        //Permet de pré-calculer le bcc avant l'envoi d'une trame
        //Paramètres : - data[] => tableau à envoyer par le protocole
        //			   - lenght => longueur du tableau data[]
        //Valeur de retour : - le bcc pré-calculé
        private byte process_bcc_3964r(byte[] data)
        {
	        byte bcc = 0;

            bcc ^= STX[0];
            for(int i=0; i<data.Length; i++)
	        {
		        bcc ^= data[i];
		        //On compte un double DLE
                if(data[i] == DLE[0])
                    bcc ^= DLE[0];
	        }
            bcc ^= DLE[0];
            bcc ^= ETX[0];

	        return bcc;
        }

        //Fonction sum_error_3964r
        //Permet de compter le nombre d'erreur qui s'est produit pendant l'émission
        //Paramètres : Aucun
        //Valeur de retour : - le nombre d'erreur produite
        byte sum_error_3964r()
        {
	        byte sum, i;

	        for(i=0, sum=0; i<NB_ERRORS; i++)
		        sum += tab_error_3964r[i];

	        return sum;
        }

//Tableau permettant d'identifier les différents erreurs
//Le tableau existe et est rempli mais pas exploité dans le programme
//unsigned char tab_error_3964r[NB_ERRORS];


//Fonction send_data_3964r
//Envoi des données par le protocole 3964 sur le port série
//Paramètres : - data[] => tableau à envoyer par le protocole
//			   - lenght => longueur du tableau data[]
//Valeur de retour : - TRANSMISSION_SUCCESS
//					 - TRANSMISSION_FAILED
//					 - RECEPTION_MODE


//Fonction get_data_3964r
//Recoi des données sur le protocole 3964 par le port série
//Paramètres : - data[] => tableau qui va recevoir les données par le protocole
//Valeur de retour : Aucune
        public int ReadBytes3964r(ref byte[] _data)
        {
            byte bcc;
            int i, c = 0, prev_c = 0;

            Console.WriteLine("\n#########################");
            Console.WriteLine("# Receiving frame 3964r #");
            Console.WriteLine("#########################");

            _flag_error = false;

            _data[0] = 0;
            _data[1] = 0;
            _data[2] = 0;
            //do
            //{
                this.DiscardInBuffer();
                //Initialisation des variables
                i = 0;
                prev_c = 0;
                _flag_timer = false;
	
                //On attend de recevoir un caractère
                try
                {
                    c = this.ReadByte();
                }
                catch
                {
                    _flag_timer = true;
                }

                //Si on reçoi un STX
                if(c == STX[0])
                {
                    Console.WriteLine("Rx <- STX");
                    //Calcul du bcc
                    bcc = STX[0];

                    Console.WriteLine("Tx -> DLE");
                    //On répond DLE
                    this.Write(DLE,0,1);

                    //On attend de recevoir un caractère
                    try
                    {
                        _data[0] = (byte)this.ReadByte();
                        bcc ^= (byte)_data[0];
                        Console.WriteLine("Rx <- Data 1 : " + _data[0].ToString());
                        if (_data[0] == DLE[0])
                        {
                            _data[0] = (byte)this.ReadByte();
                            bcc ^= (byte)_data[0];
                            Console.WriteLine("Rx <- Data 1 (DLE 2x) : " + _data[0].ToString());
                        }

                        _data[1] = (byte)this.ReadByte();
                        bcc ^= (byte)_data[1];
                        Console.WriteLine("Rx <- Data 2 : " + _data[1].ToString());
                        if (_data[1] == DLE[0])
                        {
                            _data[1] = (byte)this.ReadByte();
                            bcc ^= (byte)_data[1];
                            Console.WriteLine("Rx <- Data 2 (DLE 2x) : " + _data[1].ToString());
                        }

                        _data[2] = (byte)this.ReadByte();
                        bcc ^= (byte)_data[2];
                        Console.WriteLine("Rx <- Data 3 : " + _data[2].ToString());
                        if (_data[2] == DLE[0])
                        {
                            _data[2] = (byte)this.ReadByte();
                            bcc ^= (byte)_data[2];
                            Console.WriteLine("Rx <- Data 2 (DLE 2x) : " + _data[2].ToString());
                        }
                        c = this.ReadByte();
                        bcc ^= (byte)c;
                    }
                    catch
                    {
                        _flag_timer = true;
                    }

                    ////Début de la boucle de réception
                    //do
                    //{
                    //    //Démarrage du timer avec la valeur de timeout TIMEOUT_MS
                    //    //start_timer1(TIMEOUT_MS);
                    //    //Attend de recoir un caractère
                    //    //Passage à l'instruction suivant si le timeout est déclenché (flag_timer1 == TRUE)
                    //    try
                    //    {
                    //        //this.ReadTimeout = InfiniteTimeout;
                    //        c = this.ReadByte();
                    //        //this.DiscardInBuffer();
                    //    }
                    //    catch
                    //    {
                    //        _flag_timer = true;
                    //    }

                    //    //Si le timeout n'a pas expiré
                    //    if(_flag_timer == false)
                    //    {
                    //        //Calcul du bcc					
                    //        bcc ^= (byte)c;

                    //        //Machine d'état pour le contrôle des double DLE
                    //        //Cette machine d'état permet de différencier 
                    //        //les doubles DLE et le DLE de terminaison des données utiles.

                    //        //Si le caractère précédent est différent d'un DLE et que le caractère reçu est un DLE
                    //        if((prev_c != DLE[0]) && (c == DLE[0]))
                    //        {
                    //            //Mise à jour des états
                    //            this._flag_dle[0] = true;
                    //            this._flag_dle[1] = false;
                    //            this._flag_dle[2] = false;
                    //        }
                    //        else
                    //        {
                    //            //Si on est en présence d'un double DLE
                    //            if((prev_c == DLE[0]) && (c == DLE[0]))
                    //            {
                    //                //Vérification d'état (1er passage)
                    //                //if(flag_dle[1] == FALSE)
                    //                if(this._flag_dle[1] == false)
                    //                {
                    //                    //Mise à jour des états
                    //                    this._flag_dle[0] = false;
                    //                    this._flag_dle[1] = true;
                    //                    this._flag_dle[2] = false;
								
                    //                    //Place la valeur DLE dans le tabeau data
                    //                    this._data[i] = DLE[0];
                    //                    //Incrémentation de l'indice du tableau
                    //                    i++;
                    //                }
                    //                //Si 3 DLE consécutifs
                    //                else
                    //                {
                    //                    //Mise à jour des états
                    //                    this._flag_dle[0] = true;
                    //                    this._flag_dle[1] = false;
                    //                    this._flag_dle[2] = false;
                    //                }
                    //            }
                    //            //Si le caractère actuelle ou le précédent est différents de DLE
                    //            else
                    //            {
                    //                //Si le caractère présent est différent de DLE mais que le précédent est un DLE
                    //                if((prev_c == DLE[0]) && (c != DLE[0]))
                    //                {
                    //                    //Mise à jour des états
                    //                    this._flag_dle[1] = false;
                    //                    this._flag_dle[2] = true;
								
                    //                    //Place la valeur c dans le tabeau data
                    //                    this._data[i] = (byte)c;
                    //                    //Incrémentation de l'indice du tableau
                    //                    i++;
                    //                }

                    //                else
                    //                {
                    //                    //Mise à jour des états
                    //                    this._flag_dle[0] = false;
                    //                    this._flag_dle[1] = false;
                    //                    this._flag_dle[2] = false;
								
                    //                    //Place la valeur c dans le tabeau data
                    //                    this._data[i] = (byte)c;
                    //                    //Incrémentation de l'indice du tableau
                    //                    i++;
                    //                }
                    //            }
                    //        }
                    //        //Sauvegarde de la valeur actuelle dans la variable du caractère précédent
                    //        prev_c = c;
                    //    }
                    //    //Si le timeout a expiré
                    //    else
                    //    {
                    //        //Envoi du caractère NAK
                    //        this.Write(NAK,0,1);
                    //        //Sort de la boucle de reception
                    //        break;
                    //    }
                    ////On continue de recevoir des caractères tant que on a pas déterminer le DLE de terminaison
                    //}while(!((this._flag_dle[0] == true) && (this._flag_dle[2] == true)));

                    //Si le timeout n'a pas expiré
                    if(this._flag_timer == false)
                    {
                        if (c == DLE[0])
                        {
                            Console.WriteLine("Rx <- DLE");

                            //On attend de recevoir un caractère
                            try
                            {
                                c = this.ReadByte();
                                bcc ^= (byte)c;
                            }
                            catch
                            {
                                _flag_timer = true;
                            }

                            //Si le timeout n'a pas expiré
                            if (this._flag_timer == false)
                            {

                                //Si le caractère dernier après le DLE est ETX
                                if (c == ETX[0])
                                {
                                    Console.WriteLine("Rx <- ETX");
                                    //Attend de recevoir un caractère sur le port série
                                    try
                                    {
                                        c = this.ReadByte();
                                        //this.DiscardInBuffer();
                                    }
                                    catch
                                    {
                                        this._flag_timer = true;
                                    }

                                    //Si le timeout n'a pas expiré
                                    if (this._flag_timer == false)
                                    {
                                        //Si le bcc reçu est égale au bcc calculé
                                        if (c == bcc)
                                        {
                                            Console.WriteLine("Rx <- BCC [OK]");
                                            //Envoi d'un DLE
                                            this.Write(DLE, 0, 1);
                                            Console.WriteLine("Tx -> DLE");
                                        }
                                        //Si échec de BCC
                                        else
                                        {
                                            Console.WriteLine("Rx <- BCC [Failed]");
                                            Console.WriteLine("Tx -> NAK");
                                            //Envoi un NAK
                                            this.Write(NAK, 0, 1);
                                            this._flag_error = true;
                                        }

                                    }
                                    //Si timeout expiré
                                    else
                                    {
                                        Console.WriteLine("Timeout error (#2)");
                                        Console.WriteLine("Tx -> NAK");
                                        //Envoi un NAK
                                        this.Write(NAK, 0, 1);
                                        this._flag_error = true;
                                    }

                                }
                                //Si le caractère après le DLE n'est pas ETX
                                else
                                {
                                    Console.WriteLine("Rx <- not ETX");
                                    Console.WriteLine("Tx -> NAK");
                                    //Envoi un NAK
                                    this.Write(NAK, 0, 1);
                                    this._flag_error = true;
                                }
                            }
                            //Si le timeout a expiré
                            else
                            {
                                Console.WriteLine("Timeout error (#1)");
                                Console.WriteLine("Tx -> NAK");
                                //Envoi un NAK
                                this.Write(NAK, 0, 1);
                                this._flag_error = true;
                            }
                        }
                        //Si le caractère n'est pas un DLE
                        else
                        {
                            Console.WriteLine("Rx <- not DLE");
                            Console.WriteLine("Tx -> NAK");
                            //Envoi un NAK
                            this.Write(NAK, 0, 1);
                            this._flag_error = true;
                        }
                    }
                    //Si le timeout a expiré
                    else
                    {
                        Console.WriteLine("Timeout error (#1)");
                        Console.WriteLine("Tx -> NAK");
                        //Envoi un NAK
                        this.Write(NAK,0,1);
                        this._flag_error = true;
                    }
                }
                //Si le 1er caractère de la trame n'est pas STX
                else
                {
                    Console.WriteLine("Rx <- not STX");
                    Console.WriteLine("Tx -> NAK");
                    //Envoi un NAK
                    this.Write(NAK,0,1);
                    this._flag_error = true;
                }
            //On continue la reception tant que le flag_timer1 ou le flag_error est à TRUE
            //} while ((this._flag_timer == true) || (this._flag_error == true));
            if (this._flag_error == true)
                return RECEPTION_FAILED;
            else
                return RECEPTION_SUCCESS;
        }
    }
}
