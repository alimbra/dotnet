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
    class DiplomeDAO:DAO
    {

        public const int ID_DIPLOME = 0;
        public const int INTITULE_DIPLOME = 1;

        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Diplome  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    intitule varchar(255) NOT NULL,
                    PRIMARY KEY (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }


        public void create(Diplome diplome)
        {
            try
            {
                //création de la table diplome
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.diplome (intitule)  VALUES  (@intitule);";
                commande.Parameters.AddWithValue("@intitule", diplome.intitule);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Diplome objetDiplome(MySqlDataReader msdr)
        {
            Diplome diplome = new Diplome();
            diplome.id = msdr.GetInt32(ID_DIPLOME);
            diplome.intitule = msdr.GetString(INTITULE_DIPLOME);
            return diplome;
        }
        public List<Diplome> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.diplome";
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Diplome> diplomes = new List<Diplome>(msdr.FieldCount);
            Diplome d;
            while (msdr.Read())
            {
                d = this.objetDiplome(msdr);
                diplomes.Add(d);
            }
            msdr.Close();
            return diplomes;
        }


        public void delete(int id)
        {
            try
            {
                commande.CommandText = @"DELETE FROM projetgestiondepartement.Diplome 
                                        WHERE projetgestiondepartement.Diplome.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                msdr.Close();


            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public void update(Diplome dip)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"UPDATE projetgestiondepartement.Diplome 
                SET intitule = @intitule
                WHERE projetgestiondepartement.Diplome.id = @id;";
                commande.Parameters.AddWithValue("@id", dip.id);
                commande.Parameters.AddWithValue("@intitule", dip.intitule);

                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Diplome find(int id)
        {
            try
            {
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Diplome 
                                        WHERE projetgestiondepartement.Diplome.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Diplome diplome = this.objetDiplome(msdr);
                msdr.Close();

                return diplome;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

    }
}
