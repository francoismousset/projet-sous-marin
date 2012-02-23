using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISIC_SUBMARINE2010
{
    public class BO_Graphes
    {
        private SousMarin parent;
        public FormGraphiques Graphiques;

        private String CapteurGraphe1;
        private String CapteurGraphe2;

        public BD BaseDeDonnees;

        private Timer TimerRafraichissementGraphes;
        

        public BO_Graphes(SousMarin parent)
        {
            this.parent = parent;

            Graphiques = new FormGraphiques(this);

            BaseDeDonnees = new BD();
            BaseDeDonnees.connexion();
            
            TimerRafraichissementGraphes = new Timer();
            TimerRafraichissementGraphes.Tick += new EventHandler(TimerRafraichissementGraphes_Tick);
            
            // procedure de test
            //BaseDeDonnees.SupprimerContenuTable("PositionBallast1");
            //BaseDeDonnees.IDnulTable("PositionBallast1");
            //BaseDeDonnees.AjoutValeur("PositionBallast1", 13);
            //MessageBox.Show("ID :" + BaseDeDonnees.DernierID("PositionBallast2"));
            //MessageBox.Show("ID :" + BaseDeDonnees.DernierID("PositionBallast1"));
            //MessageBox.Show("Valeur0 :" + BaseDeDonnees.LireValeur("PositionBallast1", 0));
            //MessageBox.Show("Valeur1 :" + BaseDeDonnees.LireValeur("PositionBallast1", 1));
            //MessageBox.Show("Valeurlast :" + BaseDeDonnees.LireValeur("PositionBallast1", BaseDeDonnees.DernierID("PositionBallast1")));

        }

        // SET

        public void setPeriodeRafraichissement(int valeur)
        {
            TimerRafraichissementGraphes.Interval = valeur*1000;
        }

        public void setCapteurGraphe1(String valeur)
        {
            CapteurGraphe1 = valeur;
        }

        public void setCapteurGraphe2(String valeur)
        {
            CapteurGraphe2 = valeur;
        }

        // GET

        public int getPeriodeRafraichissement()
        {
            return (TimerRafraichissementGraphes.Interval % 1000);
        }

        public String getCapteurGraphe1()
        {
            return CapteurGraphe1;
        }

        public String getCapteurGraphe2()
        {
            return CapteurGraphe2;
        }

        // événements TIMER

        public void StartRafraichissementGraphes()
        {
            TimerRafraichissementGraphes.Start();
        }

        public void StopRafraichissementGraphes()
        {
            TimerRafraichissementGraphes.Stop();
        }

        private void TimerRafraichissementGraphes_Tick(object sender, EventArgs e)
        {
            RafraichissementGraphes();
        }

        // fonction de rafraichissement

        public void RafraichissementGraphes()
        {
            parent.BO_graphiques.Graphiques.RafraichirGraphes(CapteurGraphe1, CapteurGraphe2);
        }

        // fonction pour supprimer tout le contenu de la BD

        public void SuppressionContenuBD()
        {

            /*BaseDeDonnees.SupprimerContenuTable("CourantBatterie1");
            BaseDeDonnees.SupprimerContenuTable("CourantBatterie2");
            BaseDeDonnees.SupprimerContenuTable("Humidite");
            BaseDeDonnees.SupprimerContenuTable("InclinaisonAxeX");
            BaseDeDonnees.SupprimerContenuTable("InclinaisonAxeY");
            BaseDeDonnees.SupprimerContenuTable("Ordres");*/
            BaseDeDonnees.SupprimerContenuTable("PositionBallast1");
            BaseDeDonnees.IDnulTable("PositionBallast1");
            /*BaseDeDonnees.SupprimerContenuTable("PositionBallast2");
            BaseDeDonnees.SupprimerContenuTable("Profondeur");
            BaseDeDonnees.SupprimerContenuTable("Temperature");
            BaseDeDonnees.SupprimerContenuTable("TensionBatterie1");
            BaseDeDonnees.SupprimerContenuTable("TensionBatterie2");
            BaseDeDonnees.SupprimerContenuTable("VitessePropulsion1");
            BaseDeDonnees.SupprimerContenuTable("VitessePropulsion2");*/
        }

    }
}
