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
    public partial class FormParam_OngletGeneral : Form
    {
        public FormParam_OngletGeneral()
        {
            InitializeComponent();
        }

        // SET

        public void setText_nomSM(string value)
        {
            nomSM.Text = value;
        }

        public void setText_poidsSM(string value)
        {
            poidsSM.Text = value;
        }

        public void setText_longueurSM(string value)
        {
            longueurSM.Text = value;
        }

        public void setText_largeurSM(string value)
        {
            largeurSM.Text = value;
        }

        public void setText_hauteurSM(string value)
        {
            hauteurSM.Text = value;
        }

        // GET

        public string getnomSM()
        {
            return nomSM.Text;
        }

        public string getpoidsSM()
        {
            return poidsSM.Text;
        }

        public string getlongueurSM()
        {
            return longueurSM.Text;
        }

        public string getlargeurSM()
        {
            return largeurSM.Text;
        }

        public string gethauteurSM()
        {
            return hauteurSM.Text;
        }
    }
}
