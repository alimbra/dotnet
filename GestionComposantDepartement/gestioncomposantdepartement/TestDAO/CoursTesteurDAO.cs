using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    class CoursTesteurDAO:TesteurDAO
    {
        public CoursTesteurDAO() : base()
        {

        }

        override
        public void tester()
        {
            Console.WriteLine("Test Cours DAO ");
            CoursDAO coursDAO = (CoursDAO)daoFactory.getCoursDAO();
            Cours cours = testCreer(coursDAO);
            Cours cours1 = testFind(1, coursDAO);
            List<Cours> coursGr40 = testFindBy(coursDAO);
            this.testFindAll(coursDAO);
        }

        public Cours testCreer(CoursDAO coursDAO)
        {
            Cours cours = new Cours();
            cours.GroupePropriete = "Groupe 1";
            cours.NbHeureTotalPropriete = 30;
            EcDAO ecDAO = (EcDAO)daoFactory.getEcDAO();
            cours.EcPropriete = ecDAO.find(1);
            TypeCoursDAO typeCoursDAO = (TypeCoursDAO)daoFactory.getTypeCoursDAO();
            cours.TypeCoursPropriete = typeCoursDAO.find(1);
            PersonnelDAO personnelDAO = (PersonnelDAO)daoFactory.getPersonnelDAO();
            cours.PersonnelPropriete = personnelDAO.find(1);
            coursDAO.create(cours);
            Console.WriteLine("Cours crée avec succès"); 
            return cours;
        }

        public Cours testFind(int id_cours,CoursDAO coursDAO)
        {
            Cours cours = coursDAO.find(id_cours);
            Console.WriteLine(cours.id+" | "+cours.GroupePropriete+" | "+cours.NbHeureTotalPropriete);
            Console.WriteLine("Personnel de ce cours");
            Console.WriteLine(cours.PersonnelPropriete.id + " | " + cours.PersonnelPropriete.PrenomPropriete+" | "+cours.PersonnelPropriete.NomPropriete);
            Console.WriteLine("Type de ce cours");
            Console.WriteLine(cours.TypeCoursPropriete.id + " | " + cours.TypeCoursPropriete.NomUniquePropriete);
            Console.WriteLine("Ec de ce cours");
            Console.WriteLine(cours.EcPropriete.id + " | "+cours.EcPropriete.NomPropriete);
 
            return cours; 
        }


        public List<Cours> testFindBy(CoursDAO coursDAO)
        {
            Dictionary<string, string> contraintes = new Dictionary<string, string>();
            contraintes.Add("groupe", "Groupe 40");
            List<Cours> lc = coursDAO.findBy(contraintes);
            
            foreach (Cours c in lc){Console.WriteLine("Test FindBy Cours : " + c.id + " | " + c.GroupePropriete);}
            return lc;
        }

        public void testFindAll(CoursDAO coursDAO)
        {
            Console.WriteLine("*** FindAll Cours ***");
            foreach (Cours p in coursDAO.findAll())
            {
                Console.WriteLine(p.id + " | " + p.GroupePropriete);
            }
        }
    }
}
