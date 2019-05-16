using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Categorie
    {
        public int id;
        private String nomUnique;
        private List<CalculCategorie> coefficientCategorie;
        private List<Personnel> personnels;

        internal List<CalculCategorie> CoefficientCategoriePropriete
        {
            get { return coefficientCategorie; }
            set { coefficientCategorie = value; }
        }

        internal List<Personnel> personnelsPropriete
        {
            get { return personnels; }
            set { personnels = value; }
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
