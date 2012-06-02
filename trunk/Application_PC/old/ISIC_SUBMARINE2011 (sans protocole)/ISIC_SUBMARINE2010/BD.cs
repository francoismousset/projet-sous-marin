using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace ISIC_SUBMARINE2010
{
    public class BD
    {
        private SqlCeConnection connection;

        public BD()
        {
            connection = new SqlCeConnection(ConnectString());
        }

        // fonctions pour la connexion

        public void connexion()
        {
            //ConnectString();
            connection.Open();
        }

        private string ConnectString()
        {
            string connectionString;
            //string fileName = "BDSousMarin.sdf";
            string fileName = "C:\\Users\\Guillaume\\Desktop\\ISIC_SUBMARINE2011 (sans protocole)\\ISIC_SUBMARINE2010\\bin\\Debug\\BDSousMarin.sdf";
            //string fileName = "C:\\Documents and Settings\\Frédéric\\Bureau\\ISIC_SUBMARINE2010\\ISIC_SUBMARINE2010\\bin\\Debug\\BDSousMarin.sdf";
            string password = "password";
            connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);

            return connectionString;
        }

        // déconnexion

        public void deconnexion()
        {
            //ConnectString();
            connection.Close();
        }

        // ajout d'une valeur

        public void AjoutValeur(String table, int valeur)
        {
            SqlCeTransaction transaction = connection.BeginTransaction();
            SqlCeCommand myCommand_insert = connection.CreateCommand();
            myCommand_insert.Transaction = transaction;

            try
            {
                myCommand_insert.CommandText = "INSERT INTO " + table + " ([Valeur], [Heure]) VALUES ('" + valeur.ToString() + "', '" + Maintenant() + "')";
                myCommand_insert.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        private string Maintenant()
        {
            return DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
        }

        // lecture d'une valeur

        public int LireValeur(String table, int ID)
        {
            string SelectValeur = "SELECT Valeur FROM " + table + " WHERE ID = " + ID.ToString();
            SqlCeCommand command = new SqlCeCommand(SelectValeur, connection);
            SqlCeDataReader myReader = command.ExecuteReader();
            myReader.Read();

            return Convert.ToInt32(myReader["Valeur"]);
        }

        // lecture de la taille d'une table

        public int DernierID(String table)
        {
            string resultat;

            string SelectDernierID = "SELECT MAX(ID) AS DernierID FROM " + table;
            SqlCeCommand command = new SqlCeCommand(SelectDernierID, connection);
            SqlCeDataReader myReader = command.ExecuteReader();
            myReader.Read();
            resultat = myReader["DernierID"].ToString();

            if (resultat == "") // si la table n'a jamais été remplie, on renvoit 0
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(resultat);
            }
        }

        public void SupprimerContenuTable(String table)
        {
            SqlCeTransaction transaction = connection.BeginTransaction();
            SqlCeCommand myCommand_delete = connection.CreateCommand();
            myCommand_delete.Transaction = transaction;

            try
            {
                myCommand_delete.CommandText = "DELETE FROM " + table;
                myCommand_delete.ExecuteNonQuery();

                //myCommand_delete.CommandText = "DBCC CHECKIDENT (" + table + ", reseed, 1)";
                //myCommand_delete.ExecuteNonQuery();

                //myCommand_delete.CommandText = "ALTER TABLE " + table + " AUTO_INCREMENT=0";
                //myCommand_delete.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
        public void IDnulTable(String table)
        {
            SqlCeTransaction transaction = connection.BeginTransaction();
            SqlCeCommand myCommand_alter = connection.CreateCommand();
            myCommand_alter.Transaction = transaction;

            try
            {
                //myCommand_alter.CommandText = "ALTER TABLE PositionBallast1 AUTO_INCREMENT=0";
                //myCommand_alter.ExecuteNonQuery();
             
                myCommand_alter.CommandText = "DBCC CHECKIDENT (" + table + ", reseed, 1)";
                myCommand_alter.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

    }
}
