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
    public class EcDAO:DAO
    {

        public const int ID_EC = 0;
        public const int NOM_EC = 1;
        public const int ID_UE = 3;
        public const int NOM_UE = 4;
        public const int ID_COURS = 0; 
        public const int GROUPE_COURS = 1;
        public const int NB_HEURE_TOTAL_COURS = 2;

        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.EC  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    nom VARCHAR(255) NOT NULL ,
                    ue_id int DEFAULT NULL, 
                    PRIMARY KEY (id), 
                    FOREIGN KEY (ue_id) REFERENCES projetgestiondepartement.UE (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() { }

        public void create(Ec ec)
        {
            try
            {
                //création de la table EC
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear(); 
                commande.CommandText = @"INSERT INTO projetgestiondepartement.EC (nom, ue_id)  VALUES  (@nom, @ue_id);";
                commande.Parameters.AddWithValue("@nom", ec.NomPropriete);
                Ue ue = ec.UePropriete; 
                commande.Parameters.AddWithValue("@ue_id", ue.id);
                commande.ExecuteNonQuery();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public Ec find(int id)
        {
            try
            {
                //Recup ec 
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.EC 
                                        JOIN projetgestiondepartement.UE ON projetgestiondepartement.EC.ue_id = projetgestiondepartement.UE.id     
                                        WHERE projetgestiondepartement.EC.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                Ue ue = objetUe(msdr);
                Ec ec = objetEc(ue, msdr);
                msdr.Close();
                 
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.EC     
                                        WHERE projetgestiondepartement.EC.ue_id = " + ue.id;
                msdr = commande.ExecuteReader();
                List<Ec> ecs = new List<Ec>();
                while(msdr.Read()){
                    ecs.Add(objetEc(ue,msdr));
                }
                ue.EcsPropriete = ecs;
                msdr.Close();

                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Cours     
                                        WHERE projetgestiondepartement.Cours.ec_id = " + id;
                msdr = commande.ExecuteReader();
                List<Cours> lesCours = new List<Cours>();
                while (msdr.Read())
                {
                    lesCours.Add(objetCours(ec, msdr));    
                }
                ec.ListeCoursPropriete = lesCours;
                msdr.Close();

                return ec;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public List<Ec> findAll()
        {
            commande.CommandText = @"SELECT * FROM projetgestiondepartement.Ec ";
            MySqlDataReader msdr = commande.ExecuteReader();
            List<Ec> ecs = new List<Ec>(msdr.FieldCount);
            while (msdr.Read()) { ecs.Add(objetEcSimple(msdr)); }
            msdr.Close();
            return ecs;
        }

        public List<Ec> findBy(Dictionary<string, string> contraintes)
        {
            try
            {
                int i = 0;
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"SELECT * FROM projetgestiondepartement.Ec ");
                foreach (KeyValuePair<string, string> c in contraintes)
                {
                    if (i == 0) sb.Append("  WHERE projetgestiondepartement.Ec." + c.Key + " ='" + c.Value + "'");
                    sb.Append("  AND projetgestiondepartement.Ec." + c.Key + " = '" + c.Value + "'");
                    i++;
                }

                string query = sb.ToString();
                commande.CommandText = query;
                MySqlDataReader msdr = commande.ExecuteReader();
                List<Ec> lc = new List<Ec>();
                while (msdr.Read())
                {
                    lc.Add(this.objetEcSimple(msdr));
                }
                msdr.Close();

                return lc;
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public Ec objetEcSimple(MySqlDataReader msdr)
        {
            Ec ec = new Ec();
            ec.id = msdr.GetInt32(ID_EC);
            ec.NomPropriete = msdr.GetString(NOM_EC);
            return ec;
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
            int ue_id = msdr.GetInt32(ID_UE);
            String ue_nom = msdr.GetString(NOM_UE);
            Ue ue = new Ue();
            ue.id = ue_id;
            ue.NomPropriete = ue_nom; 
            return ue;
        }

        public Cours objetCours(Ec ec, MySqlDataReader msdr)
        {
            int cours_id = msdr.GetInt32(ID_COURS);
            string groupe = msdr.GetString(GROUPE_COURS);
            int heureTotal = msdr.GetInt32(NB_HEURE_TOTAL_COURS);
            Cours cours = new Cours();
            cours.id = cours_id;
            cours.GroupePropriete = groupe;
            cours.NbHeureTotalPropriete = heureTotal; 
            cours.EcPropriete = ec; 
            return cours;
        }
    }
}
