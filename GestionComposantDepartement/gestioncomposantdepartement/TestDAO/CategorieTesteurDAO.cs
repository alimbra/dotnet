using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    class CategorieTesteurDAO:TesteurDAO
    {

        public CategorieTesteurDAO() : base(){ }

        override
        public void tester()
        {
            Console.WriteLine("Test Categorie DAO");
            CategorieDAO categorieDAO = (CategorieDAO)daoFactory.getCategorieDAO();
            if (categorieDAO.findAll().Count <= 0){ Categorie categorie = testCreer(categorieDAO);}
            Categorie categorie1 = testFind(1, categorieDAO);
            List<Categorie> categorieEnsChercheur = testFindBy(categorieDAO); 
            this.testFindAll(categorieDAO);
        }

        public void testFindAll(CategorieDAO categorieDAO)
        {
            Console.WriteLine("*** FindAll Categorie ***");
            foreach (Categorie p in categorieDAO.findAll())
            {
                Console.WriteLine(p.id + " | " + p.NomUniquePropriete);
            }
        }

        public Categorie testCreer(CategorieDAO categorieDAO)
        {
            Categorie categorie = new Categorie();
            categorie.NomUniquePropriete = "Enseignant Chercheur";
            categorie.NbHeuresPropriete = 200; 
            categorieDAO.create(categorie);
            Console.WriteLine("Catégorie créée avec succès"); 
            return categorie;
        }

        public Categorie testFind(int id,CategorieDAO categorieDAO)
        {
            Categorie categorie = categorieDAO.find(id);
            Console.WriteLine(categorie.id + " | " + categorie.NomUniquePropriete + " | " + categorie.NbHeuresPropriete);
            Console.WriteLine("Personnels de cette catégrorie");
            foreach(Personnel p in categorie.personnelsPropriete){
                Console.WriteLine(p.id+" | "+p.PrenomPropriete+" | "+p.NomPropriete);
            }
            Console.WriteLine("Coefficients de cette catégrorie");
            foreach (Coefficient coef in categorie.coefficientsPropriete)
            {
                Console.WriteLine(coef.id + " | " + coef.coefficient);
            }
            return categorie; 
        }

        public List<Categorie> testFindBy(CategorieDAO categorieDAO)
        {
            Dictionary<string, string> contraintes = new Dictionary<string, string>();
            contraintes.Add("nom", "Enseignant Chercheur");
            List<Categorie> lc = categorieDAO.findBy(contraintes);
            foreach(Categorie c in lc){Console.WriteLine("Test FindBy Catégorie : " + c.id + " | " + c.NomUniquePropriete);}
            return lc;
        }

    }
}
