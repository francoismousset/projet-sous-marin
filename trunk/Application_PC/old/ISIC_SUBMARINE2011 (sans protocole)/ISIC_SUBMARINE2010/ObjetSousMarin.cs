using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using isic_submarine_com;

namespace ISIC_SUBMARINE2010
{
    public class SousMarin
    {
        private String NomFichierXML;
        
        private FormMain parent;

        private MoteursBallasts ConsignesBallasts;
        private CapteursBallasts PositionsBallasts;
        private MoteursPropulsion ConsignePropulsion;
        private CapteursPropulsion VitessesPropulsion;
        private CapteurProfondeur Profondeur;
        private CapteurInclinaison Inclinaison;

        public bool flag_A;
        public bool flag_C;
        public bool flag_E;
        public bool flag_G;
        public bool flag_I;

        private xml_reader filedata;
        public DataSet file;
        
        public FormTelecommande Telecommande;
        private Timer TimerTelecommande;

        private Timer TimerRafraichissementBD;

        public BO_serie BO_communication;
        private Timer compteurARebours;

        public BO_Graphes BO_graphiques;

        public SousMarin(FormMain parent, String NomFichierXML)
        {
            initialisation(parent, NomFichierXML);
        }

        public void initialisation(FormMain parent, String NomFichierXML)
        {
            this.parent = parent;
            this.NomFichierXML = NomFichierXML;

            // lecture du fichier XML
            filedata = new xml_reader(NomFichierXML);
            file = filedata.getFileSet();

            // creation de la BO graphes/BD
            BO_graphiques = new BO_Graphes(this);

            // creation de la BO de communication serie

            string[] tabSerie = new String[8];

            chargementRS232(tabSerie);

            BO_communication = new BO_serie(this, Convert.ToInt32(tabSerie[0]),
                                                    Convert.ToInt32(tabSerie[1]),
                                                    tabSerie[2],
                                                    tabSerie[3],
                                                    Convert.ToInt32(tabSerie[4]),
                                                    Convert.ToInt32(tabSerie[5]),
                                                    Convert.ToInt32(tabSerie[6]),
                                                    Convert.ToInt32(tabSerie[7])
                                                    );
                                                    //flag_A);

            // création des class
            ConsignesBallasts = new MoteursBallasts();
            PositionsBallasts = new CapteursBallasts();
            ConsignePropulsion = new MoteursPropulsion();
            VitessesPropulsion = new CapteursPropulsion();
            Profondeur = new CapteurProfondeur();
            Inclinaison = new CapteurInclinaison();

            // création de la fenêtre télécommande
            Telecommande = new FormTelecommande(this);

            // initialisation positions et tailles des fenêtres
            initialisationFenetres();

            // rafraichissement automatique de la BD
            TimerRafraichissementBD = new Timer();
            TimerRafraichissementBD.Interval = 1000;
            TimerRafraichissementBD.Tick += new EventHandler(TimerRafraichissementBD_Tick);

            // mise à jour des valeurs
            RafraichissementParamGeneraux();
            RafraichissementTelecommande();
            RafraichissementGraphiques();
            BO_graphiques.RafraichissementGraphes();
            BO_graphiques.StartRafraichissementGraphes();

            // affichage des fenêtres
            Telecommande.MdiParent = parent;
            Telecommande.Show();
            BO_graphiques.Graphiques.MdiParent = parent;
            BO_graphiques.Graphiques.Show();
            BO_communication.Console.MdiParent = parent;
            BO_communication.Console.Show();

            // rafraichissement automatique de la télécommande
            TimerTelecommande = new Timer();
            TimerTelecommande.Interval = 1000;
            TimerTelecommande.Start();
            TimerTelecommande.Tick += new EventHandler(TimerTelecommande_Tick);

            // rafraichissement automatique de la console
            compteurARebours = new Timer();
            compteurARebours.Interval = 1;
            compteurARebours.Start();
            compteurARebours.Tick += new EventHandler(compteurARebours_Tick);
        }

