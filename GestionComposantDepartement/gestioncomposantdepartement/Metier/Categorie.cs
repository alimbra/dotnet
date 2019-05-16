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
        //private List<CategorieCoefficient> categorieCoefficient;
        private List<Personnel> personnels;
        private List<Coefficient> coefficients;

        /*internal List<CategorieCoefficient> categorieCoefficientPropriete
        {
            get { return categorieCoefficient; }
            set { categorieCoefficient = value; }
        }*/

        /*public void ajouterCategorieCoefficient(CategorieCoefficient cc)
        {
            categorieCoefficient.Add(cc);
        }*/

        internal List<Coefficient> coefficientsPropriete
        {
            get { return coefficients; }
            set { coefficients = value; }
        }

        public void addCoefficient (Coefficient coef){
            if( !this.coefficients.Contains(coef) ) this.coefficients.Add(coef);
            else
            {
                int index = this.coefficients.FindIndex(0, this.coefficients.Count, c => c.typeCours == coef.typeCours);
                this.coefficients.Insert(index, coef);
            }
        }

        public Coefficient getCoefTypeCours(TypeCours tc)
        {
            try { return this.coefficients.Find(c => c.typeCours.id == tc.id); }
            catch (ArgumentNullException e) { Console.WriteLine(e.Message); return null; }
            
        }

        internal List<Personnel> personnelsPropriete
        {
            get { return personnels; }
            set { personnels = value; }
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
