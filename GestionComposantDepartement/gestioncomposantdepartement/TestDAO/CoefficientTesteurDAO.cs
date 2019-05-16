using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    class CoefficientTesteurDAO:TesteurDAO
    {
        public CoefficientTesteurDAO() : base(){ }

        override
        public void tester()
        {
            Console.WriteLine("Test Coefficient DAO");
            CoefficientDAO coefficientDAO = (CoefficientDAO)daoFactory.getCoefficientDAO();
            Coefficient coefficient = testCreer(coefficientDAO);
            Coefficient coefficient1 = testFind(1, coefficientDAO);
            List<Coefficient> coefficients = testFindBy(coefficientDAO);
            this.testFindAll(coefficientDAO);
        }

        public void testFindAll(CoefficientDAO coefficientDAO)
        {
            Console.WriteLine("*** FindAll Coefficient ***");
            foreach (Coefficient p in coefficientDAO.findAll())
            {
                Console.WriteLine(p.id + " | " + p.coefficient);
            }
        }

        public Coefficient testCreer(CoefficientDAO coefficientDAO)
        {
            Console.WriteLine("*** Creer Coefficient ***");
            Coefficient coefficient = new Coefficient();
            coefficient.coefficient = 1.5;
            CategorieDAO catDAO = (CategorieDAO)daoFactory.getCategorieDAO();
            TypeCoursDAO tcDAO = (TypeCoursDAO)daoFactory.getTypeCoursDAO();
            Categorie c = catDAO.find(1);
            TypeCours tc = tcDAO.find(1);
            coefficient.categorie = c;
            coefficient.typeCours = tc;

            coefficientDAO.create(coefficient);
            return coefficient;
        }

        public Coefficient testFind(int id, CoefficientDAO coefficientDAO)
        {
            Console.WriteLine("Find coefficient");
            Coefficient coefficient = coefficientDAO.find(id);
            Console.WriteLine(coefficient.id + " | " + coefficient.coefficient + " | nomTypeCours : " + coefficient.typeCours.id);
            return coefficient; 
        }

        public List<Coefficient> testFindBy(CoefficientDAO coefficientDAO)
        {
            Dictionary<string, string> contraintes = new Dictionary<string, string>();
            contraintes.Add("coefficient", "1.5");
            contraintes.Add("id", "1");
            List<Coefficient> lc = coefficientDAO.findBy(contraintes);
            foreach(Coefficient c in lc){Console.WriteLine("Test FindBy Coefficient : " + c.id + " | " + c.coefficient);}
            return lc;
        }
    }
}
