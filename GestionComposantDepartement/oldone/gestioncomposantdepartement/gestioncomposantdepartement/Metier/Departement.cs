using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Departement
    {
        public int id;
        private String nom;
        private Personnel directeur;

        public Personnel directeurPropriete
        {
            get { return directeur;  }
            set { directeur = value; }
        }

        public String NomPropriete
        {
            get { return nom; }
            set { nom = value; }
        }
        private List<Personnel> listePersonnel;

        internal List<Personnel> ListePersonnelPropriete
        {
            get { return listePersonnel; }
            set { listePersonnel = value; }
        }
    }
}
