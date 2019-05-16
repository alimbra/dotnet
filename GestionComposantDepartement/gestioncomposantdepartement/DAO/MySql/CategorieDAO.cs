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
    class CategorieDAO:DAO
    {
        public const int ID_CATEGORIE = 0;
        public const int NOM_CATEGORIE = 1;
        public const int NB_HEURES_CATEGORIE = 2;

        public const int ID_PERSONNEL = 0;
        public const int PRENOM_PERSONNEL = 1;
        public const int NOM_PERSONNEL = 2;

        public const int ID_COEFFICIENT = 0;
        public const int COEFFICIENT_COEFFICIENT = 1;
        public const int ID_TYPE_COURS = 4;
        public const int NOM_TYPE_COURS = 5;

        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Categorie  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    nom VARCHAR(255) NOT NULL UNIQUE,
                    nbHeure double NOT NULL,
                    PRIMARY KEY (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }


        public void create(Categorie categorie)
        {
            try
            {
                //création de la table EC
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Categorie (nom, nbHeure)  VALUES  (@nom, @nbHeure);";
                commande.Parameters.AddWithValue("@nom", categorie.NomUniquePropriete);
                commande.Parameters.AddWithValue("@nbHeure", categorie.NbHeuresPropriete);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public Categorie find(int id)
        {
            try
            {
                //Recup ec 
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Categorie    
                                        WHERE projetgestiondepartement.Categorie.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Categorie categorie = this.objetCategorie(msdr);
                msdr.Close();

                //Recup personnels
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Personnel 
                                        WHERE projetgestiondepartement.Personnel.categorie_id = " + id;
                msdr = commande.ExecuteReader();
                List<Personnel> personnels = new List<Personnel>();
                while (msdr.Read()){ personnels.Add(objetPersonnel(categorie, msdr)); }
                categorie.personnelsPropriete = personnels;
                msdr.Close();

                //Recup coefficients
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Coefficient  
                                        JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Coefficient.typeCours_id = projetgestiondepartement.TypeCours.id  
                                        WHERE projetgestiondepartement.Coefficient.categorie_id = " + id;
                msdr = commande.ExecuteReader();
                List<Coefficient> coefficients = new List<Coefficient>(msdr.FieldCount);
                while (msdr.Read()) { coefficients.Add(objetCoefficient(categorie, msdr)); }
                categorie.coefficientsPropriete = coefficients;
                msdr.Close();

                return categorie;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Categorie> findBy(Dictionary<string, string> contraintes)
        {
            try
            {
                int i = 0; 
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"SELECT * FROM projetgestiondepartement.Categorie ");
                foreach (KeyValuePair<string, string> c in contraintes)
                {
                    if (i == 0) sb.Append("  WHERE projetgestiondepartement.Categorie."+c.Key+" ='"+c.Value+"'");
                    sb.Append("  AND projetgestiondepartement.Categorie." + c.Key + " = '"+c.Value+"'");
                    i++;
                }

                string query = sb.ToString();
                //Console.WriteLine(query);
                commande.CommandText = query;
                MySqlDataReader msdr = commande.ExecuteReader();
                List<Categorie> lc = new List<Categorie>();
                while (msdr.Read())
                {
                    lc.Add(this.objetCategorie(msdr)); 
                }
                msdr.Close();

                return lc;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Categorie> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Categorie ";
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Categorie> categories = new List<Categorie>(msdr.FieldCount);
            while (msdr.Read()){categories.Add(objetCategorie(msdr)); }
            msdr.Close();
            return categories;
        }

        public Categorie objetCategorie(MySqlDataReader msdr)
        {
            Categorie categorie = new Categorie();
            categorie.id = msdr.GetInt32(ID_CATEGORIE);
            categorie.NomUniquePropriete = msdr.GetString(NOM_CATEGORIE);
            categorie.NbHeuresPropriete = msdr.GetDouble(NB_HEURES_CATEGORIE);
            return categorie;
        }

        public Personnel objetPersonnel(Categorie c, MySqlDataReader msdr){
            Personnel personnel = new Personnel();
            personnel.id = msdr.GetInt32(ID_PERSONNEL); 
            personnel.PrenomPropriete = msdr.GetString(PRENOM_PERSONNEL); 
            personnel.NomPropriete = msdr.GetString(NOM_PERSONNEL); 
            personnel.CategoriePropriete = c;
            return personnel; 
        }

        public Coefficient objetCoefficient(Categorie c, MySqlDataReader msdr)
        {
            Coefficient coefficient = new Coefficient();
            coefficient.id = msdr.GetInt32(ID_COEFFICIENT);
            coefficient.coefficient = msdr.GetDouble(COEFFICIENT_COEFFICIENT);
            TypeCours tc = new TypeCours();
            tc.id = msdr.GetInt32(ID_TYPE_COURS);
            tc.NomUniquePropriete = msdr.GetString(NOM_TYPE_COURS);
            coefficient.categorie = c;
            coefficient.typeCours = tc;
            return coefficient;
        }

        public Categorie findByNom(String nom)
        {

            try
            {
                //Recup ec 
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Categorie    
                                        WHERE projetgestiondepartement.Categorie.nom like '" + nom + "'";
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Categorie categorie = this.objetCategorie(msdr);
                msdr.Close();
                /*
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Personnel 
                                        WHERE projetgestiondepartement.Personnel.categorie_id = "
                    +  categorie.id;
                msdr = commande.ExecuteReader();
                List<Personnel> personnels = new List<Personnel>();
                while (msdr.Read()) { personnels.Add(objetPersonnel(categorie, msdr)); }
                categorie.personnelsPropriete = personnels;*/
                //msdr.Close();

                return categorie;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


    }
}
