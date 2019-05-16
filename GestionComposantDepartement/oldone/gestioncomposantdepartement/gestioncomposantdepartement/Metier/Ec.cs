using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Ec
    {
        public int id;

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
