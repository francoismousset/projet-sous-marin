using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ISIC_SUBMARINE2010
{
    public partial class FormParam : Form
    {
        public FormParam_OngletGeneral General;
        public FormParam_OngletRS232 RS232;
        public FormParam_OngletGraphiques Graphiques;
        public FormParam_OngletBD BaseDeDonnees;
        private BO_Param parent;
        public FormMain main;

        public FormParam(String NomFichierXML, BO_Param parent, FormMain main)
        {
            InitializeComponent();

            // intégration de la form FormParam_OngletGeneral dans le 1er tab
            General = new FormParam_OngletGeneral();
            General.TopLevel = false;
            General.FormBorderStyle = FormBorderStyle.None;
            OngletsParam.TabPages[0].Controls.Add(General);
            General.Size = OngletsParam.TabPages[0].ClientSize;
            General.Show();

            // intégration de la form FormParam_OngletRS232 dans le 2e tab
            RS232 = new FormParam_OngletRS232();
            RS232.TopLevel = false;
            RS232.FormBorderStyle = FormBorderStyle.None;
            OngletsParam.TabPages[1].Controls.Add(RS232);
            RS232.Size = OngletsParam.TabPages[1].ClientSize;
            RS232.Show();

            // intégration de la form FormParam_OngletGraphiques dans le 3e tab
            Graphiques = new FormParam_OngletGraphiques();
            Graphiques.TopLevel = false;
            Graphiques.FormBorderStyle = FormBorderStyle.None;
            OngletsParam.TabPages[2].Controls.Add(Graphiques);
            Graphiques.Size = OngletsParam.TabPages[2].ClientSize;
            Graphiques.Show();

            // intégration de la form FormParam_OngletBD dans le 4e tab
            BaseDeDonnees = new FormParam_OngletBD(this);
            BaseDeDonnees.TopLevel = false;
            BaseDeDonnees.FormBorderStyle = FormBorderStyle.None;
            OngletsParam.TabPages[3].Controls.Add(BaseDeDonnees);
            BaseDeDonnees.Size = OngletsParam.TabPages[3].ClientSize;
            BaseDeDonnees.Show();

            // set dans l'onglet du get dans la BO
            this.parent = parent;
            this.main = main;

            General.setText_nomSM(parent.getNom());
            General.setText_poidsSM(parent.getPoids());
            General.setText_longueurSM(parent.getLongueur());
            General.setText_largeurSM(parent.getLargeur());
            General.setText_hauteurSM(parent.getHauteur());

            RS232.setText_baudrate(parent.getBaudrate());
            RS232.setText_nbBits(parent.getNombreDeBits());
            RS232.setText_nbBitsStop(parent.getNombreDeBitsDeStop());
            RS232.setText_parity(parent.getParite());
            RS232.setText_timeOutSortie(parent.getTimeOutSortie());
            RS232.setText_timeOutEntree(parent.getTimeOutEntree());
            RS232.setText_bufferEntree(parent.getTailleBufferEntree());
            RS232.setText_bufferSortie(parent.getTailleBufferSortie());

            Graphiques.setText_TauxRafraichissement(Convert.ToInt16(parent.getTauxRafraichissement()));
            Graphiques.setText_TailleFenetre(Convert.ToInt16(parent.getTailleFenetre()));
            Graphiques.setText_CapteurGraphe1(parent.getCapteurGraphe1());
            Graphiques.setText_CouleurCourbe1(parent.getCouleurCourbe1());
            Graphiques.setText_CouleurFond1(parent.getCouleurFond1());
            Graphiques.setText_CapteurGraphe2(parent.getCapteurGraphe2());
            Graphiques.setText_CouleurCourbe2(parent.getCouleurCourbe2());
            Graphiques.setText_CouleurFond2(parent.getCouleurFond2());

            BaseDeDonnees.setCheckboxAcquisition(parent.getActivationAcquisition());
        }

        // actions des trois boutons
        private void BoutonParam_Ok_Click(object sender, EventArgs e)
        {
            parent.saveData();
            main.SM.RafraichissementParamGeneraux();
            main.SM.RafraichissementGraphiques();
            main.SM.RafraichissementRS232();
            this.DestroyHandle();
        }

        private void BoutonParam_Annuler_Click(object sender, EventArgs e)
        {
            this.DestroyHandle();
        }

        private void BoutonParam_Appliquer_Click(object sender, EventArgs e)
        {
            parent.saveData();
            main.SM.RafraichissementParamGeneraux();
            main.SM.RafraichissementGraphiques();
            main.SM.RafraichissementRS232();
        }

        private void FormParam_Load(object sender, EventArgs e)
        {

        }
    }
}
