using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class TypeCours
    {
        private String nomUnique;

        public String NomUniquePropriete
        {
            get { return nomUnique; }
            set { nomUnique = value; }
        }
        private List<Cours> listeCours;

        internal List<Cours> ListeCoursPropriete
        {
            get { return listeCours; }
            set { listeCours = value; }
        }
    }
}
