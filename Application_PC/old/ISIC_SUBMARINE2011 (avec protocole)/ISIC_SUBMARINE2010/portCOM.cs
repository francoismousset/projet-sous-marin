using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;                            // IO du pc --> Ports
using System.IO.Ports;                      // Ports du PC
using ISIC_SUBMARINE2010;
using System.Timers;

namespace isic_submarine_com
{
    public partial class FormPortCom : Form
    {
        private BO_serie parent;

        public FormPortCom(BO_serie parent)
        {
            this.parent = parent;

            InitializeComponent();
            ControlBox = false;
            PortCom.DataSource = SerialPort.GetPortNames();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (PortCom.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un port COM");
            }
            else
            {
                parent.connect(PortCom.SelectedItem.ToString());
            }
        }

        private void FormPortCom_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }

    public partial class BO_serie
    {
        SousMarin parent;
        public FormConsole Console;

        public SerialPort serialPort;

        private int baudrate = 300;
        private int nbBits = 8;
        private string parite = "NONE";
        private string stopBits = "ONE";
        private int readBufferSize = 4096;
        private int readTimeOut = -1;
        private int writeBufferSize = 4096;
        private int writeTimeOut = -1;

        BO_tableau tableau_de_donnee;
        Boolean newProfondeur = false;
        Boolean newInclinaisonX = false;
        Boolean newInclinaisonY = false;
        Boolean newPositionAvant = false;
        Boolean newPositionArriere = false;
        Boolean newData = false;

        String dataSerie;
        
        FormPortCom DemandePortCom;

        public BO_serie(SousMarin cs_parent, int cs_baudrate, int cs_nbBits, string cs_parite, string cs_stopBits, int cs_readBufferSize, int cs_writeBufferSize, int cs_readTimeOut, int cs_writeTimeOut)//, ref bool flag_A)
        {
            parent = cs_parent;

            Console = new FormConsole(parent);

            dataSerie = new String("".ToCharArray());
            baudrate = cs_baudrate;
            nbBits = cs_nbBits;
            parite = cs_parite;
            stopBits = cs_stopBits;
            readBufferSize = cs_readBufferSize;
            readTimeOut = cs_readTimeOut;
            writeBufferSize = cs_writeBufferSize;
            writeTimeOut = cs_writeTimeOut;

            serialPort = new SerialPort();
            tableau_de_donnee = new BO_tableau();

            DemandePortCom = new FormPortCom(this);
            DemandePortCom.ShowDialog();
        }

        ~BO_serie() //destructeur
        {
            serialPort.Close();
        }

        private void alertConnexion()
        {
            MessageBox.Show("Veuillez vous connecter avant d'utiliser le port");
        }

        private void alertDeconnexion()
        {
            MessageBox.Show("Veuillez vous déconnecter avant de modifier ce paramètre");
        }

        /*
         * SET
         */

        public void setPort()
        {
            if (serialPort.IsOpen)
                alertDeconnexion();
            else
                DemandePortCom.ShowDialog();
        }

        public void setBaudrate(int baudrate)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.BaudRate=baudrate;

            serialPort.Open();
        }

        public void setNombreBits(int nbbits)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.DataBits = nbbits;

