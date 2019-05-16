using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Personnel
    {
        public int id;
        private String nom;
        private List<Cours> cours;  

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
        /*
        private List<HeurePresentielle> heuresPresentielles;

        internal List<HeurePresentielle> HeuresPresentiellesPropriete
        {
            get { return heuresPresentielles; }
            set { heuresPresentielles = value; }
        }
        */

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

        internal List<Cours> CoursPropriete
        {
            get { return cours; }
            set { cours = value; }
        }
    }
}
