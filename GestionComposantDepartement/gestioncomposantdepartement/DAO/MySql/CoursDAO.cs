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

    public class CoursDAO : DAO
    {

        public const int ID_COURS = 0;
        public const int GROUPE_COURS = 1;
        public const int NB_HEURE_TOTAL_COURS = 2;
        public const int HEURES_COURS = 3;
        //public const int PERSONNEL_COURS = 6;

        public const int ID_EC = 7;
        public const int NOM_EC = 8;

        public const int ID_TYPE_COURS = 10;
        public const int NOM_TYPE_COURS = 11;

        public const int ID_PERSONNEL = 12;
        public const int PRENOM_PERSONNEL = 13;
        public const int NOM_PERSONNEL = 14;

        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.Cours  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    groupe VARCHAR(255) NOT NULL ,
                    nb_heure_total int DEFAULT 0,
                    heures double DEFAULT 0, 
                    ec_id int NOT NULL, 
                    type_id int NOT NULL, 
                    personnel_id int DEFAULT NULL,
                    PRIMARY KEY (id), 
                    FOREIGN KEY (ec_id) REFERENCES projetgestiondepartement.EC (id),
                    FOREIGN KEY (type_id) REFERENCES projetgestiondepartement.TypeCours (id),
                    FOREIGN KEY (personnel_id) REFERENCES projetgestiondepartement.Personnel (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }

        public void create(Cours cours)
        {
            try
            {
                //création de la table Cours
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.Cours (groupe, nb_heure_total, heures, ec_id, type_id, personnel_id)  VALUES  (@groupe,@nb_heure_total,@heures,@ec_id, @type_id, @personnel_id);";
                commande.Parameters.AddWithValue("@groupe", cours.GroupePropriete);
                commande.Parameters.AddWithValue("@nb_heure_total", cours.NbHeureTotalPropriete);
                commande.Parameters.AddWithValue("@heures", cours.heuresPropriete);
                commande.Parameters.AddWithValue("@ec_id", cours.EcPropriete.id);
                commande.Parameters.AddWithValue("@type_id", cours.TypeCoursPropriete.id);
                commande.Parameters.AddWithValue("@personnel_id", cours.PersonnelPropriete.id);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex){ Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public Cours find(int id)
        {
            try
            {
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Cours 
                                        JOIN projetgestiondepartement.EC ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.EC.id  
                                        JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Cours.type_id = projetgestiondepartement.TypeCours.id
                                        JOIN projetgestiondepartement.Personnel ON projetgestiondepartement.Cours.personnel_id = projetgestiondepartement.Personnel.id   
                                        JOIN projetgestiondepartement.Ec ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.Ec.id   
  
                                        WHERE projetgestiondepartement.Cours.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Ec ec = objetEc(msdr);
                TypeCours typeCours = objetTypeCours(msdr);
                Personnel personnel = objetPersonnel(msdr);
                Cours cours = objetCours(ec, typeCours, personnel, msdr);
                msdr.Close(); 

                return cours;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Cours findByNull(int id)
        {
            try
            {
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Cours 
                                        JOIN projetgestiondepartement.EC ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.EC.id  
                                        JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Cours.type_id = projetgestiondepartement.TypeCours.id
                                        
                                        WHERE projetgestiondepartement.Cours.personnel_id is NULL and projetgestiondepartement.Cours.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Ec ec = objetEc(msdr);
                TypeCours typeCours = objetTypeCours(msdr);
                Personnel personnel = null;
                Cours cours = objetCours(ec, typeCours, personnel, msdr);
                msdr.Close();

                return cours;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Cours> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Cours ";
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Cours> cours = new List<Cours>(msdr.FieldCount);
            while (msdr.Read()) { cours.Add(objetCoursSimple(msdr)); }
            msdr.Close();
            return cours;
        }


        public List<Cours> findNonAffecte()
        {
            try
            {
                int i = 0;
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"SELECT * FROM projetgestiondepartement.Cours 
                    JOIN projetgestiondepartement.EC ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.Ec.id  
                    JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Cours.type_id = projetgestiondepartement.TypeCours.id
                    WHERE projetgestiondepartement.Cours.personnel_id is NULL");
                 

                string query = sb.ToString();
                commande.CommandText = query;
                MySqlDataReader msdr = commande.ExecuteReader();

                List<Cours> lc = new List<Cours>();
                while (msdr.Read())
                {
                    Ec ec = objetEc(msdr);
                    TypeCours typeCours = objetTypeCours(msdr);
                    Personnel personnel = null;
                    Cours cours = objetCours(ec, typeCours, personnel, msdr);

                    lc.Add(cours);
                }
                msdr.Close();

                return lc;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public List<Cours> findBy(Dictionary<string, string> contraintes)
        {
            try
            {
                int i = 0;
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"SELECT * FROM projetgestiondepartement.Cours 
                    JOIN projetgestiondepartement.EC ON projetgestiondepartement.Cours.ec_id = projetgestiondepartement.Ec.id  
                    JOIN projetgestiondepartement.TypeCours ON projetgestiondepartement.Cours.type_id = projetgestiondepartement.TypeCours.id
                    JOIN projetgestiondepartement.Personnel ON projetgestiondepartement.Cours.personnel_id = projetgestiondepartement.Personnel.id   
                    ");
                foreach (KeyValuePair<string, string> c in contraintes)
                {
                    if (i == 0) sb.Append("  WHERE projetgestiondepartement.Cours." + c.Key + " ='" + c.Value + "'");
                    sb.Append("  AND projetgestiondepartement.Cours." + c.Key + " = '" + c.Value + "'");
                    i++;
                }

                string query = sb.ToString();
                commande.CommandText = query;
                MySqlDataReader msdr = commande.ExecuteReader();

                List<Cours> lc = new List<Cours>();
                while (msdr.Read())
                {
                    Ec ec = objetEc(msdr);
                    TypeCours typeCours = objetTypeCours(msdr);
                    Personnel personnel = objetPersonnel(msdr);
                    Cours cours = objetCours(ec, typeCours, personnel, msdr);

                    lc.Add(cours);
                }
                msdr.Close();

                return lc;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Cours objetCoursSimple(MySqlDataReader msdr)
        {
            Cours cours = new Cours();
            cours.id = msdr.GetInt32(ID_COURS);
            cours.GroupePropriete = msdr.GetString(GROUPE_COURS);
            cours.NbHeureTotalPropriete = msdr.GetInt32(NB_HEURE_TOTAL_COURS);
            cours.heuresPropriete = msdr.GetDouble(HEURES_COURS);
            return cours;
        }

        public Cours objetCours(Ec ec, TypeCours typeCours, Personnel personnel, MySqlDataReader msdr)
        {
            Cours cours = new Cours();
            cours.id = msdr.GetInt32(ID_COURS);
            cours.GroupePropriete = msdr.GetString(GROUPE_COURS);
            cours.NbHeureTotalPropriete = msdr.GetInt32(NB_HEURE_TOTAL_COURS);
            cours.heuresPropriete = msdr.GetDouble(HEURES_COURS); 
            cours.EcPropriete = ec;
            cours.TypeCoursPropriete = typeCours; 
            cours.PersonnelPropriete = personnel; 
            return cours;
        }

        public Ec objetEc(MySqlDataReader msdr)
        {
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

        public Personnel objetPersonnel(MySqlDataReader msdr){
            Personnel personnel = new Personnel();
            personnel.id = msdr.GetInt32(ID_PERSONNEL);
            personnel.PrenomPropriete = msdr.GetString(PRENOM_PERSONNEL);
            personnel.NomPropriete = msdr.GetString(NOM_PERSONNEL);
            return personnel;
        }
        public void update(Cours cours)
        {
            try
            {
                //création de la table Cours
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"UPDATE projetgestiondepartement.Cours
                    SET groupe=@groupe,
                        nb_heure_total = @nb_heure_total,
                        heures = @heures,
                        ec_id = @ec_id ,
                        type_id = @type_id,
                        personnel_id = @personnel_id
                    where id=@id;";
                commande.Parameters.AddWithValue("@groupe", cours.GroupePropriete);
                commande.Parameters.AddWithValue("@nb_heure_total", cours.NbHeureTotalPropriete);
                commande.Parameters.AddWithValue("@heures", cours.heuresPropriete);
                commande.Parameters.AddWithValue("@ec_id", cours.EcPropriete.id);
                commande.Parameters.AddWithValue("@type_id", cours.TypeCoursPropriete.id);
                commande.Parameters.AddWithValue("@personnel_id", cours.PersonnelPropriete.id);
                commande.Parameters.AddWithValue("@id", cours.id);

                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

    }
}

