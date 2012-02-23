using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISIC_SUBMARINE2010
{
    public partial class FormConsole : Form
    {
        SousMarin parent;
        int oldSize = 0;
        Boolean blockInt;

        public FormConsole(SousMarin parent)
        {
            InitializeComponent();

            this.parent = parent;
            blockInt = false;

            oldSize = textConsole.Lines.Length;
            envoiConsole.KeyDown += new KeyEventHandler(envoiConsole_KeyDown);
            textConsole.TextChanged += new EventHandler(textConsole_TextChanged);
        }

        public void ajoutString(String ajout)
        {
            if(ajout!=string.Empty)
                textConsole.AppendText(ajout);
        }

        private void Console_BoutonEnvoyer_Click(object sender, EventArgs e)
        {
            ajoutString(envoiConsole.Text.ToString() + "\n> ");

            if ((envoiConsole.Text == "K") || (envoiConsole.Text == "M"))
            {
                parent.EcritureSerie(envoiConsole.Text + "\n");
                blockInt = true;
            }
            else if (blockInt)
            {
                byte[] temp = new byte[2];

                temp[0] = Convert.ToByte(Convert.ToUInt16(envoiConsole.Text) >> 8);
                temp[1] = Convert.ToByte('\n');
                parent.EcritureSerie(temp);
                System.Threading.Thread.Sleep(1000);

                temp[0] = Convert.ToByte(Convert.ToUInt16(envoiConsole.Text) & 0xFF);
                temp[1] = Convert.ToByte('\n');
                parent.EcritureSerie(temp);

                blockInt = false;
            }
            else
                parent.EcritureSerie(envoiConsole.Text.ToString() + "\n");

            envoiConsole.Clear();
        }

        private void envoiConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ajoutString(envoiConsole.Text.ToString() + "\n> ");

                if ((envoiConsole.Text == "K") || (envoiConsole.Text == "M"))
                {
                    parent.EcritureSerie(envoiConsole.Text + "\n");
                    blockInt = true;
                }
                else if (blockInt)
                {
                    byte[] temp = new byte[2];

                    temp[0] = Convert.ToByte(Convert.ToUInt16(envoiConsole.Text) >> 8);
                    temp[1] = Convert.ToByte('\n');
                    parent.EcritureSerie(temp);
                    System.Threading.Thread.Sleep(1000);

                    temp[0] = Convert.ToByte(Convert.ToUInt16(envoiConsole.Text) & 0xFF);
                    temp[1] = Convert.ToByte('\n');
                    parent.EcritureSerie(temp);

                    blockInt = false;
                }
                else
                    parent.EcritureSerie(envoiConsole.Text.ToString() + "\n");

                envoiConsole.Clear();
            }
        }

        private void textConsole_TextChanged(object sender, EventArgs e)
        {
            if (textConsole.Lines.Length > oldSize)
            {
                textConsole.SelectionStart = textConsole.Text.Length;
                textConsole.ScrollToCaret();
                textConsole.Refresh();
            }
            oldSize = textConsole.Lines.Length;
        }

        public void ConnexionActive(Boolean Etat)
        {
            if (Etat == true)
            {
                LedConnexion.BackColor = Color.Lime;
                EtatConnexion.Text = "Connecté";
            }
            else
            {
                LedConnexion.BackColor = Color.Red;
                EtatConnexion.Text = "Hors connexion";
            }
        }

        // resizing automatique des éléments en fonction de la taille de la fenêtre

        private void FormConsole_SizeChanged(object sender, EventArgs e)
        {
            textConsole.Width = this.Width - 40;
            textConsole.Height = this.Height - 104;

            envoiConsole.Width = this.Width - 120;
            envoiConsole.Top = this.Height - 70;

            Console_BoutonEnvoyer.Left = this.Width - 100;
            Console_BoutonEnvoyer.Top = this.Height - 72;
        }
    }
}
