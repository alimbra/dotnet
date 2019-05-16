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
    class SemestreDAO : DAO
    {
        public const int ID_SEMESTRE = 0;
        public const int TITRE_SEMESTRE = 1;

        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Semestre  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    titre varchar(10) NOT NULL,
                    annee_id int NOT NULL,
                    PRIMARY KEY (id), 
                    FOREIGN KEY (annee_id) REFERENCES projetgestiondepartement.Annee (id)
                    ON DELETE RESTRICT ON UPDATE RESTRICT
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }


        public void create(Semestre semestre)
        {
            try
            {
                //création de la table semestre
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Semestre (titre, annee_id)  VALUES  (@titre, @annee_id);";
                commande.Parameters.AddWithValue("@titre", semestre.titre);
                commande.Parameters.AddWithValue("@annee_id", semestre.AnneePropriete.id);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }
        public Semestre objetSemestre(MySqlDataReader msdr, Annee annee)
        {

            Semestre semestre = new Semestre();
            semestre.id = msdr.GetInt32(ID_SEMESTRE);
            semestre.titre = msdr.GetString(TITRE_SEMESTRE);

            semestre.AnneePropriete = annee;
            return semestre;
        }

        public Semestre objetSemestre(MySqlDataReader msdr)
        {

            Semestre semestre = new Semestre();
            semestre.id = msdr.GetInt32(ID_SEMESTRE);
            semestre.titre = msdr.GetString(TITRE_SEMESTRE);
            return semestre;
        }

        public List<Semestre> findByAnnee(Annee an)
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Semestre  
                                   WHERE projetgestiondepartement.Semestre.annee_id = " + an.id;

            MySqlDataReader msdr = commande.ExecuteReader();
            List<Semestre> semestres = new List<Semestre>(msdr.FieldCount);
            Semestre s;
            while (msdr.Read())
            {
                s = this.objetSemestre(msdr, an);
                semestres.Add(s);
            }
            msdr.Close();
            return semestres;
        }

        public List<Semestre> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Semestre";

            MySqlDataReader msdr = commande.ExecuteReader();
            List<Semestre> semestres = new List<Semestre>(msdr.FieldCount);
            Semestre s;
            while (msdr.Read())
            {
                s = this.objetSemestre(msdr);
                semestres.Add(s);
            }
            msdr.Close();
            return semestres;
        }



        public List<Semestre> findByNom(String nom)
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Semestre  
                                    
                                   WHERE projetgestiondepartement.Semestre.nom = " + nom;

            MySqlDataReader msdr = commande.ExecuteReader();
            List<Semestre> semestres = new List<Semestre>(msdr.FieldCount);
            Semestre s;
            while (msdr.Read())
            {
                s = this.objetSemestre(msdr);
                semestres.Add(s);
            }
            msdr.Close();
            return semestres;
        }


        public void delete(int id)
        {
            try
            {
                commande.CommandText = @"DELETE FROM projetgestiondepartement.Semestre 
                                        WHERE projetgestiondepartement.Semestre.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                msdr.Close();

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public void update(Semestre semestre)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"UPDATE projetgestiondepartement.Semestre 
                SET titre = @titre
                WHERE projetgestiondepartement.Semestre.id = @id;";
                commande.Parameters.AddWithValue("@id", semestre.id);
                commande.Parameters.AddWithValue("@titre", semestre.titre);

                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

    }
 }




