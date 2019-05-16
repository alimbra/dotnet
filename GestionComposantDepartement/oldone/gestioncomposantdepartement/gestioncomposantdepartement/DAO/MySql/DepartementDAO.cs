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
    public class DepartementDAO:DAO
    {
        public const int ID_DEPARTEMENT = 0;
        public const int NOM_DEPARTEMENT = 1;
        
        public const int ID_DIRECTEUR = 3;
        public const int PRENOM_DIRECTEUR = 4;
        public const int NOM_DIRECTEUR = 5;

        public const int ID_PERSONNEL = 0;
        public const int PRENOM_PERSONNEL = 1;
        public const int NOM_PERSONNEL = 2;


        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Departement  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    nom VARCHAR(255) NOT NULL,
                    directeur_id int DEFAULT NULL,
                    PRIMARY KEY (id), 
                    FOREIGN KEY (directeur_id) REFERENCES projetgestiondepartement.Personnel (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }

        public void create(Departement departement)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Departement (nom , directeur_id)  VALUES  (@nom , @directeur_id);";
                commande.Parameters.AddWithValue("@nom", departement.NomPropriete);
                commande.Parameters.AddWithValue("@directeur_id", departement.directeurPropriete.id);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Departement find(int id)
        {
            try
            {
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Departement
                                        JOIN projetgestiondepartement.Personnel ON projetgestiondepartement.Departement.directeur_id = projetgestiondepartement.Personnel.id    
                                        WHERE projetgestiondepartement.Departement.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Departement departement = this.objetDepartement(msdr);
                Personnel directeur = this.objetPersonnel(msdr);
                departement.directeurPropriete = directeur;
                msdr.Close();

                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Personnel
                                        WHERE projetgestiondepartement.Personnel.departement_id = " + id;
                msdr = commande.ExecuteReader();
                List<Personnel> listePersonnel = new List<Personnel>(msdr.FieldCount); 
                while(msdr.Read()){
                    listePersonnel.Add(this.objetPersonnel2(msdr));
                }
                departement.ListePersonnelPropriete = listePersonnel; 
                msdr.Close();

                return departement;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Departement objetDepartement(MySqlDataReader msdr)
        {
            Departement departement = new Departement();
            departement.id = msdr.GetInt32(ID_DEPARTEMENT);
            departement.NomPropriete = msdr.GetString(NOM_DEPARTEMENT);
            return departement;
        }

        public Personnel objetPersonnel(MySqlDataReader msdr)
        {
            Personnel personnel = new Personnel();
            personnel.id = msdr.GetInt32(ID_DIRECTEUR);
            personnel.PrenomPropriete = msdr.GetString(PRENOM_DIRECTEUR);
            personnel.NomPropriete = msdr.GetString(NOM_DIRECTEUR);
            return personnel;
        }

        public Personnel objetPersonnel2(MySqlDataReader msdr)
        {
            Personnel personnel = new Personnel();
            personnel.id = msdr.GetInt32(ID_PERSONNEL);
            personnel.PrenomPropriete = msdr.GetString(PRENOM_PERSONNEL);
            personnel.NomPropriete = msdr.GetString(NOM_PERSONNEL);
            return personnel;
        }
    }
}
