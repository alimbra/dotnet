using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using gestioncomposantdepartement.Metier; 
using gestioncomposantdepartement.DAO; 

namespace gestioncomposantdepartement.DAO.MySql
{
    public class UeDAO : DAO
    {

        public const int ID_UE = 0;
        public const int NOM_UE = 1; 
        public const int ID_EC = 0;
        public const int NOM_EC = 1;
        
        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.UE  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    nom VARCHAR(255) NOT NULL , 
                    PRIMARY KEY (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut(){ }
        
        public void create(Ue ue)
        {    
            try{
                //création de la table UE
                this.createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear(); 
                commande.CommandText = @"INSERT INTO projetgestiondepartement.UE (nom)  VALUES  (@nom);";
                commande.Parameters.AddWithValue("@nom", ue.NomPropriete); 
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public Ue find(int id)
        {
            try
            {
                //Recup ue 
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.UE 
                                           WHERE projetgestiondepartement.UE.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Ue ue = objetUe(msdr);
                msdr.Close();

                commande.CommandText = @"SELECT * FROM projetgestiondepartement.EC 
                                           WHERE projetgestiondepartement.EC.ue_id = " + id;
                msdr = commande.ExecuteReader();
                List<Ec> ecs = new List<Ec>();
                while (msdr.Read()) { ecs.Add(objetEc(ue, msdr)); }
                
                ue.EcsPropriete = ecs; 
                msdr.Close();

                return ue;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Ec objetEc(Ue ue, MySqlDataReader msdr)
        {
            Ec ec = new Ec();
            ec.id = msdr.GetInt32(ID_EC);
            ec.NomPropriete = msdr.GetString(NOM_EC);
            ec.UePropriete = ue;
            return ec;
        }

        public Ue objetUe(MySqlDataReader msdr)
        {
            Ue ue = new Ue();
            ue.id = msdr.GetInt32(ID_UE);
            ue.NomPropriete = msdr.GetString(NOM_UE);
            return ue;
        }
        
    }
}
