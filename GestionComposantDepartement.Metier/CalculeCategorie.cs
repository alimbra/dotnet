using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class CalculCategorie
    {
        private String nomCalcul;

        public String NomCalculPropriete
        {
            get { return nomCalcul; }
            set { nomCalcul = value; }
        }
        private double coefficient;

        public double CoefficientPropriete
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

    }

}
