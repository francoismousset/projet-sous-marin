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
    public class BO_Param
    {
        private FormMain parent;
        private String NomFichierXML;
        
        private String[] ReadFile_General;
        private String[] ReadFile_RS232;
        private String[] ReadFile_Graphiques;
        private String[] WriteFile_General;
        private String[] WriteFile_RS232;
        private String[] WriteFile_Graphiques;

        private FormParam Configuration;

        public BO_Param(FormMain parent, String NomFichierXML)
        {
            this.parent = parent;
            this.NomFichierXML = NomFichierXML;
            
            // création des 3 tableaux pour les 3 onglets

            ReadFile_General = new string[5];
            ReadFile_RS232 = new string[8];
            ReadFile_Graphiques = new string[9];
            WriteFile_General = new string[5];
            WriteFile_RS232 = new string[8];
            WriteFile_Graphiques = new string[9];

            int i;
            
            for (i = 0; i < 5; i++)
            {
                ReadFile_General[i] = parent.SM.file.Tables["GENERAL"].Rows[0].ItemArray[i].ToString();
            }

            for (i = 0; i < 8; i++)
            {
                ReadFile_RS232[i] = parent.SM.file.Tables["RS232"].Rows[0].ItemArray[i].ToString();
            }

            for (i = 0; i < 9; i++)
            {
                ReadFile_Graphiques[i] = parent.SM.file.Tables["GRAPHIQUES"].Rows[0].ItemArray[i].ToString();
            }

            // création de la fenêtre de config

            Configuration = new FormParam(NomFichierXML, this, parent);
            Configuration.Show();
        }

        public void saveData()
        {
            setNom(Configuration.General.getnomSM());
            setPoids(Configuration.General.getpoidsSM());
            setLongueur(Configuration.General.getlongueurSM());
            setLargeur(Configuration.General.getlargeurSM());
            setHauteur(Configuration.General.gethauteurSM());

            setBaudrate(Configuration.RS232.getBaudrate());
            setNombreDeBits(Configuration.RS232.getNbBits());
            setNombreDeBitsDeStop(Configuration.RS232.getNbBitsStop());
            setParite(Configuration.RS232.getParity());
            setTimeOutSortie(Configuration.RS232.getTimeOutSortie());
            setTimeOutEntree(Configuration.RS232.getTimeOutEntree());
            setTailleBufferEntree(Configuration.RS232.getBufferEntree());
            setTailleBufferSortie(Configuration.RS232.getBufferSortie());

            setTauxRafraichissement(Configuration.Graphiques.getTauxRafraichissement().ToString());
            setTailleFenetre(Configuration.Graphiques.getTailleFenetre().ToString());
            setCapteurGraphe1(Configuration.Graphiques.getCapteurGraphe1());
            setCouleurCourbe1(Configuration.Graphiques.getCouleurCourbe1());
            setCouleurFond1(Configuration.Graphiques.getCouleurFond1());
            setCapteurGraphe2(Configuration.Graphiques.getCapteurGraphe2());
            setCouleurCourbe2(Configuration.Graphiques.getCouleurCourbe2());
            setCouleurFond2(Configuration.Graphiques.getCouleurFond2());

            setActivationAcquisition(Configuration.BaseDeDonnees.getCheckboxAcquisition());

            writingFile();
        }

        public void writingFile()
        {
            int i;

            for (i = 0; i < 5; i++)
            {
                parent.SM.file.Tables["GENERAL"].Rows[0][i] = WriteFile_General[i];
            }

            for (i = 0; i < 8; i++)
            {
                parent.SM.file.Tables["RS232"].Rows[0][i] = WriteFile_RS232[i];
            }

            for (i = 0; i < 9; i++)
            {
                parent.SM.file.Tables["GRAPHIQUES"].Rows[0][i] = WriteFile_Graphiques[i];
            }

            parent.SM.file.WriteXml(NomFichierXML);
        }

        // get pour le général

        public string getNom()
        {
            return ReadFile_General[0];
        }

        public string getPoids()
        {
            return ReadFile_General[1];
        }

        public string getLongueur()
        {
            return ReadFile_General[2];
        }

        public string getLargeur()
        {
            return ReadFile_General[3];
        }

        public string getHauteur()
        {
            return ReadFile_General[4];
        }

        // set pour le général

        public void setNom(string value)
        {
            WriteFile_General[0] = value;
        }

        public void setPoids(string value)
        {
            WriteFile_General[1] = value;
        }

        public void setLongueur(string value)
        {
            WriteFile_General[2] = value;
        }

        public void setLargeur(string value)
        {
            WriteFile_General[3] = value;
        }

        public void setHauteur(string value)
        {
            WriteFile_General[4] = value;
        }

        // get pour le RS232

        public string getBaudrate()
        {
            return ReadFile_RS232[0];
        }

        public string getNombreDeBits()
        {
            return ReadFile_RS232[1];
        }

        public string getParite()
        {
            return ReadFile_RS232[2];
        }

        public string getNombreDeBitsDeStop()
        {
            return ReadFile_RS232[3];
        }

        public string getTailleBufferEntree()
        {
            return ReadFile_RS232[4];
        }

        public string getTailleBufferSortie()
        {
            return ReadFile_RS232[5];
        }

        public string getTimeOutEntree()
        {
            return ReadFile_RS232[6];
        }

        public string getTimeOutSortie()
        {
            return ReadFile_RS232[7];
        }

        // set pour le RS232

        public void setBaudrate(string value)
        {
            WriteFile_RS232[0] = value;
        }

        public void setNombreDeBits(string value)
        {
            WriteFile_RS232[1] = value;
        }

        public void setParite(string value)
        {
            WriteFile_RS232[2] = value;
        }

        public void setNombreDeBitsDeStop(string value)
        {
            WriteFile_RS232[3] = value;
        }

        public void setTailleBufferEntree(string value)
        {
            WriteFile_RS232[4] = value;
        }

        public void setTailleBufferSortie(string value)
        {
            WriteFile_RS232[5] = value;
        }

        public void setTimeOutEntree(string value)
        {
            WriteFile_RS232[6] = value;
        }

        public void setTimeOutSortie(string value)
        {
            WriteFile_RS232[7] = value;
        }

        // set pour l'onglet graphiques

        public void setActivationAcquisition(string value)
        {
            WriteFile_Graphiques[0] = value;
        }

        public void setTauxRafraichissement(string value)
        {
            WriteFile_Graphiques[1] = value;
        }

        public void setTailleFenetre(string value)
        {
            WriteFile_Graphiques[2] = value;
        }

        public void setCapteurGraphe1(string value)
        {
            WriteFile_Graphiques[3] = value;
        }

        public void setCouleurCourbe1(string value)
        {
            WriteFile_Graphiques[4] = value;
        }

        public void setCouleurFond1(string value)
        {
            WriteFile_Graphiques[5] = value;
        }

        public void setCapteurGraphe2(string value)
        {
            WriteFile_Graphiques[6] = value;
        }

        public void setCouleurCourbe2(string value)
        {
            WriteFile_Graphiques[7] = value;
        }

        public void setCouleurFond2(string value)
        {
            WriteFile_Graphiques[8] = value;
        }

        // get pour l'onglet graphiques

        public string getActivationAcquisition()
        {
            return ReadFile_Graphiques[0];
        }

        public string getTauxRafraichissement()
        {
            return ReadFile_Graphiques[1];
        }

        public string getTailleFenetre()
        {
            return ReadFile_Graphiques[2];
        }

        public string getCapteurGraphe1()
        {
            return ReadFile_Graphiques[3];
        }

        public string getCouleurCourbe1()
        {
            return ReadFile_Graphiques[4];
        }

        public string getCouleurFond1()
        {
            return ReadFile_Graphiques[5];
        }

        public string getCapteurGraphe2()
        {
            return ReadFile_Graphiques[6];
        }

        public string getCouleurCourbe2()
        {
            return ReadFile_Graphiques[7];
        }

        public string getCouleurFond2()
        {
            return ReadFile_Graphiques[8];
        }
    }
}
