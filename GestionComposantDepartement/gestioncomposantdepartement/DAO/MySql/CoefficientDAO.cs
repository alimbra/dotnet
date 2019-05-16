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
    class CoefficientDAO:DAO
    {
        private const int ID_COEFFICIENT = 0;
        private const int COEFFICIENT_COEFFICIENT = 1;

        private const int ID_TYPE_COURS = 4;
        private const int NOM_TYPE_COURS = 5; 
        override
       public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Coefficient  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    coefficient double NOT NULL,
                    categorie_id int NOT NULL,
                    typeCours_id int NOT NULL,
                    PRIMARY KEY (id), 
                    FOREIGN KEY (categorie_id) REFERENCES projetgestiondepartement.Categorie (id), 
                    FOREIGN KEY (typeCours_id) REFERENCES projetgestiondepartement.TypeCours (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }


        public void create(Coefficient coefficient)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Coefficient (coefficient, categorie_id, typeCours_id)  VALUES  (@coefficient, @categorie_id, @typeCours_id);";
                commande.Parameters.AddWithValue("@coefficient", coefficient.coefficient);
                commande.Parameters.AddWithValue("@categorie_id", coefficient.categorie.id);
                commande.Parameters.AddWithValue("@typeCours_id", coefficient.typeCours.id);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); /*throw ex;*/ }
        }


        public Coefficient find(int id)
        {
            try
            {
                //Recup coeff
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Coefficient
                                        JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Coefficient.typeCours_id = projetgestiondepartement.TypeCours.id     
                                        WHERE projetgestiondepartement.Coefficient.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Coefficient coefficient = this.objetCoefficientAux(msdr);
                msdr.Close();

                return coefficient;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Coefficient> findBy(Dictionary<string, string> contraintes)
        {
            try
            {
                int i = 0;
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"SELECT * FROM projetgestiondepartement.Coefficient ");
                foreach (KeyValuePair<string, string> c in contraintes)
                {
                    if (i == 0) sb.Append("  WHERE projetgestiondepartement.Coefficient." + c.Key + " ='" + c.Value + "'");
                    sb.Append("  AND projetgestiondepartement.Coefficient." + c.Key + " = '" + c.Value + "'");
                    i++;
                }

                string query = sb.ToString();
                //Console.WriteLine(query);
                commande.CommandText = query;
                MySqlDataReader msdr = commande.ExecuteReader();
                List<Coefficient> lc = new List<Coefficient>(msdr.FieldCount);
                while (msdr.Read())
                {
                    lc.Add(this.objetCoefficient(msdr));
                }
                msdr.Close();

                return lc;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Coefficient> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Coefficient ";
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Coefficient> coefficients = new List<Coefficient>(msdr.FieldCount);
            while (msdr.Read()) { coefficients.Add(objetCoefficient(msdr)); }
            msdr.Close();
            return coefficients;
        }

        public Coefficient objetCoefficient(MySqlDataReader msdr){
            Coefficient coefficient = new Coefficient();
            coefficient.id = msdr.GetInt32(ID_COEFFICIENT);
            coefficient.coefficient = msdr.GetDouble(COEFFICIENT_COEFFICIENT);
            return coefficient;
        }

        public Coefficient objetCoefficientAux(MySqlDataReader msdr)
        {
            Coefficient coefficient = this.objetCoefficient(msdr); 
            TypeCours tc = new TypeCours();
            tc.id = msdr.GetInt32(ID_TYPE_COURS);
            tc.NomUniquePropriete = msdr.GetString(NOM_TYPE_COURS);
            coefficient.typeCours = tc;
            return coefficient;
        }
    }
}
