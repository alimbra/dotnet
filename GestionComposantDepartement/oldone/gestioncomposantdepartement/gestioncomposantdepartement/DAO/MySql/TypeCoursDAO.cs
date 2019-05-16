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
    class TypeCoursDAO:DAO
    {
        public const int ID_TYPE_COURS = 0;
        public const int NOM_TYPE_COURS = 1;

        public const int ID_COURS = 0;
        public const int GROUPE_COURS = 1;
        public const int NB_HEURE_T_COURS = 2;
        
        override
        public void createTable()
        {
            commande.CommandText = @"CREATE TABLE IF NOT EXISTS projetgestiondepartement.TypeCours  (  
                    id int NOT NULL AUTO_INCREMENT, 
                    nom VARCHAR(255) NOT NULL UNIQUE,
                    PRIMARY KEY (id)
                )";
            commande.ExecuteNonQuery();
        }

        override
        public void creerTuplesParDefaut() 
        {
            String[] t = { "CM", "TD", "TP" };
            bool b = false;
            try
            {
                commande.CommandText = @"SELECT COUNT(*) FROM projetgestiondepartement.TypeCours    
                                        WHERE projetgestiondepartement.TypeCours.nom = 'CM' OR  projetgestiondepartement.TypeCours.nom = 'TD' 
                                        OR projetgestiondepartement.TypeCours.nom = 'TP'";
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                b = msdr.GetInt32(0) <= 0;
                msdr.Close();
            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }

            if (b)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    TypeCours tc = new TypeCours();
                    tc.NomUniquePropriete = t[i];
                    this.create(tc);
                }
            }
        }

        public void create(TypeCours typeCours)
        {
            try
            {
                createTable();
                //Insertion d'une occurrence
                commande.Parameters.Clear();
                commande.CommandText = @"INSERT INTO projetgestiondepartement.TypeCours (nom)  VALUES  (@nom);";
                commande.Parameters.AddWithValue("@nom", typeCours.NomUniquePropriete);
                commande.ExecuteNonQuery();
            }catch (MySqlException ex){ Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }

        public TypeCours find(int id)
        {
            try
            {
                commande.CommandText = @"SELECT * FROM projetgestiondepartement.TypeCours   
                                        WHERE projetgestiondepartement.TypeCours.id = " + id;
                MySqlDataReader msdr = commande.ExecuteReader();
                msdr.Read();
                TypeCours typeCours = objetTypeCours(msdr);
                msdr.Close();

                commande.CommandText = @"SELECT * FROM projetgestiondepartement.Cours   
                                        WHERE projetgestiondepartement.Cours.type_id = " + id;
                msdr = commande.ExecuteReader();
                    List<Cours> listeCours = new List<Cours>();
                    while (msdr.Read()) { listeCours.Add(objetCours(typeCours , msdr)); }
                msdr.Close();
                typeCours.ListeCoursPropriete = listeCours; 

                return typeCours;
            }catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw ex; }
        }


        public TypeCours objetTypeCours(MySqlDataReader msdr){
            TypeCours typeCours = new TypeCours();
            typeCours.id = msdr.GetInt32(ID_TYPE_COURS);
            typeCours.NomUniquePropriete = msdr.GetString(NOM_TYPE_COURS); 
            return typeCours; 
        }

        public Cours objetCours(TypeCours typeCours,MySqlDataReader msdr)
        {
            //possibilite de recupérer l'ec

            Cours cours = new Cours();
            cours.id = msdr.GetInt32(ID_COURS);
            cours.GroupePropriete = msdr.GetString(GROUPE_COURS);
            cours.NbHeureTotalPropriete = msdr.GetInt32(NB_HEURE_T_COURS);
            cours.TypeCoursPropriete = typeCours;
            return cours;
        }

    }
}
