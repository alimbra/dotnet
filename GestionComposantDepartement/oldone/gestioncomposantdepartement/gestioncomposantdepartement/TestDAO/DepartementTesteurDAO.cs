using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    public class DepartementTesteurDAO:TesteurDAO
    {
        public DepartementTesteurDAO() : base()
        {

        }

        override
        public void tester()
        {
            Console.WriteLine("\n****Test Département DAO****");
            DepartementDAO departementDAO = (DepartementDAO)daoFactory.getDepartementDAO();
            Departement departement = testCreer(departementDAO);
            Departement departement1 = testFind(1, departementDAO);
        }

        public Departement testCreer(DepartementDAO departementDAO)
        {
            Departement departement = new Departement();
            departement.NomPropriete = "Informatique";

            PersonnelDAO personnelDAO = (PersonnelDAO)daoFactory.getPersonnelDAO();
            Personnel directeur = personnelDAO.find(1);

            departement.directeurPropriete = directeur;
            departementDAO.create(departement);
            Console.WriteLine("Département crée avec succès"); 
            return departement;
        }

        public Departement testFind(int id, DepartementDAO departementDAO)
        {
            Departement departement = departementDAO.find(1);
            Console.WriteLine(departement.id+" | "+departement.NomPropriete); 
            Console.WriteLine("Le directeur du département");
            Console.WriteLine(departement.directeurPropriete.id +" | "+departement.directeurPropriete.PrenomPropriete+" | "+departement.directeurPropriete.NomPropriete);
            Console.WriteLine("La liste personnel"); 
            foreach(Personnel p in departement.ListePersonnelPropriete){
                Console.WriteLine(p.id+" | "+p.PrenomPropriete+" | "+p.NomPropriete); 
            }
            return departement;
        }
    }
}
