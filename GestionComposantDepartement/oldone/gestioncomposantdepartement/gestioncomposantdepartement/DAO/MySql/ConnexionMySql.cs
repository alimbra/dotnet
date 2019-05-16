using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace gestioncomposantdepartement.DAO.MySql
{
    class ConnexionMySql
    {
        private static MySqlConnection connexion;
        private static MySqlCommand _cmd;
        private static ConnexionMySql instance = null;

        private ConnexionMySql(){ }

        public void initConnexion()
        {
            //détails de la connexion
            String connexionString = "SERVER=localhost; UID=root; PASSWORD=;";
            //créer la connexion à la base de données 
            connexion = new MySqlConnection(connexionString);
            _cmd = new MySqlCommand();

            try
            {
                //creation de la connexion 
                _cmd.Connection = connexion;
                //ouvrir la connexion
                _cmd.Connection.Open();
                Console.WriteLine("Connexion établie !");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                throw ex;
            }
        }

        public void initConnexion(string host, string username, string password)
        {
            //détails de la connexion
            String connexionString = "SERVER="+host+"; UID="+username+"; PASSWORD="+password+";";
            //créer la connexion à la base de données 
            connexion = new MySqlConnection(connexionString);
            _cmd = new MySqlCommand();

            try
            {
                //creation de la connexion 
                _cmd.Connection = connexion;
                //ouvrir la connexion
                _cmd.Connection.Open();
                Console.WriteLine("Connexion établie !");
            }
            catch (NullReferenceException ex){Console.WriteLine("Error: {0}", ex.ToString());throw ex;}
        }

        public static ConnexionMySql getInstance()
        {   
            if(instance == null ) instance = new ConnexionMySql();
            return instance; 
        }

        public void creerBaseDeDonnees()
        {
            _cmd.CommandText = "CREATE DATABASE IF NOT EXISTS projetgestiondepartement";
            try
            {
                _cmd.ExecuteNonQuery();
                Console.WriteLine("Base de données créer avec succès !");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                throw ex;
            }
        }

        public MySqlCommand getCommande(){return _cmd;}

    }
}
