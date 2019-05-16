using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Categorie
    {
        private String nomUnique;
        private List<CalculCategorie> coefficientCategorie;

        internal List<CalculCategorie> CoefficientCategoriePropriete
        {
            get { return coefficientCategorie; }
            set { coefficientCategorie = value; }
        }
        public void ajouterCoefficient(CalculCategorie cc)
        {
            coefficientCategorie.Add(cc);
        }
        public String NomUniquePropriete
        {
            get { return nomUnique; }
            set { nomUnique = value; }
        }
        private double nbHeures;

        public double NbHeuresPropriete
        {
            get { return nbHeures; }
            set { nbHeures = value; }
        }
        
    }
}
