using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Ec
    {
        private Ue ue;

        internal Ue UePropriete
        {
            get { return ue; }
            set { ue = value; }
        }
        private String nom;

        public String NomPropriete
        {
            get { return nom; }
            set { nom = value; }
        }
        private List<Cours> listeCours;

        internal List<Cours> ListeCoursPropriete
        {
            get { return listeCours; }
            set { listeCours = value; }
        }
    }
}
