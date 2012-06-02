using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ISIC_SUBMARINE2010;

using System.Timers;
using System.IO;                            // IO du pc --> Ports
using System.IO.Ports;                      // Ports du PC

namespace ISIC_SUBMARINE2010
{
    public partial class FormTelecommande : Form
    {        
        private SousMarin parent;

        private Boolean flagLierBallastAvant = false;
        private Boolean flagLierBallastArriere = false;

        public FormTelecommande(SousMarin parent)
        {
            InitializeComponent();
            this.parent = parent;
            
        }

        // SET

        public void setPositionBallastAvant(int Valeur)
        {
            BarreBallastAvant.Value = Valeur;
            ValeurPositionBallastAvant.Text = BarreBallastAvant.Value.ToString();
        }

        public void setPositionBallastArriere(int Valeur)
        {
            BarreBallastArriere.Value = Valeur;
            ValeurPositionBallastArriere.Text = BarreBallastArriere.Value.ToString();
        }

        public void setVitessseMoteur1(int Valeur)
        {
            LabelVitesseMoteur1.Text = "Vitesse moteur 1 : "  +Valeur.ToString() + " tr/min";
        }

        public void setVitessseMoteur2(int Valeur)
        {
            LabelVitesseMoteur2.Text = "Vitesse moteur 2 : " + Valeur.ToString() + " tr/min";
        }

        public void setProfondeur(int Valeur)
        {
            LabelProfondeur.Text = "Profondeur : " + Valeur.ToString() + " mm";
        }

        public void setInclinaisonAxeX(int Valeur)
        {
            LabelInclinaisonAxeX.Text = "Inclinaison axe X : " + Valeur.ToString() + " °";
        }

        public void setInclinaisonAxeY(int Valeur)
        {
            LabelInclinaisonAxeY.Text = "Inclinaison axe Y : " + Valeur.ToString() + " °";
        }

        public void setTensionBatterie1(int Valeur)
        {
            LabelTensionBatterie1.Text = "Tension batterie 1 : " + Valeur.ToString() + " V";
        }

        public void setTensionBatterie2(int Valeur)
        {
            LabelTensionBatterie2.Text = "Tension batterie 2 : " + Valeur.ToString() + " V";
        }

        public void setTensionCourant1(int Valeur)
        {
            LabelCourantBatterie1.Text = "Courant batterie 1 : " + Valeur.ToString() + " A";
        }

        public void setTensionCourant2(int Valeur)
        {
            LabelCourantBatterie2.Text = "Courant batterie 2 : " + Valeur.ToString() + " A";
        }

        public void setTemperature(int Valeur)
        {
            LabelTemperature.Text = "Temperature : " + Valeur.ToString() + " °C";
        }

        public void setHumidite(int Valeur)
        {
            LabelHumidite.Text = "Taux d'humidité : " + Valeur.ToString() + " %";
        }

        // GET

        public int getConsigneBallastAvant()
        {
            return CurseurBallastAvant.Value;
        }

        public int getConsigneBallastArriere()
        {
            return CurseurBallastArriere.Value;
        }

        public int getConsignePropulsion()
        {
            return CurseurPropulsion.Value;
        }

        // lorsque les curseurs ont été déplacés par la souris ou le clavier

        private void CurseurBallastAvant_MouseUp(object sender, MouseEventArgs e)
        {
            parent.RafraichissementSousMarin();

            EnvoiBallastAvant();

            if (LierBallast.Checked)
            {
                EnvoiBallastArriere();
            }
        }

        private void CurseurBallastAvant_KeyUp(object sender, KeyEventArgs e)
        {
            parent.RafraichissementSousMarin();

            EnvoiBallastAvant();

            if (LierBallast.Checked)
            {
                EnvoiBallastArriere();
            }
        }

        private void CurseurBallastArriere_MouseUp(object sender, MouseEventArgs e)
        {
            parent.RafraichissementSousMarin();

            EnvoiBallastArriere();

            if (LierBallast.Checked)
            {
                EnvoiBallastAvant();
            }
        }

        private void CurseurBallastArriere_KeyUp(object sender, KeyEventArgs e)
        {
            parent.RafraichissementSousMarin();

            EnvoiBallastArriere();

            if (LierBallast.Checked)
            {
                EnvoiBallastAvant();
            }
        }

        private void CurseurPropulsion_MouseUp(object sender, MouseEventArgs e)
        {
            parent.RafraichissementSousMarin();
        }

        private void CurseurPropulsion_KeyUp(object sender, KeyEventArgs e)
        {
            parent.RafraichissementSousMarin();
        }

        private void BoutonSTOP_Click(object sender, EventArgs e)
        {
            CurseurPropulsion.Value = 512;
            parent.RafraichissementSousMarin();
        }

