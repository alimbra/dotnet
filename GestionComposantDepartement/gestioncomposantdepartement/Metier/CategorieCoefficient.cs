using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class CategorieCoefficient
    {
        private String nomTypeCours;

        public String nomTypeCoursPropriete
        {
            get { return nomTypeCours; }
            set { nomTypeCours = value; }
        }

        private Coefficient coefficient;

        public Coefficient coefficientPropriete
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        private Categorie categorie;

        public Categorie categorieProprite
        {
            get { return categorie; }
            set { categorie = value; }
        }
    }
}