            serialPort.Open();
        }

        public void setReadBufferSize(int size)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.ReadBufferSize = size;

            serialPort.Open();
        }

        public void setReadTimeOut(int timeout)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.ReadTimeout = timeout;

            serialPort.Open();
        }

        public void setWriteTimeOut(int timeout)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.WriteTimeout = timeout;

            serialPort.Open();
        }

        public void setWriteBufferSize(int size)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.WriteBufferSize = size;

            serialPort.Open();
        }

        public void setParity(string parity)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            switch (parite)
            {
                case "NONE": serialPort.Parity = Parity.None;
                    break;
                case "ODD": serialPort.Parity = Parity.Odd;
                    break;
                case "EVEN": serialPort.Parity = Parity.Even;
                    break;
                case "MARK": serialPort.Parity = Parity.Mark;
                    break;
                case "SPACE": serialPort.Parity = Parity.Space;
                    break;
                default: serialPort.Parity = Parity.None;
                    break;
            }

            serialPort.Open();
        }

        public void setStopBits(string stopBits)
        {
            if (serialPort.IsOpen)
                serialPort.Close();

            switch (stopBits)
            {
                case "NONE": serialPort.StopBits = StopBits.None;
                    break;
                case "ONE": serialPort.StopBits = StopBits.One;
                    break;
                case "TWO": serialPort.StopBits = StopBits.Two;
                    break;
                case "ONEPOINTFIVE": serialPort.StopBits = StopBits.OnePointFive;
                    break;
                default: serialPort.StopBits = StopBits.One;
                    break;
            }

            serialPort.Open();
        }

        public void fermerPort()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
            else
                alertConnexion();
        }

        public void connect(string portCom)
        {

            switch (parite)
            {
                case "NONE": serialPort.Parity = Parity.None;
                    break;
                case "ODD": serialPort.Parity = Parity.Odd;
                    break;
                case "EVEN": serialPort.Parity = Parity.Even;
                    break;
                case "MARK": serialPort.Parity = Parity.Mark;
                    break;
                case "SPACE": serialPort.Parity = Parity.Space;
                    break;
                default: serialPort.Parity = Parity.None;
                    break;
            }

            switch (stopBits)
            {
                case "NONE": serialPort.StopBits = StopBits.None;
                    break;
                case "ONE": serialPort.StopBits = StopBits.One;
                    break;
                case "TWO": serialPort.StopBits = StopBits.Two;
                    break;
                case "ONEPOINTFIVE": serialPort.StopBits = StopBits.OnePointFive;
                    break;
                default: serialPort.StopBits = StopBits.One;
                    break;
            }

            serialPort.PortName = portCom;
            serialPort.BaudRate = baudrate;
            serialPort.DataBits = nbBits;
            serialPort.ReadBufferSize = readBufferSize;
            serialPort.ReadTimeout = readTimeOut;
            serialPort.WriteBufferSize = writeBufferSize;
            serialPort.WriteTimeout = writeTimeOut;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.ReceivedBytesThreshold = 1;
            //serialPort.Handshake = Handshake.None;
            //serialPort.DtrEnable = false;
            //serialPort.RtsEnable = false;

            serialPort.Open();

            DemandePortCom.Close();
            //parent.BO_communication.Console.ConnexionActive(true);
            Console.ConnexionActive(true);
        }

        public void write(char[] data)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(data, 0, data.Length);
            }
            else
                alertConnexion();
        }

        public void write(byte[] data)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(data, 0, 2);
            }
            else
                alertConnexion();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        const byte STX = 0x02;  // caractère de contrôle Start of TeXt = (02H)
        const byte ETX = 0x03;  // caractère de contrôle End of TeXt = (03H)
        const byte DLE = 0x10;  // caractère de contrôle Data Link Escape = (10H)
        const byte NAK = 0x15;  // caractère de contrôle Negative AcKnoledgement = (15H)

        bool FLAG_TIMER0;                   // définit un flag pour le TIMEOUT
        static bool flag_debut;             // définit un flag pour signaler que le caractère STX de début de communication est reçu et qu'on a répondu DLE
        static bool flag_longueur_trame_3;  // définit un flag pour signaler que la longueur de trame reçue est égale à 3 (donées utiles)

        static byte bcc;    // byte BCC (Block Check Character)

        private void serialPort_DataReceived(object sender, EventArgs e)   // fonction de réception de donnée(s) : dès que quelque chose arrive sur le port série, la fonction est appélée
        { 
            int valeur = 0;   // entier pour pouvoir exploiter la valeur reçue
            
            FLAG_TIMER0 = true;    // on initialise le flag du timer0 à false

            byte[] c = new byte[serialPort.BytesToRead];    // on mettra les bytes reçus dans le tableau de bytes c
            serialPort.Read(c, 0, serialPort.BytesToRead); // lit les bytes reçus et met dans c
            serialPort.DiscardInBuffer();   // vide le tampon

            if (c.Length == 1 && c[0] == STX && flag_debut == false) //si on reçoit un STX comme premier caractère [la FOX envoie un STX pour commencer une communication => on répond un DLE]
            {
                parent.EcritureSerie("DLE");
                flag_debut = true;      // on indique que la communication a débuté : passage du flag à true
                timer0.BeginInit();
                timer0.Start(); // on démarre le timer0 pour attendre réception des données sivantes

                bcc = 0; // initialisation du BCC
            }

            else    // si on ne reçoit pas le premier caractère (STX) de début de communication
            {
                if (flag_debut == true) // si on a déjà entamé la communication, càd STX reçu et DLE envoyé
                {
                    if (FLAG_TIMER0 == true && c.Length == 3 && flag_longueur_trame_3 == true && c[0] == DLE && c[1] == ETX) //FIN DE COMMUNICATION : longueur trame = 3 , DLE-ETX-BCC reçus et BCC ok => envoi de DLE
                    {
                        if (c[2] == Convert.ToChar("bcc"))  // si le BCC reçu et celui calculé condcordent : envoi de DLE => communication réussie
                        {
                            timer0.Stop();
                            parent.EcritureSerie("DLE");
                            flag_debut = true;  // remise à zéro du flag pour attendre une nouvelle communication
                        }
                        else    // si les deux BCC sont différents : on envoie un NAK
                        {
                            parent.EcritureSerie("NAK");
                            flag_debut = true;  // remise à zéro du flag pour attendre une nouvelle communication
                            timer0.Stop();
                        }

                        flag_longueur_trame_3 = false;  // remise à zéro du flag
                    }

                    else    // sinon (pas fin ou début de communication)
                    {
                        if (FLAG_TIMER0 == true && c.Length >= 3 && flag_longueur_trame_3 == false) // si le timer n'est pas arrivé à son terme, que la trame de bytes reçue est de longueurs de min. 3 et qu'on n'a pas encore reçu les données utiles
                        {
                            char[] data = new char[3];  // création d'un tableau de caractères de taille = 3

                            int k = 0, l=0;  // indices pour les boucles dans le cas de réception de deux (ou plus) DLE d'affilée

                            bcc ^= c[0]; // calcul du BCC

                            data[l] = Convert.ToChar(c[0]); // on convertit le premier byte en caractère, il déterminera le type de valeur reçue (le type du capteur)
                            l++;

                            do   // boucle de traitement en cas de double DLE
                            {
                                if (c[k] == DLE && c[k + 1] == DLE)  // si deux DLE d'affilée : si le byte présent et le suivant sont = DLE : on passe au suivant (k+1) et on ne tient pas compte du byte présent (k)
                                {
                                    k++;
                                }
                                else
                                {
                                    if (l == 1)  // cas de data[1]
                                    {
                                        data[l] = Convert.ToChar(c[k + 1]); // sinon on convertit le byte suivant (k+1) en caractère
                                        l++;
                                        bcc ^= c[k + 1];  // continue le calcul de BCC
                                        k++;    // passage au byte suivant
                                    }
                                    else   // cas de data[2]
                                    {
                                        if (c[k] == DLE && c[k + 1] == DLE)   // si deux DLE d'affilée : si le byte présent et le suivant sont = DLE : on passe au suivant (k+1) et on ne tient pas compte du byte présent (k)
                                        {
                                            k++;
                                        }
                                        else
                                        {
                                            data[l] = Convert.ToChar(c[k + 1]);    // sinon on convertit le byte suivant (k+1) en caractère
                                            bcc ^= c[k + 1];  // continue le calcul de BCC
                                            k++;
                                        }
                                    }
                                }
                            } while (data.Length == 3);  // boucle effectuée tant que la taille du tableau data n'est pas égale à 3


                            valeur = valeur = Convert.ToInt32((data[1] * 256) + data[2]);   // traitement des données utiles : deux derniers des trois bytes = valeur envoyée par la Fox

                            flag_longueur_trame_3 = true;   // remise à zéro (false) du flag

                            switch (data[0])    // traitement dans les différents cas en fonction du premier octet utile
                            {
                                case 'A':   // Cas : Profondeur
                                    tableau_de_donnee.setProfondeur(valeur);    // Stocke la valeur dans la base de données et bascule un flag de confirmation
                                    newProfondeur = true;
                                    break;
                                case 'C':   // Cas : Axe X
                                    tableau_de_donnee.setInclinaisonX(valeur);
                                    newInclinaisonX = true;
                                    break;
                                case 'E':   // Cas : Axe Y
                                    tableau_de_donnee.setInclinaisonY(valeur);
                                    newInclinaisonY = true;
                                    break;
                                case 'G':   // Cas : Ballast 0
                                    tableau_de_donnee.setBallastAvant(valeur);
                                    newPositionAvant = true;
                                    break;
                                case 'I':   // Cas : Ballast 1
                                    tableau_de_donnee.setBallastArriere(valeur);
                                    newPositionArriere = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else   // Sinon envoi de NAK et attente de nouvelle communication
                        {
                            parent.EcritureSerie("NAK");
                            flag_debut = true;
                            timer0.Stop();
                        }
                    }
                }
                else     // sinon on envoi un NAK
                {
                    parent.EcritureSerie("NAK");
                    flag_debut = true;
                }
            }
        }




        public System.Timers.Timer timer0;  //TIMEOUT

        public void TIMER0()   // fonction TIMEOUT, 25ms
        {
            System.Timers.Timer timer0 = new System.Timers.Timer();
            timer0.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer0.Interval = 25;
            timer0.Enabled = true;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e) // si événement (fin) sur TIMEOUT : on change le flag : passage à false
        {
            FLAG_TIMER0 = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public String getData()
        {
            String temp = dataSerie.ToString();
            newData=false;
            dataSerie="";

            return temp;
        }

        public int getProfondeur()
        {
            newProfondeur = false;
            return tableau_de_donnee.getProfondeur();
        }

        public int getInclinaisonX()
        {
            newInclinaisonX = false;
            return tableau_de_donnee.getInclinaisonX();
        }

        public int getInclinaisonY()
        {
            newInclinaisonY = false;
            return tableau_de_donnee.getInclinaisonY();
        }

        public int getPositionAvant()
        {
            newPositionAvant = false;
            return tableau_de_donnee.getBallastAvant();
        }

        public int getPositionArriere()
        {
            newPositionArriere = false;
            return tableau_de_donnee.getBallastArriere();
        }

        public Boolean IsData()
        {
            return newData;
        }

        public Boolean ProfondeurIsNew()
        {
            return newProfondeur;
        }

        public Boolean PositionAvantIsNew()
        {
            return newPositionAvant;
        }

        public Boolean PositionArriereIsNew()
        {
            return newPositionArriere;
        }

        public Boolean InclinaisonXIsNew()
        {
            return newInclinaisonX;
        }

        public Boolean InclinaisonYIsNew()
        {
            return newInclinaisonY;
        }
    }

    public partial class BO_tableau
    {
        private CapteurInclinaison Inclinaison;
        private CapteursBallasts BallastAvant;
        private CapteursBallasts BallastArriere;
        private CapteurProfondeur Profondeur;
        private MoteursBallasts MoteurAvant;
        private MoteursBallasts MoteurArriere;

        public BO_tableau()
        {
            Inclinaison = new CapteurInclinaison();

            BallastArriere = new CapteursBallasts();
            BallastAvant = new CapteursBallasts();

            Profondeur = new CapteurProfondeur();

            MoteurAvant = new MoteursBallasts();
            MoteurArriere = new MoteursBallasts();
        }

        public int getProfondeur()
        {
            return Profondeur.getProfondeur();
        }

        public int getBallastAvant()
        {
            return BallastAvant.getPositionBallast1();
        }

        public int getBallastArriere()
        {
            return BallastArriere.getPositionBallast2();
        }

        public int getInclinaisonX()
        {
            return Inclinaison.getInclinaisonAxeX();
        }

        public int getInclinaisonY()
        {
            return Inclinaison.getInclinaisonAxeY();
        }

        public int getMoteurAvant()
        {
            return MoteurAvant.getConsigneBallast1();
        }

        public int getMoteurArriere()
        {
            return MoteurArriere.getConsigneBallast2();
        }
        public void setInclinaisonX(int value)
        {
            Inclinaison.setInclinaisonAxeX(value);
        }

        public void setInclinaisonY(int value)
        {
            Inclinaison.setInclinaisonAxeY(value);
        }

        public void setProfondeur(int value)
        {
            Profondeur.setProfondeur(value);
        }

        public void setBallastAvant(int value)
        {
            BallastAvant.setPositionBallast1(value);
        }

        public void setBallastArriere(int value)
        {
            BallastArriere.setPositionBallast2(value);
        }

        public void setMoteurAvant(int Value)
        {
            MoteurAvant.setConsigneBallast1(Value);
        }

        public void setMoteurArriere(int Value)
        {
            MoteurArriere.setConsigneBallast2(Value);
        }
    }
}
