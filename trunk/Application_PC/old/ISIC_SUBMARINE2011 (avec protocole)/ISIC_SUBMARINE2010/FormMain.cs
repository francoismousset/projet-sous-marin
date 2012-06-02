using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ISIC_SUBMARINE2010
{
    public partial class FormMain : Form
    {
        private String NomFichierXML;

        public SousMarin SM;

        public FormMain()
        {
            InitializeComponent();
            SM = null;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void CreerSM()
        {
            Main_BarreStatut_Texte1.Text = NomFichierXML;
            Main_BarreMenu_SousMarin_Nouveau.Enabled = false;
            Main_BarreMenu_SousMarin_Fermer.Enabled = true;
            Main_BarreMenu_SousMarin_Supprimer.Enabled = true;
            Main_BarreMenu_Options.Enabled = true;

            if (SM == null)
            {
                SM = new SousMarin(this, NomFichierXML);
            }
            else
            {
                SM.initialisation(this, NomFichierXML);
            }
        }

        private void FermerSM()
        {
            SM.Telecommande.Close();
            SM.StopRafraichissementBD();
            SM.BO_graphiques.StopRafraichissementGraphes();
            SM.BO_graphiques.Graphiques.Close();
            SM.BO_communication.Console.Close();
            SM.BO_communication.serialPort.Close();
            SM.BO_graphiques.BaseDeDonnees.deconnexion();
            SM.saveParamFenetres();
            Main_BarreStatut_Texte1.Text = "Cliquez sur \"Sous-Marin/Nouveau\" pour commencer";
            Main_BarreMenu_SousMarin_Nouveau.Enabled = true;
            Main_BarreMenu_SousMarin_Fermer.Enabled = false;
            Main_BarreMenu_SousMarin_Supprimer.Enabled = false;
            Main_BarreMenu_Options.Enabled = false;
        }

        private void Main_BarreMenu_SousMarin_Nouveau_Click(object sender, EventArgs e)
        {
            if (Main_Dialogue_Nouveau.ShowDialog() == DialogResult.OK)
            {
                NomFichierXML = Main_Dialogue_Nouveau.FileName;
                FileInfo FichierXML = new FileInfo(NomFichierXML);

                if (File.Exists(NomFichierXML))
                {
                    if (FichierXML.Extension == ".xml")
                    {
                        CreerSM();
                    }
                    else
                    {
                        MessageBox.Show("Le fichier sélectionné n'est pas de type XML !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (MessageBox.Show("Le fichier n'existe pas. Voulez-vous créer un nouveau fichier ?", "Nouveau fichier", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // créer nouveau fichier xml en copiant un template situé dans le dossier de l'application
                        File.Copy(Application.StartupPath + "\\Template.xml", NomFichierXML);

                        CreerSM();
                    }
                }
            }
        }

        private void Main_BarreMenu_SousMarin_Fermer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûrs de vouloir fermer le Sous-Marin ?", "Fermer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FermerSM();
            }
        }

        private void Main_BarreMenu_SousMarin_Supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûrs de vouloir supprimer ce Sous-Marin ?\n\nCette opération est irréversible !", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FermerSM();
                System.IO.File.Delete(@NomFichierXML); 
            }
        }

        private void Main_BarreMenu_SousMarin_Quitter_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void Main_BarreMenu_Options_Config_Click(object sender, EventArgs e)
        {
            BO_Param BOParam = new BO_Param(this, NomFichierXML);
        }

        private void Main_BarreMenu_Options_LancerProgrammeFB_Click(object sender, EventArgs e)
        {
            SM.LancerProgrammeFB();
        }

        private void arrêterLeProgrammeFoxBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM.ArreterProgrammeFB();
        } 

        private void Main_BarreMenu_Aide_Afficher_Click(object sender, EventArgs e)
        {
            FormAide Aide = new FormAide();
            Aide.Show();
        }

        private void Main_BarreMenu_Aide_Apropos_Click(object sender, EventArgs e)
        {
            FormApropos Apropos = new FormApropos();
            Apropos.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûrs de vouloir quitter le programme ?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (SM != null)
                {
                    SM.saveParamFenetres();
                }
            }
        }
    }
}