        // mise à jour des textbox à coté des curseurs et fonction Lier les ballasts

        private void CurseurBallastAvant_ValueChanged(object sender, EventArgs e)
        {
            if ((LierBallast.Checked) && (flagLierBallastArriere == false))
            {
                flagLierBallastAvant = true;
                if (CurseurBallastAvant.Value > Convert.ToInt16(ValeurConsigneBallastAvant.Text)) // curseur +1
                {
                    if (CurseurBallastArriere.Value + (CurseurBallastAvant.Value - Convert.ToInt16(ValeurConsigneBallastAvant.Text)) > 1023)
                    {
                        CurseurBallastAvant.Value = (Convert.ToInt16(ValeurConsigneBallastAvant.Text) + 1023 - CurseurBallastArriere.Value);
                        CurseurBallastArriere.Value = 1023;
                    }
                    else
                    {
                        CurseurBallastArriere.Value += (CurseurBallastAvant.Value - Convert.ToInt16(ValeurConsigneBallastAvant.Text));
                    }
                }
                else
                {
                    if ((CurseurBallastArriere.Value - (Convert.ToInt16(ValeurConsigneBallastAvant.Text) - CurseurBallastAvant.Value)) < 0)
                    {
                        CurseurBallastAvant.Value = (Convert.ToInt16(ValeurConsigneBallastAvant.Text) - CurseurBallastArriere.Value);
                        CurseurBallastArriere.Value = 0;
                    }
                    else
                    {
                        CurseurBallastArriere.Value -= (Convert.ToInt16(ValeurConsigneBallastAvant.Text) - CurseurBallastAvant.Value);
                    }
                }
            }
            else
            {
                flagLierBallastArriere = false;
            }

            ValeurConsigneBallastAvant.Text = CurseurBallastAvant.Value.ToString();
        }

        private void CurseurBallastArriere_ValueChanged(object sender, EventArgs e)
        {
            if ((LierBallast.Checked) && (flagLierBallastAvant == false))
            {
                flagLierBallastArriere = true;
                if (CurseurBallastArriere.Value > Convert.ToInt16(ValeurConsigneBallastArriere.Text)) // curseur +1
                {
                    if (CurseurBallastAvant.Value + (CurseurBallastArriere.Value - Convert.ToInt16(ValeurConsigneBallastArriere.Text)) > 1023)
                    {
                        CurseurBallastArriere.Value = (Convert.ToInt16(ValeurConsigneBallastArriere.Text) + 1023 - CurseurBallastAvant.Value);
                        CurseurBallastAvant.Value = 1023;
                    }
                    else
                    {
                        CurseurBallastAvant.Value += (CurseurBallastArriere.Value - Convert.ToInt16(ValeurConsigneBallastArriere.Text));
                    }
                }
                else
                {
                    if ((CurseurBallastAvant.Value - (Convert.ToInt16(ValeurConsigneBallastArriere.Text) - CurseurBallastArriere.Value)) < 0)
                    {
                        CurseurBallastArriere.Value = (Convert.ToInt16(ValeurConsigneBallastArriere.Text) - CurseurBallastAvant.Value);
                        CurseurBallastAvant.Value = 0;
                    }
                    else
                    {
                        CurseurBallastAvant.Value -= (Convert.ToInt16(ValeurConsigneBallastArriere.Text) - CurseurBallastArriere.Value);
                    }
                }
            }
            else
            {
                flagLierBallastAvant = false;
            }

            ValeurConsigneBallastArriere.Text = CurseurBallastArriere.Value.ToString();
        }

        private void CurseurPropulsion_ValueChanged(object sender, EventArgs e)
        {

            ValeurConsignePropulsion.Text = CurseurPropulsion.Value.ToString();
        }

        // fonctions d'envoi vers le série