        public void initialisationFenetres()
        {
            Telecommande.Left = Convert.ToInt16(file.Tables["FORM_REMOTE"].Rows[0].ItemArray[0].ToString());
            Telecommande.Top = Convert.ToInt16(file.Tables["FORM_REMOTE"].Rows[0].ItemArray[1].ToString());
            Telecommande.Width = Convert.ToInt16(file.Tables["FORM_REMOTE"].Rows[0].ItemArray[2].ToString());
            Telecommande.Height = Convert.ToInt16(file.Tables["FORM_REMOTE"].Rows[0].ItemArray[3].ToString());

            BO_graphiques.Graphiques.Left = Convert.ToInt16(file.Tables["FORM_GRAPH"].Rows[0].ItemArray[0].ToString());
            BO_graphiques.Graphiques.Top = Convert.ToInt16(file.Tables["FORM_GRAPH"].Rows[0].ItemArray[1].ToString());
            BO_graphiques.Graphiques.Width = Convert.ToInt16(file.Tables["FORM_GRAPH"].Rows[0].ItemArray[2].ToString());
            BO_graphiques.Graphiques.Height = Convert.ToInt16(file.Tables["FORM_GRAPH"].Rows[0].ItemArray[3].ToString());

            BO_communication.Console.Left = Convert.ToInt16(file.Tables["FORM_CONSOLE"].Rows[0].ItemArray[0].ToString());
            BO_communication.Console.Top = Convert.ToInt16(file.Tables["FORM_CONSOLE"].Rows[0].ItemArray[1].ToString());
            BO_communication.Console.Width = Convert.ToInt16(file.Tables["FORM_CONSOLE"].Rows[0].ItemArray[2].ToString());
            BO_communication.Console.Height = Convert.ToInt16(file.Tables["FORM_CONSOLE"].Rows[0].ItemArray[3].ToString());
        }

        private void chargementRS232(String[] parametres)
        {
            for (int i = 0; i < 8; i++)
            {
                parametres[i] = file.Tables["RS232"].Rows[0][i].ToString();
            }
        }

        public void RafraichissementRS232()
        {
            BO_communication.setBaudrate(Convert.ToInt16(file.Tables["RS232"].Rows[0].ItemArray[0].ToString()));
            BO_communication.setNombreBits(Convert.ToInt16(file.Tables["RS232"].Rows[0].ItemArray[1].ToString()));
            BO_communication.setParity(file.Tables["RS232"].Rows[0].ItemArray[2].ToString());
            BO_communication.setStopBits(file.Tables["RS232"].Rows[0].ItemArray[3].ToString());
            BO_communication.setReadBufferSize(Convert.ToInt16(file.Tables["RS232"].Rows[0].ItemArray[4].ToString()));
            BO_communication.setWriteBufferSize(Convert.ToInt16(file.Tables["RS232"].Rows[0].ItemArray[5].ToString()));
            BO_communication.setReadTimeOut(Convert.ToInt16(file.Tables["RS232"].Rows[0].ItemArray[6].ToString()));
            BO_communication.setWriteTimeOut(Convert.ToInt16(file.Tables["RS232"].Rows[0].ItemArray[7].ToString()));
        }

        public void RafraichissementParamGeneraux()
        {
            Telecommande.label1.Text = "Nom : " + file.Tables["GENERAL"].Rows[0].ItemArray[0].ToString();
            Telecommande.label2.Text = "Poids : " + file.Tables["GENERAL"].Rows[0].ItemArray[1].ToString() + " kg";
            Telecommande.label3.Text = "Longueur : " + file.Tables["GENERAL"].Rows[0].ItemArray[2].ToString() + " mm";
            Telecommande.label4.Text = "Largeur : " + file.Tables["GENERAL"].Rows[0].ItemArray[3].ToString() + " mm";
            Telecommande.label5.Text = "Hauteur : " + file.Tables["GENERAL"].Rows[0].ItemArray[4].ToString() + " mm";
        }

