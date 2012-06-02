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

using System.IO;                            // IO du pc --> Ports
using System.IO.Ports;  

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

            parent.EcritureSerie("K\n");
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastAvant.Value >> 8);
            temp[1] = Convert.ToByte('\n');
            parent.EcritureSerie(temp);
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastAvant.Value & 0xFF);
            temp[1] = Convert.ToByte('\n');
            parent.EcritureSerie(temp);
        }

        private void EnvoiBallastArriere()
        {
            parent.BO_communication.Console.ajoutString("\n> envoi : M + " + (CurseurBallastArriere.Value >> 8).ToString() + " + " + (CurseurBallastArriere.Value & 0xFF).ToString() + "\n");
            byte[] temp = new byte[2];

            parent.EcritureSerie("M\n");
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastArriere.Value >> 8);
            temp[1] = Convert.ToByte('\n');
            parent.EcritureSerie(temp);
            System.Threading.Thread.Sleep(1000);

            temp[0] = Convert.ToByte(CurseurBallastArriere.Value & 0xFF);
            temp[1] = Convert.ToByte('\n');
            parent.EcritureSerie(temp);
        }

        static  int i = 1 ;

        public SerialPort serialPort;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Debut_acq_Click_1(object sender, EventArgs e)  // Fonction "action" lorsqu'on clique sur le bouton de demande d'acquisition
        {
            int j = 0;  // Sécurité : si on n'a pas reçu de valeur après 3 essais, on attend un clic pour interroger le capteur suivant - remis à zéro à chaque clic!

            parent.flag_A = false;  // On initialise les flag de retour d'information, à false à chaque clic sur le bouton. Cette valeur sera modifiée dans portCOM.cs en cas de bonne réception
            parent.flag_C = false;
            parent.flag_E = false;
            parent.flag_G = false;
            parent.flag_I = false;

            //Timer_acquisition.Start(); 

            switch (i)  // Cas d'un capteur à la fois, valeur incrémentée à chaque clic sur le bouton, remise à zéro au dernier capteur
            {
                case 1:      // Cas : Profondeur
                    do
                    {
                        parent.BO_communication.Console.ajoutString("\n> Demande profondeur - envoi : A \n");   // On écrit dans la console (information visuelle pour utilisateur)
                        parent.EcritureSerie("A");  // On envoie "A" sur le port série
                        Thread.Sleep(2000); // On patiente 2 secondes
                        j++;    // Incrémente la variable de sécurité (utile en cas de non-réponse après les 2 secondes, càd si le flag reste à false...)
                    } while (parent.flag_A == false && j<3);    // On reste dans la boucle tant qu'on n'a pas réalisé les trois essais ET que le flag n'est pas passé à true (donc pas de réception)

                    break;

                case 2:      // Cas : Axe X
                    do
                    {
                        parent.BO_communication.Console.ajoutString("\n> Demande axe X - envoi : C \n");
                        parent.EcritureSerie("C");
                        j++;
                        Thread.Sleep(2000);
                    } while (parent.flag_C == false && j < 3);
                    break;

                case 3:      // Cas : Axe Y
                    do
                    {
                        parent.BO_communication.Console.ajoutString("\n> Demande axe Y - envoi : E \n");
                        parent.EcritureSerie("E");
                        Thread.Sleep(2000);
                        j++;
                    } while (parent.flag_E == false && j < 3);

                    break;

                case 4:      // Cas : Ballast 0
                    do
                    {
                        parent.BO_communication.Console.ajoutString("\n> Demande position ballast avant - envoi : G \n");
                        parent.EcritureSerie("G");
                        Thread.Sleep(2000);
                        j++;
                    } while (parent.flag_G == false && j < 3);

                    break;

                case 5:      // Cas : Ballast 1
                    do
                    {
                        parent.BO_communication.Console.ajoutString("\n> Demande position ballast arrière - envoi : I \n");
                        parent.EcritureSerie("I");
                        Thread.Sleep(2000);
                        j++;
                    } while (parent.flag_I == false && j < 3);

                    i = 0;  // Remet l'indice pour la boucle à zéro
                    break;

                default:
                    break;
            }

            if (j==3)
                parent.BO_communication.Console.ajoutString("\n> 3 essais ratés... Attente clic suivant... \n");    // Cas de 3 essais sans réponse : on informe l'utilisateur par affichage sur console

            i++;    // On incrémente la valeur statique i afin d'interroger les capteurs à tour de rôle à chaque clic sur le bouton
        }

        private void FormTelecommande_Load(object sender, EventArgs e)  // Initialisation des flags à l'ouverture de la fenêtre (lancement du programme)
        {
            parent.flag_A = false;
            parent.flag_C = false;
            parent.flag_E = false;
            parent.flag_G = false;
            parent.flag_I = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
   
    }
}