        private void EnvoiBallastAvant()
        {
            parent.BO_communication.Console.ajoutString("\n> envoi : K + " + (CurseurBallastAvant.Value >> 8).ToString() + " + " + (CurseurBallastAvant.Value & 0xFF).ToString() + "\n");
            byte[] temp = new byte[2];

            //parent.EcritureSerie("K\n");
            Envoi_data(Convert.ToByte("K\n"));
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastAvant.Value >> 8);
            temp[1] = Convert.ToByte('\n');
            //parent.EcritureSerie(temp);
            Envoi_data(Convert.ToByte(temp));
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastAvant.Value & 0xFF);
            temp[1] = Convert.ToByte('\n');
            //parent.EcritureSerie(temp);
            Envoi_data(Convert.ToByte(temp));
        }

        private void EnvoiBallastArriere()
        {
            parent.BO_communication.Console.ajoutString("\n> envoi : M + " + (CurseurBallastArriere.Value >> 8).ToString() + " + " + (CurseurBallastArriere.Value & 0xFF).ToString() + "\n");
            byte[] temp = new byte[2];

            //parent.EcritureSerie("M\n");
            Envoi_data(Convert.ToByte("M\n"));
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastArriere.Value >> 8);
            temp[1] = Convert.ToByte('\n');
            //parent.EcritureSerie(temp);
            Envoi_data(Convert.ToByte(temp));
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastArriere.Value & 0xFF);
            temp[1] = Convert.ToByte('\n');
            //parent.EcritureSerie(temp);
            Envoi_data(Convert.ToByte(temp));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        const byte STX = 0x02;  // caractère de contrôle Start of TeXt = (02H)
        const byte ETX = 0x03;  // caractère de contrôle End of TeXt = (03H)
        const byte DLE = 0x10;  // caractère de contrôle Data Link Escape = (10H)
        const byte NAK = 0x15;  // caractère de contrôle Negative AcKnoledgement = (15H)

        const int nombre_max_d_erreurs = 6;   // nombre maximal d'erreurs permises
        const int nombre_de_type_d_erreurs = 4;    // pour définir la taille du tableau recensant les erreurs

        const int transmission_reussie = 0; // transmission réussie
        const int transmission_echouee = 1;  // transmission échouée

        bool FLAG_TIMER1;   // définit un flag pour le TIMEOUT

        int[] Cpt = new int[nombre_de_type_d_erreurs]; // crée le tableau d'erreurs

        public SerialPort serialPort;   // utilise le SerialPort

        public static System.Timers.Timer timer1;  //TIMEOUT

        public int Envoi_data(byte data)   // fonction d'envoi de donnée(s)
        {
            Vue_donnees_transit.Clear();    // efface l'affichage sous le bouton, servant juste à informer l'utilisateur sur les données envoyées et reçues
   
            byte bcc;   // défini le BCC : Block Check Character (= ou exclusif)

            for (int l = 0; l < nombre_de_type_d_erreurs; l++) // tous les caractères du tableau d'erreurs sont mis à 0
                Cpt[l] = 0;
            
            bcc = calcul_du_bcc (data); // calcul du BCC, appel de la fonction

            byte[] cc = new byte[3];   // on mettra les bytes reçus dans le tableau de bytes cc
            
            FLAG_TIMER1 = true; // initialisation du flag du timer1 à true

            parent.EcritureSerie("STX");    // envoi de STX
            Vue_donnees_transit.Text = "Tx : STX ; ";   // affichage des données envoyées sous le bouton (info pour l'utilisateur)
            parent.BO_communication.Console.ajoutString("\n> Tx : STX \n");   // affichage des données envoyées dans la console (info pour l'utilisateur)

            timer1.Start(); // démarre le TIMEOUT
            serialPort.Read(cc, 0, serialPort.BytesToRead); // lit les bytes reçus et met dans cc
            serialPort.DiscardInBuffer();   // vide le tampon
            timer1.Stop();  // arrête le TIMEOUT

            if (FLAG_TIMER1 == true)   // si on n'est pas arrivé à l'échéance du délai TIMEOUT :
            {
                if (cc[0] == DLE)   // si le premier caractère reçu est DLE
                {
                    Vue_donnees_transit.Text += "Rx : DLE ; ";   // affichage des données reçues sous le bouton (info pour l'utilisateur)
                    parent.BO_communication.Console.ajoutString("\n> Rx : DLE \n");   // affichage des données reçues dans la console (info pour l'utilisateur)

                    parent.EcritureSerie(Convert.ToString(data));   // envoi des données utiles
                    Vue_donnees_transit.Text += "Tx : ";   // affichage des données envoyées sous le bouton (info pour l'utilisateur)
                    Vue_donnees_transit.Text += data;
                    Vue_donnees_transit.Text += " ; ";
                    parent.BO_communication.Console.ajoutString("\n> Tx : " + data + " \n");

                    if (data == DLE) //si double DLE
                    {
                        parent.EcritureSerie("DLE");    // on envoi DLE une deuxième fois
                        Vue_donnees_transit.Text = "Tx : DLE ; ";
                        parent.BO_communication.Console.ajoutString("\n> Tx : DLE \n");
                    }

                    parent.EcritureSerie("DLE");    // envoi de DLE pour terminer
                    Vue_donnees_transit.Text = "Tx : DLE ; ";
                    parent.BO_communication.Console.ajoutString("\n> Tx : DLE \n");

                    parent.EcritureSerie("ETX");    // envoi de ETX pour terminer
                    Vue_donnees_transit.Text = "Tx : ETX ; ";
                    parent.BO_communication.Console.ajoutString("\n> Tx : ETX \n");

                    parent.EcritureSerie(Convert.ToString(bcc));    // envoi de BCC pour terminer
                    Vue_donnees_transit.Text += "Tx : ";
                    Vue_donnees_transit.Text += bcc;
                    Vue_donnees_transit.Text += " ; ";
                    parent.BO_communication.Console.ajoutString("\n> Tx : " + bcc + " \n");

                    timer1.Start();
                    serialPort.Read(cc, 0, serialPort.BytesToRead);
                    serialPort.DiscardInBuffer();
                    timer1.Stop();

                    if (FLAG_TIMER1 == true)
                    {
                        if (cc[0] != DLE)
                        {
                            Cpt[1]++;
                            Vue_donnees_transit.Text += " Erreur 1 ; ";
                            parent.BO_communication.Console.ajoutString("\n> Erreur 1 \n");
                        }
                    }
                    else
                    {
                        Cpt[2]++;
                        Vue_donnees_transit.Text += " Erreur 2 ; ";
                        parent.BO_communication.Console.ajoutString("\n> Erreur 2 \n");
                    }
                }
                else
                {
                    Cpt[3]++;
                    Vue_donnees_transit.Text += " Erreur 3 ; ";
                    parent.BO_communication.Console.ajoutString("\n> Erreur 3 \n");
                }
            }
            else
            {
               Cpt[4]++;
               Vue_donnees_transit.Text += " Erreur 4 ; ";
               parent.BO_communication.Console.ajoutString("\n> Erreur 4 \n");
            }

            if (somme_d_erreurs() == nombre_max_d_erreurs) //si somme des erreurs> seuil max
                return transmission_echouee; //retourne une erreur de transmission

            return transmission_reussie;    // retourne une réussite de transmission
        }

        public byte calcul_du_bcc (byte data)    // fonction calcul du BCC
        {
            byte bcc = 0;
            bcc ^= data;
            if (data == DLE) //on compte un double DLE
                bcc ^= DLE;
            return bcc;
        }

        public int somme_d_erreurs ()    //  fonction réaliant la somme des erreurs, on augmente "somme" à chaque appel de la fonction
        {
            int somme, k;
            for (k = 0, somme = 0; k < nombre_de_type_d_erreurs; k++)
                somme += Cpt[k];
            return somme;
        }

        

        public void TIMER1()    // fonction TIMEOUT, 25ms
        {
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer1.Interval = 25;
            timer1.Enabled = true;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e) // si événement (fin) sur TIMEOUT : on change le flag
        {
            FLAG_TIMER1 = false;
        }

        static int valeur_demandee = 1; // indice statique permettant d'interroger chaque capeteur à tour de rôle lors d'un clic sur le bouton

        private void Debut_acq_Click_1(object sender, EventArgs e)  // événement = clic sur le bouton
        {
            //Timer_acquisition.Start();

            switch (valeur_demandee)    // en fonction de la valeur de valeur_demandée, on interrogera l'un ou l'autre capteur
            {
                case 1:     // Cas : Profondeur
                    parent.BO_communication.Console.ajoutString("\n> Demande profondeur - envoi : A \n");   // affichage sur console (informtation pour utilisateur)
                    Envoi_data(Convert.ToByte('A'));    // envoi de "A" sur le port série
                    Thread.Sleep(2000); // "pause" de 2 secondes
                    break;

                case 2:     // Cas : Axe X
                    parent.BO_communication.Console.ajoutString("\n> Demande axe X - envoi : C \n");
                    Envoi_data(Convert.ToByte('C'));
                    Thread.Sleep(2000);
                    break;

                case 3:     // Cas : Axe Y
                    parent.BO_communication.Console.ajoutString("\n> Demande axe Y - envoi : E \n");
                    Envoi_data(Convert.ToByte('E'));
                    Thread.Sleep(2000);
                    break;

                case 4:     // Cas : Ballast 0
                    parent.BO_communication.Console.ajoutString("\n> Demande position ballast 0 - envoi : G \n");
                    Envoi_data(Convert.ToByte('G'));
                    Thread.Sleep(2000);
                    break;

                case 5:     // Cas : Ballast 1
                    parent.BO_communication.Console.ajoutString("\n> Demande position ballast 1 - envoi : I \n");
                    Envoi_data(Convert.ToByte('I'));
                    Thread.Sleep(2000);
                    valeur_demandee = 0;
                    break;

                default:
                    break;
            }
            valeur_demandee++;  // on incrémente la valeur statique afin d'interroge chaque capteur à tour de rôle à chaque clic
        }

        private void FormTelecommande_Load(object sender, EventArgs e) 
        {

        }

        private void Vue_donnees_transit_TextChanged(object sender, EventArgs e)    // zone de texte sous le bouton
        {

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

    }
}
