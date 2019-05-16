using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    class Diplome
    {
        public int id;
        public string intitule;
        private List<Annee> annees;

        public List<Annee> AnneesPropriete
        {
            get { return annees; }
            set { annees = value; }
        }
    }
}