        public void RafraichissementGraphiques()
        {
            BO_graphiques.setPeriodeRafraichissement(Convert.ToInt16(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[1]));
            BO_graphiques.setCapteurGraphe1(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[3].ToString());
            BO_graphiques.setCapteurGraphe2(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[6].ToString());

            BO_graphiques.Graphiques.setTempsFenetre(Convert.ToInt16(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[2]));
            BO_graphiques.Graphiques.setCouleurCourbe1(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[4].ToString());
            BO_graphiques.Graphiques.setCouleurFond1(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[5].ToString());
            BO_graphiques.Graphiques.setCouleurCourbe2(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[7].ToString());
            BO_graphiques.Graphiques.setCouleurFond2(file.Tables["GRAPHIQUES"].Rows[0].ItemArray[8].ToString());

            switch (file.Tables["GRAPHIQUES"].Rows[0].ItemArray[0].ToString())
            {
                case "true":
                    StartRafraichissementBD();
                    BO_graphiques.StartRafraichissementGraphes();
                    break;
                case "false":
                    StopRafraichissementBD();
                    BO_graphiques.StopRafraichissementGraphes();
                    break;
                default:
                    break;
            }
        }

        public void saveParamFenetres()
        {
            file.Tables["FORM_REMOTE"].Rows[0][0] = Telecommande.Left.ToString();
            file.Tables["FORM_REMOTE"].Rows[0][1] = Telecommande.Top.ToString();
            file.Tables["FORM_REMOTE"].Rows[0][2] = Telecommande.Width.ToString();
            file.Tables["FORM_REMOTE"].Rows[0][3] = Telecommande.Height.ToString();

            file.Tables["FORM_GRAPH"].Rows[0][0] = BO_graphiques.Graphiques.Left.ToString();
            file.Tables["FORM_GRAPH"].Rows[0][1] = BO_graphiques.Graphiques.Top.ToString();
            file.Tables["FORM_GRAPH"].Rows[0][2] = BO_graphiques.Graphiques.Width.ToString();
            file.Tables["FORM_GRAPH"].Rows[0][3] = BO_graphiques.Graphiques.Height.ToString();

            file.Tables["FORM_CONSOLE"].Rows[0][0] = BO_communication.Console.Left.ToString();
            file.Tables["FORM_CONSOLE"].Rows[0][1] = BO_communication.Console.Top.ToString();
            file.Tables["FORM_CONSOLE"].Rows[0][2] = BO_communication.Console.Width.ToString();
            file.Tables["FORM_CONSOLE"].Rows[0][3] = BO_communication.Console.Height.ToString();

            file.WriteXml(NomFichierXML);
        }

        public void RafraichissementTelecommande()
        {
            Telecommande.setPositionBallastAvant(PositionsBallasts.getPositionBallast1());
            Telecommande.setPositionBallastArriere(PositionsBallasts.getPositionBallast2());
            Telecommande.setVitessseMoteur1(VitessesPropulsion.getVitesseMoteur1());
            Telecommande.setVitessseMoteur2(VitessesPropulsion.getVitesseMoteur2());
            Telecommande.setProfondeur(Profondeur.getProfondeur());
            Telecommande.setInclinaisonAxeX(Inclinaison.getInclinaisonAxeX());
            Telecommande.setInclinaisonAxeY(Inclinaison.getInclinaisonAxeY());
        }

        public void RafraichissementSousMarin()
        {
            ConsignesBallasts.setConsigneBallast1(Telecommande.getConsigneBallastAvant());
            ConsignesBallasts.setConsigneBallast2(Telecommande.getConsigneBallastArriere());
            ConsignePropulsion.setConsigneMoteur1(Telecommande.getConsignePropulsion());
            ConsignePropulsion.setConsigneMoteur2(Telecommande.getConsignePropulsion()); // meme consigne pour les deux moteurs de propulsion
        }

        public void RafraichissementConsole()
        {
            BO_communication.Console.ajoutString(BO_communication.getData());
        }

