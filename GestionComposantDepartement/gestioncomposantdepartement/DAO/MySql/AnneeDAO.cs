using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using gestioncomposantdepartement.DAO;
using gestioncomposantdepartement.Metier; 

namespace gestioncomposantdepartement.DAO.MySql
{
    class AnneeDAO:DAO
    {

        public const int ID_ANNEE = 0;
        public const int ETUDE_ANNEE = 1;


        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Annee  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    etude varchar(10) NOT NULL,
                    diplome_id int NOT NULL,
                    PRIMARY KEY (id), 
                    FOREIGN KEY (diplome_id) REFERENCES projetgestiondepartement.Diplome (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }


        public void create(Annee annee)
        {
            try
            {
                //création de la table annee
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Annee (id,etude,diplome_id)  VALUES  (@id,@etude,@diplome_id);";

                commande.Parameters.AddWithValue("@id", annee.id);
                commande.Parameters.AddWithValue("@etude", annee.etude);

                commande.Parameters.AddWithValue("@diplome_id", annee.DiplomePropriete.id);

                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public void update(Annee annee)
        {
            try
            {
                //modif d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"UPDATE projetgestiondepartement.Annee
                              SET etude = @etude
                              WHERE projetgestiondepartement.Annee.id = @id;";


                commande.Parameters.AddWithValue("@etude", annee.etude);

                commande.Parameters.AddWithValue("@id", annee.id);

                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Annee objetAnnee(MySqlDataReader msdr,Diplome diplome)
        {

            Annee annee = new Annee();
            annee.id = msdr.GetInt32(ID_ANNEE);
            annee.etude = msdr.GetString(ETUDE_ANNEE);

            annee.DiplomePropriete = diplome;
            return annee;
        }

        public List<Annee> findByDiplome(Diplome dip)
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Annee  
                                   WHERE projetgestiondepartement.Annee.diplome_id = " + dip.id; 
 
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Annee> annees = new List<Annee>(msdr.FieldCount);
            Annee a; 
            while (msdr.Read())
            {
                a = this.objetAnnee(msdr,dip);
                annees.Add(a);
            }
            msdr.Close();
            return annees;
        }


        public List<Annee> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Annee; " ;

            MySqlDataReader msdr = commande.ExecuteReader();
            List<Annee> annees = new List<Annee>(msdr.FieldCount);
            Annee a;
            Diplome dip = new Diplome();
            while (msdr.Read())
            {

                a = this.objetAnnee(msdr,dip);
                annees.Add(a);
            }
            msdr.Close();
            return annees;
        }

        public void delete(int id)
        {
            try
            {
                commande.CommandText = @"DELETE FROM projetgestiondepartement.Annee 
                                        WHERE projetgestiondepartement.Annee.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                msdr.Close();

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }
    }
}
