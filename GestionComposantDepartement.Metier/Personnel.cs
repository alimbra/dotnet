using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Personnel
    {
        private String nom;

        public String NomPropriete
        {
            get { return nom; }
            set { nom = value; }
        }
        private String prenom;

        public String PrenomPropriete
        {
            get { return prenom; }
            set { prenom = value; }
        }
        private List<HeurePresentielle> heuresPresentielles;

        internal List<HeurePresentielle> HeuresPresentiellesPropriete
        {
            get { return heuresPresentielles; }
            set { heuresPresentielles = value; }
        }
        private Departement departement;

        internal Departement DepartementPropriete
        {
            get { return departement; }
            set { departement = value; }
        }
        private Categorie categorie;

        internal Categorie CategoriePropriete
        {
            get { return categorie; }
            set { categorie = value; }
        }
    }
}