        public void EcritureSerie(byte[] data)
        {
            BO_communication.write(data);
        }

        public void EcritureSerie(String data)
        {
            BO_communication.write(data.ToCharArray());
        }

        public void LancerProgrammeFB()
        {
            BO_communication.Console.ajoutString("> Lancement du programme dans le sous-marin...\n");
            BO_communication.Console.ajoutString("> Paramètrage de la FoxBoard :\n\n");
            EcritureSerie("stty -F /dev/ttyS3 9600\n");
            EcritureSerie("stty -F /dev/ttyS2 9600\n");
            EcritureSerie("stty -F /dev/ttyS2 -onlcr\n");
            EcritureSerie("stty -F /dev/ttyS3 -onlcr\n");
            EcritureSerie("cd /mnt/flash/submarine\n");
            EcritureSerie("./main\n");
        }

        public void ArreterProgrammeFB()
        {
            BO_communication.Console.ajoutString("Z\n");
        }

        public void StartRafraichissementBD()
        {
            TimerRafraichissementBD.Start();
        }

        public void StopRafraichissementBD()
        {
            TimerRafraichissementBD.Stop();
        }

        private void TimerTelecommande_Tick(object sender, EventArgs e)
        {
            PositionsBallasts.setPositionBallast1(BO_communication.getPositionAvant());
            PositionsBallasts.setPositionBallast2(BO_communication.getPositionArriere());
            Inclinaison.setInclinaisonAxeX(BO_communication.getInclinaisonX());
            Inclinaison.setInclinaisonAxeY(BO_communication.getInclinaisonY());
            Profondeur.setProfondeur(BO_communication.getProfondeur());
            RafraichissementTelecommande();
        }

        private void TimerRafraichissementBD_Tick(object sender, EventArgs e)
        {
            BO_graphiques.BaseDeDonnees.AjoutValeur("PositionBallast1", BO_communication.getPositionAvant());
            BO_graphiques.BaseDeDonnees.AjoutValeur("PositionBallast2", BO_communication.getPositionArriere());
            BO_graphiques.BaseDeDonnees.AjoutValeur("Profondeur", BO_communication.getProfondeur());
            BO_graphiques.BaseDeDonnees.AjoutValeur("InclinaisonAxeX", BO_communication.getInclinaisonX());
            BO_graphiques.BaseDeDonnees.AjoutValeur("InclinaisonAxeY", BO_communication.getInclinaisonY());
        }

        private void compteurARebours_Tick(object sender, EventArgs e)
        {
            RafraichissementConsole();
        }
    }

    class MoteursBallasts
    {
        private int ConsigneBallast1;
        private int ConsigneBallast1Prec;
        private int ConsigneBallast2;
        private int ConsigneBallast2Prec;

        public int getConsigneBallast1()
        {
            return ConsigneBallast1;
        }

        public int getConsigneBallast1Prec()
        {
            return ConsigneBallast1Prec;
        }

        public int getConsigneBallast2()
        {
            return ConsigneBallast2;
        }

        public int getConsigneBallast2Prec()
        {
            return ConsigneBallast2Prec;
        }

        public void setConsigneBallast1(int Valeur)
        {
            ConsigneBallast1Prec = ConsigneBallast1;
            ConsigneBallast1 = Valeur;
        }

        public void setConsigneBallast2(int Valeur)
        {
            ConsigneBallast2Prec = ConsigneBallast2;
            ConsigneBallast2 = Valeur;
        }
    }

    class CapteursBallasts
    {
        private int PositionBallast1;
        private int PositionBallast1Prec;
        private int PositionBallast2;
        private int PositionBallast2Prec;

        public int getPositionBallast1()
        {
            return PositionBallast1;
        }

        public int getPositionBallast1Prec()
        {
            return PositionBallast1Prec;
        }

        public int getPositionBallast2()
        {
            return PositionBallast2;
        }

        public int getPositionBallast2Prec()
        {
            return PositionBallast2Prec;
        }

