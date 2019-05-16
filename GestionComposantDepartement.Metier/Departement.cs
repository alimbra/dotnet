using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Departement
    {
        private String nom;

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
