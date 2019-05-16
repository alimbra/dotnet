using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    class PersonnelTesteurDAO:TesteurDAO
    {
        public PersonnelTesteurDAO() : base()
        {

        }

        override
        public void tester()
        {
            Console.WriteLine("Test Personnel DAO ");
            PersonnelDAO personnelDAO = (PersonnelDAO)daoFactory.getPersonnelDAO();
            Personnel personnel = testCreer(personnelDAO);
            Personnel p = testFind(1, personnelDAO);
            testFindAll(personnelDAO);
            List<Personnel> ps = testFindBy(personnelDAO); 
        }

        public Personnel testCreer(PersonnelDAO personnelDAO)
        {
            Personnel personnel = new Personnel();
            personnel.PrenomPropriete = "Ed.";
            personnel.NomPropriete = "NIGMA";
            CategorieDAO categorieDAO = (CategorieDAO)daoFactory.getCategorieDAO();
            Categorie categorie = categorieDAO.find(1);
            personnel.CategoriePropriete = categorie;
            personnelDAO.create(personnel);
            Console.WriteLine("Personnel crée avec succès");
            return personnel;
        }

        public Personnel testFind(int id, PersonnelDAO personnelDAO)
        {
            Personnel personnel = personnelDAO.find(id);
            Console.WriteLine(personnel.id + " | " + personnel.PrenomPropriete + " | " + personnel.NomPropriete);
            //Console.WriteLine("Le département de ce personnel");
            //Console.WriteLine(personnel.DepartementPropriete.id+" | "+personnel.DepartementPropriete.NomPropriete); 
            Console.WriteLine("La catégorie de ce personnel");
            Console.WriteLine(personnel.CategoriePropriete.id+" | "+personnel.CategoriePropriete.NomUniquePropriete+" | "+personnel.CategoriePropriete.NbHeuresPropriete); 
            /*Console.WriteLine("Les cours de ce personnel");
            foreach (Cours c in personnel.CoursPropriete)
            {
                Console.WriteLine(c.id + " | " + c.GroupePropriete + " | " + c.NbHeureTotalPropriete + " | "+c.heuresPropriete);
            }*/

            return personnel;
        }

        public void testFindAll(PersonnelDAO personnelDAO)
        {
            Console.WriteLine("*** FindAll Personnel ***");
            foreach(Personnel p in personnelDAO.findAll()){
                Console.WriteLine(p.id+" | "+p.PrenomPropriete+" | "+p.NomPropriete+" | "+p.CategoriePropriete.NomUniquePropriete); 
            }
        }

        public List<Personnel> testFindBy(PersonnelDAO personnelDAO)
        {
            Dictionary<string, string> contraintes = new Dictionary<string, string>();
            contraintes.Add("prenom", "Ed.hgsjdfh");
            List<Personnel> lc = personnelDAO.findBy(contraintes);

            foreach (Personnel c in lc) { Console.WriteLine("Test FindBy Personnel : " + c.id + " | " + c.PrenomPropriete); }
            return lc;
        }
    }
}