        public void setPositionBallast1(int Valeur)
        {
            PositionBallast1Prec = PositionBallast1;
            PositionBallast1 = Valeur;
        }

        public void setPositionBallast2(int Valeur)
        {
            PositionBallast2Prec = PositionBallast2;
            PositionBallast2 = Valeur;
        }
    }

    class MoteursPropulsion
    {
        private int ConsigneMoteur1;
        private int ConsigneMoteur1Prec;
        private int ConsigneMoteur2;
        private int ConsigneMoteur2Prec;

        public int getConsigneMoteur1()
        {
            return ConsigneMoteur1;
        }

        public int getConsigneMoteur1Prec()
        {
            return ConsigneMoteur1Prec;
        }

        public int getConsigneMoteur2()
        {
            return ConsigneMoteur2;
        }

        public int getConsigneMoteur2Prec()
        {
            return ConsigneMoteur2Prec;
        }

        public void setConsigneMoteur1(int Valeur)
        {
            ConsigneMoteur1Prec = ConsigneMoteur1;
            ConsigneMoteur1 = Valeur;
        }

        public void setConsigneMoteur2(int Valeur)
        {
            ConsigneMoteur2Prec = ConsigneMoteur2;
            ConsigneMoteur2 = Valeur;
        }
    }

    class CapteursPropulsion
    {
        private int VitesseMoteur1;
        private int VitesseMoteur1Prec;
        private int VitesseMoteur2;
        private int VitesseMoteur2Prec;

        public int getVitesseMoteur1()
        {
            return VitesseMoteur1;
        }

        public int getVitesseMoteur1Prec()
        {
            return VitesseMoteur1Prec;
        }

        public int getVitesseMoteur2()
        {
            return VitesseMoteur2;
        }

        public int getVitesseMoteur2Prec()
        {
            return VitesseMoteur2Prec;
        }

        public void setVitesseMoteur1(int Valeur)
        {
            VitesseMoteur1Prec = VitesseMoteur1;
            VitesseMoteur1 = Valeur;
        }

        public void setVitesseMoteur2(int Valeur)
        {
            VitesseMoteur2Prec = VitesseMoteur2;
            VitesseMoteur2 = Valeur;
        }
    }

    class CapteurProfondeur
    {
        private int Profondeur;
        private int ProfondeurPrec;

        public int getProfondeur()
        {
            return Profondeur;
        }

        public int getProfondeurPrec()
        {
            return ProfondeurPrec;
        }

        public void setProfondeur(int Valeur)
        {
            ProfondeurPrec = Profondeur;
            Profondeur = Valeur;
        }
    }

    class CapteurInclinaison
    {
        private int InclinaisonAxeX;
        private int InclinaisonAxeXPrec;
        private int InclinaisonAxeY;
        private int InclinaisonAxeYPrec;

        public int getInclinaisonAxeX()
        {
            return InclinaisonAxeX;
        }

        public int getInclinaisonAxeXPrec()
        {
            return InclinaisonAxeXPrec;
        }

        public int getInclinaisonAxeY()
        {
            return InclinaisonAxeY;
        }

        public int getInclinaisonAxeYPrec()
        {
            return InclinaisonAxeYPrec;
        }

        public void setInclinaisonAxeX(int Valeur)
        {
            InclinaisonAxeXPrec = InclinaisonAxeX;
            InclinaisonAxeX = Valeur;
        }

        public void setInclinaisonAxeY(int Valeur)
        {
            InclinaisonAxeYPrec = InclinaisonAxeY;
            InclinaisonAxeY = Valeur;
        }
    }

    public class xml_reader
    {
        private DataSet FileSet;

        public xml_reader(String NomFichierXML)
        {
            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load(NomFichierXML);

            XmlNodeReader xnr_test = new XmlNodeReader(xmlFile);
            FileSet = new DataSet();

            FileSet.ReadXml(xnr_test);
        }

        public DataSet getFileSet()
        {
            return FileSet;
        }
    }
}