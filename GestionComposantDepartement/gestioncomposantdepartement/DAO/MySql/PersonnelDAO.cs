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
    public class PersonnelDAO:DAO
    {
        public const int ID_PERSONNEL = 0;
        public const int PRENOM_PERSONNEL = 1;
        public const int NOM_PERSONNEL = 2;

        public const int ID_CATEGORIE = 4;
        public const int NOM_CATEGORIE = 5;
        public const int NB_HEURES_CATEGORIE = 6;

        public const int ID_COURS = 0;
        public const int GROUPE_COURS = 1;
        public const int NB_HEURE_T_COURS = 2;
        public const int HEURES_COURS = 3;

        public const int ID_EC = 7;
        public const int NOM_EC = 8; 

        public const int ID_TYPE_COURS = 10;
        public const int NOM_TYPE_COURS = 11; 

        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Personnel  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    prenom VARCHAR(255) NOT NULL,
                    nom VARCHAR(255) NOT NULL,
                    categorie_id int NOT NULL,
                    PRIMARY KEY (id), 
                    FOREIGN KEY (categorie_id) REFERENCES projetgestiondepartement.Categorie (id) ON DELETE RESTRICT ON UPDATE RESTRICT

                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut(){ }

        public void create(Personnel personnel)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Personnel (prenom , nom, categorie_id)  VALUES  (@prenom , @nom, @categorie_id);";
                commande.Parameters.AddWithValue("@prenom", personnel.PrenomPropriete);
                commande.Parameters.AddWithValue("@nom", personnel.NomPropriete);
                commande.Parameters.AddWithValue("@categorie_id", personnel.CategoriePropriete.id);
                
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Personnel find(int id)
        {
            try
            {
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Personnel 
                                        JOIN projetgestiondepartement.Categorie ON projetgestiondepartement.Personnel.categorie_id = projetgestiondepartement.Categorie.id 
                                        WHERE projetgestiondepartement.Personnel.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Categorie categorie = this.objetCategorie(msdr);
                Personnel personnel = this.objetPersonnel(msdr);
                personnel.CategoriePropriete = categorie;
                msdr.Close();
                
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Cours   
                                        JOIN projetgestiondepartement.EC ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.EC.id  
                                        JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Cours.type_id = projetgestiondepartement.TypeCours.id
                                        WHERE projetgestiondepartement.Cours.personnel_id = " + id;
                msdr = commande.ExecuteReader();
                List<Cours> listeCours = new List<Cours>();
                Ec ec; TypeCours typeCours;
                while (msdr.Read()) {
                    ec = this.objetEc(msdr);
                    typeCours = this.objetTypeCours(msdr); 
                    listeCours.Add(objetCours(ec,typeCours,msdr)); 
                } 
                msdr.Close();
                personnel.CoursPropriete = listeCours;
                
                return personnel;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Personnel> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Personnel  
                                   JOIN projetgestiondepartement.Categorie ON projetgestiondepartement.Personnel.categorie_id = projetgestiondepartement.Categorie.id";
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Personnel> personnels = new List<Personnel>(msdr.FieldCount);
            Personnel p; Categorie c;
            while (msdr.Read())
            {
                p = this.objetPersonnel(msdr);
                c = this.objetCategorie(msdr);
                p.CategoriePropriete = c;
                personnels.Add(p);
            }
            msdr.Close();
            return personnels; 
        }


        public Personnel objetPersonnel(MySqlDataReader msdr)
        {
            Personnel personnel = new Personnel();
            personnel.id = msdr.GetInt32(ID_PERSONNEL);
            personnel.PrenomPropriete = msdr.GetString(PRENOM_PERSONNEL);
            personnel.NomPropriete = msdr.GetString(NOM_PERSONNEL);
            return personnel;
        }

        public Cours objetCours(Ec ec, TypeCours typeCours, MySqlDataReader msdr)
        {
            Cours cours = new Cours();
            cours.id = msdr.GetInt32(ID_COURS);
            cours.GroupePropriete = msdr.GetString(GROUPE_COURS);
            cours.NbHeureTotalPropriete = msdr.GetInt32(NB_HEURE_T_COURS);
            cours.heuresPropriete = msdr.GetInt32(HEURES_COURS);
            cours.EcPropriete = ec; 
            cours.TypeCoursPropriete = typeCours;
            return cours;
        }

        public Ec objetEc(MySqlDataReader msdr){
            Ec ec = new Ec();
            ec.id = msdr.GetInt32(ID_EC);
            ec.NomPropriete = msdr.GetString(NOM_EC); 
            return ec; 
        }


        public TypeCours objetTypeCours(MySqlDataReader msdr)
        {
            TypeCours typeCours = new TypeCours();
            typeCours.id = msdr.GetInt32(ID_TYPE_COURS);
            typeCours.NomUniquePropriete = msdr.GetString(NOM_TYPE_COURS);
            return typeCours;
        }

        public Categorie objetCategorie(MySqlDataReader msdr){
            Categorie categorie = new Categorie();
            categorie.id = msdr.GetInt32(ID_CATEGORIE);
            categorie.NomUniquePropriete = msdr.GetString(NOM_CATEGORIE);
            categorie.NbHeuresPropriete = msdr.GetDouble(NB_HEURES_CATEGORIE); 
            return categorie;
        }

        public List<Personnel> findBy(Dictionary<string, string> contraintes)
        {
            try
            {
                int i = 0;
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"SELECT * FROM projetgestiondepartement.Personnel ");
                foreach (KeyValuePair<string, string> c in contraintes)
                {
                    if (i == 0) sb.Append("  WHERE projetgestiondepartement.Personnel." + c.Key + " ='" + c.Value + "'");
                    sb.Append("  AND projetgestiondepartement.Personnel." + c.Key + " = '" + c.Value + "'");
                    i++;
                }

                string query = sb.ToString();
                commande.CommandText = query;
                MySqlDataReader msdr = commande.ExecuteReader();
                List<Personnel> lc = new List<Personnel>();
                while (msdr.Read())
                {
                    lc.Add(this.objetPersonnel(msdr));
                }
                msdr.Close();

                return lc;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public void delete(int id)
        {
            try
            {
                commande.CommandText = @"DELETE FROM projetgestiondepartement.Personnel 
                                        WHERE projetgestiondepartement.Personnel.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                msdr.Close();

                /*commande.CommandText = @"DELETE FROM projetgestiondepartement.Cours   
                                        JOIN projetgestiondepartement.EC ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.EC.id  
                                        JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Cours.type_id = projetgestiondepartement.TypeCours.id
                                        WHERE projetgestiondepartement.Cours.personnel_id = " + id;
                msdr = commande.ExecuteReader();
                msdr.Close();*/

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public void update(Personnel personnel, int categorieId)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"UPDATE projetgestiondepartement.Personnel 
                SET prenom = @prenom, nom = @nom, categorie_id = @categorie_id
                WHERE projetgestiondepartement.Personnel.id = @id;";
                //VALUES  (@prenom , @nom, @categorie_id, @departement_id);";
                commande.Parameters.AddWithValue("@id", personnel.id);
                commande.Parameters.AddWithValue("@prenom", personnel.PrenomPropriete);
                commande.Parameters.AddWithValue("@nom", personnel.NomPropriete);
                commande.Parameters.AddWithValue("@categorie_id", categorieId);

                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

    }
}
