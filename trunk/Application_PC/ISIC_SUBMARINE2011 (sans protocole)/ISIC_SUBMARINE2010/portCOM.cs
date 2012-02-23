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



        /////////////////////////////////////////////////////////////////////////////////////////////////////


        private void serialPort_DataReceived(object sender, EventArgs e)    // On entre dans cette fonction dès que quelque chose arrive sur le port série
        {
            char[] buffer = new char[serialPort.BytesToRead];   // Crée un tableau de caractères (buffer) de taille égale au nombre de bytes présents sur le ports série
            serialPort.Read(buffer, 0, serialPort.BytesToRead); // Stocke les bytes présents sur le port série dans un tableau de caractères : buffer
            serialPort.DiscardInBuffer();   // Vide le tampon du port série

            //for (int i = 0; i < buffer.Length ; i++)
            //{
            //    dataSerie += buffer[i];
            //}

            newData = true;

            if (buffer.Length == 3) // Si la taille du tableau est égale à 3
            {
                int valeur;

                valeur = (buffer[1] * 256) + buffer[2]; // On exploite les données utiles : les deux derniers des 3 bytes = valeur réelle

                switch (buffer[0])  // Le premier byte = indique le type de valeur reçue
                {
                    case 'A':   // Cas : Profondeur
                        tableau_de_donnee.setProfondeur(valeur);    // Stocke la valeur dans la base de données et bascule un flag
                        newProfondeur = true;

                        parent.flag_A = true;   // Flag pour indiquer dans FormTelecommande.cs que la réception est effectuée

                        break;
                    case 'C':   // Cas : Inclinaison axe X
                        tableau_de_donnee.setInclinaisonX(valeur);
                        newInclinaisonX = true;

                        parent.flag_C = true;

                        break;
                    case 'E':   // Cas : Inclinaison axe Y
                        tableau_de_donnee.setInclinaisonY(valeur);
                        newInclinaisonY = true;

                        parent.flag_E = true;

                        break;
                    case 'G':   // Cas : Position Ballast 0
                        tableau_de_donnee.setBallastAvant(valeur);
                        newPositionAvant = true;

                        parent.flag_G = true;

                        break;
                    case 'I':   // Cas : Position Ballast 1
                        tableau_de_donnee.setBallastArriere(valeur);
                        newPositionArriere = true;

                        parent.flag_I = true;

                        break;
                    default:
                        break;
                }
                serialPort.DiscardInBuffer();   // Vide le tampon du port série
            }
            else 
            {
                serialPort.DiscardInBuffer();   // Vide le tampon du port série
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

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
