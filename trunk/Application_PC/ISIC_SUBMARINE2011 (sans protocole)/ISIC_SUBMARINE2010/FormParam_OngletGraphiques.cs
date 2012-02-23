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
    public partial class FormParam_OngletGraphiques : Form
    {
        public FormParam_OngletGraphiques()
        {
            InitializeComponent();
        }

        // SET

        public void setText_TauxRafraichissement(int valeur)
        {
            CurseurTauxRafraichissement.Value = valeur;
        }

        public void setText_TailleFenetre(int valeur)
        {
            CurseurTailleFenetre.Value = valeur;
        }

        public void setText_CapteurGraphe1(string valeur)
        {
            CapteurGraphe1.SelectedItem = valeur;
        }

        public void setText_CouleurCourbe1(string valeur)
        {
            CouleurCourbe1.SelectedItem = valeur;
        }

        public void setText_CouleurFond1(string valeur)
        {
            CouleurFond1.SelectedItem = valeur;
        }

        public void setText_CapteurGraphe2(string valeur)
        {
            CapteurGraphe2.SelectedItem = valeur;
        }

        public void setText_CouleurCourbe2(string valeur)
        {
            CouleurCourbe2.SelectedItem = valeur;
        }

        public void setText_CouleurFond2(string valeur)
        {
            CouleurFond2.SelectedItem = valeur;
        }

        // GET

        public int getTauxRafraichissement()
        {
            return CurseurTauxRafraichissement.Value;
        }

        public int getTailleFenetre()
        {
            return CurseurTailleFenetre.Value;
        }

        public string getCapteurGraphe1()
        {
            return CapteurGraphe1.SelectedItem.ToString();
        }

        public string getCouleurCourbe1()
        {
            return CouleurCourbe1.SelectedItem.ToString();
        }

        public string getCouleurFond1()
        {
            return CouleurFond1.SelectedItem.ToString();
        }

        public string getCapteurGraphe2()
        {
            return CapteurGraphe2.SelectedItem.ToString();
        }

        public string getCouleurCourbe2()
        {
            return CouleurCourbe2.SelectedItem.ToString();
        }

        public string getCouleurFond2()
        {
            return CouleurFond2.SelectedItem.ToString();
        }

        // mise à jour des valeurs à coté des curseurs

        private void CurseurTauxRafraichissement_ValueChanged(object sender, EventArgs e)
        {
            ValeurTauxRafraichissement.Text = CurseurTauxRafraichissement.Value.ToString() + " s";
        }

        private void CurseurTailleFenetre_ValueChanged(object sender, EventArgs e)
        {
            ValeurTailleFenetre.Text = CurseurTailleFenetre.Value.ToString() + " min";
        }
    }
}
