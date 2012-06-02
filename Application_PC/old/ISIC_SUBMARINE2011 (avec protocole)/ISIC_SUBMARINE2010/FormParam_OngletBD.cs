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
    public partial class FormParam_OngletBD : Form
    {
        private FormParam parent;

        public FormParam_OngletBD(FormParam parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public string getCheckboxAcquisition()
        {
            if (checkBoxAcquisition.Checked == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public void setCheckboxAcquisition(string value)
        {
            switch (value)
            {
                case "true": checkBoxAcquisition.Checked = true;
                    break;
                case "false": checkBoxAcquisition.Checked = false;
                    break;
                default:
                    break;
            }
        }

        private void BoutonParam_EffacerBD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûr de vouloir supprimer le contenu de la base de données ?", "Suppression du contenu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //parent.main.SM.BO_graphiques.SuppressionContenuBD();
                MessageBox.Show("Données supprimées !");
            }
        }

        private void BoutonParam_ExporterBD_Click(object sender, EventArgs e)
        {

        }
    }
}
