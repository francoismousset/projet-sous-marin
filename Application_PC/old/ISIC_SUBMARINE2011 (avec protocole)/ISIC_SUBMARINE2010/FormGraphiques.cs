using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ISIC_SUBMARINE2010
{
    public partial class FormGraphiques : Form
    {
        private BO_Graphes parent;
        
        private String CapteurGraphe1;
        private String CapteurGraphe2;

        private int TempsFenetre;
        private string CouleurCourbe1;
        private string CouleurCourbe2;
        private string CouleurFond1;
        private string CouleurFond2;

        public FormGraphiques(BO_Graphes parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public void RafraichirGraphes(String CapteurGraphe1, String CapteurGraphe2)
        {
            this.CapteurGraphe1 = CapteurGraphe1;
            this.CapteurGraphe2 = CapteurGraphe2;

            CreateChart(zedGraphe1, conversionTable(CapteurGraphe1), conversionTitre(CapteurGraphe1), conversionCouleur(CouleurCourbe1), conversionCouleur(CouleurFond1));
            CreateChart(zedGraphe2, conversionTable(CapteurGraphe2), conversionTitre(CapteurGraphe2), conversionCouleur(CouleurCourbe2), conversionCouleur(CouleurFond2));
        }

        private void CreateChart(ZedGraphControl zgc, string table, string titre, Color couleurCourbe, Color couleurFond)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = titre;
            myPane.XAxis.Title.Text = "TEMPS (s)";
            myPane.YAxis.Title.Text = null;


            // Build a PointPairList with points based on Sine wave
            PointPairList list = new PointPairList();

            int ID_max = parent.BaseDeDonnees.DernierID(table);

            double x;
            double y;

            if (ID_max == 0)
            {
                myPane.XAxis.Scale.Min = 0;
                myPane.XAxis.Scale.Max = (TempsFenetre * 60)-1;
            }
            else
            {
                if (ID_max > TempsFenetre * 60)
                {
                    for (int i = 0; i < ID_max; i++)
                    {
                        x = i;
                        y = parent.BaseDeDonnees.LireValeur(table, i + 1);

                        list.Add(x, y);
                    }
                    myPane.XAxis.Scale.Min = ID_max-(TempsFenetre * 60);
                    myPane.XAxis.Scale.Max = ID_max-1;
                }
                else
                {
                    for (int i = 0; i < TempsFenetre*60; i++)
                    {
                        if (i < ID_max)
                        {
                            x = i;
                            y = parent.BaseDeDonnees.LireValeur(table, i + 1);
                            list.Add(x, y);
                        }
                    }
                    myPane.XAxis.Scale.Min = 0;
                    myPane.XAxis.Scale.Max = (TempsFenetre * 60) - 1;
                }
            }

            // Hide the legend
            myPane.Legend.IsVisible = false;

            zgc.GraphPane.CurveList.Clear(); // effacer la vieille courbe

            // Add a curve
            LineItem curve = myPane.AddCurve("label", list, couleurCourbe, SymbolType.None);
            curve.Line.Width = 1.5F;
            //curve.Symbol.Fill = new Fill(Color.White);
            //curve.Symbol.Size = 5;

            // Make the XAxis start with the first label at 50
            myPane.XAxis.Scale.BaseTic = 50;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(couleurFond, couleurFond, 45.0F);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

            // Refresh to paint the graph components
            Refresh(); 
        }

        private string conversionTable(string capteur)
        {
            string table;

            switch (capteur)
            {
                case "Position du ballast avant": table = "PositionBallast1";
                    break;
                case "Position du ballast arrière": table = "PositionBallast2";
                    break;
                case "Vitesse du moteur 1": table = "VitessePropulsion1";
                    break;
                case "Vitesse du moteur 2": table = "VitessePropulsion2";
                    break;
                case "Profondeur": table = "Profondeur";
                    break;
                case "Inclinaison axe X": table = "InclinaisonAxeX";
                    break;
                case "Inclinaison axe Y": table = "InclinaisonAxeY";
                    break;
                default: table = null;
                    break;
            }

            return table;
        }

        private string conversionTitre(string capteur)
        {
            string titre;

            switch (capteur)
            {
                case "Position du ballast avant": titre = "POSITION DU BALLAST AVANT (mm)";
                    break;
                case "Position du ballast arrière": titre = "POSITION DU BALLAST ARRIERE (mm)";
                    break;
                case "Vitesse du moteur 1": titre = "VITESSE DU MOTEUR 1 (tr/min)";
                    break;
                case "Vitesse du moteur 2": titre = "VITESSE DU MOTEUR 2 (tr/min)";
                    break;
                case "Profondeur": titre = "PROFONDEUR (mm)";
                    break;
                case "Inclinaison axe X": titre = "INCLINAISON AXE X (°)";
                    break;
                case "Inclinaison axe Y": titre = "INCLINAISON AXE Y (°)";
                    break;
                default: titre = null;
                    break;
            }

            return titre;
        }

        private Color conversionCouleur(string couleurIN)
        {
            Color couleurOUT;

            switch (couleurIN)
            {
                case "Rouge": couleurOUT = Color.Red;
                    break;
                case "Bleu": couleurOUT = Color.Blue;
                    break;
                case "Vert": couleurOUT = Color.Lime;
                    break;
                case "Blanc": couleurOUT = Color.White;
                    break;
                case "Noir": couleurOUT = Color.Black;
                    break;
                default: couleurOUT = Color.White;
                    break;
            }

            return couleurOUT;
        }

        // SET

        public void setTempsFenetre(int valeur)
        {
            TempsFenetre = valeur;
        }

        public void setCouleurCourbe1(string valeur)
        {
            CouleurCourbe1 = valeur;
        }

        public void setCouleurCourbe2(string valeur)
        {
            CouleurCourbe2 = valeur;
        }

        public void setCouleurFond1(string valeur)
        {
            CouleurFond1 = valeur;
        }

        public void setCouleurFond2(string valeur)
        {
            CouleurFond2 = valeur;
        }

        // GET

        public int getTempsFenetre()
        {
            return TempsFenetre;
        }

        public string getCouleurCourbe1()
        {
            return CouleurCourbe1;
        }

        public string getCouleurCourbe2()
        {
            return CouleurCourbe2;
        }

        public string getCouleurFond1()
        {
            return CouleurFond1;
        }

        public string getCouleurFond2()
        {
            return CouleurFond2;
        }

        // resizing automatique des deux graphes en fonction de la taille de la fenêtre

        private void FormGraphiques_SizeChanged(object sender, EventArgs e)
        {
            zedGraphe1.Width = this.Width - 36;
            zedGraphe1.Height = ((this.Height - 68)/2);

            zedGraphe2.Top = ((this.Height - 68) / 2) + 20;
            zedGraphe2.Width = this.Width - 36;
            zedGraphe2.Height = ((this.Height - 68) / 2);
        }
    }
}
