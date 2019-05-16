using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Diplome
    {
        private List<Annee> annees;

        public List<Annee> AnneesPropriete
        {
            get { return annees; }
            set { annees = value; }
        }
    }
}
