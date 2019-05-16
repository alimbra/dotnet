using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    public class EcTesteurDAO : TesteurDAO
    {
        public EcTesteurDAO() : base()
        {

        }

        override
        public void tester()
        {
            Console.WriteLine("Test EC DAO ");
            EcDAO ecDAO = (EcDAO)daoFactory.getEcDAO();
            UeDAO ueDAO = (UeDAO)daoFactory.getUeDAO();
            Ec ec = this.testCreer(ecDAO, ueDAO);
            Ec ec1 = testFind(1, ecDAO);
            this.testUE_de_EC(ec1);
            this.testListerTousLesEcsDe_UE(ec1);
            this.testCours_Ec(ec1);
            List<Ec> ecs = this.testFindBy(ecDAO); 
            this.testFindAll(ecDAO);
        }

        public Ec testCreer(EcDAO ecDAO, UeDAO ueDAO)
        {
            Ec ec = new Ec();
            ec.NomPropriete = "Amérique";
            Ue ue1 = ueDAO.find(1);
            ec.UePropriete = ue1;
            ecDAO.create(ec);
            return ec; 
        }

        public Ec testFind(int id, EcDAO ecDAO)
        {
            Ec ec = ecDAO.find(id);
            Console.Write(ec.id + " | " + ec.NomPropriete + " | ");
            return ec; 
        }

        public void testUE_de_EC(Ec ec)
        {
            Console.WriteLine("UE correspondante : ");
            Console.WriteLine(ec.UePropriete.id + " | " + ec.UePropriete.NomPropriete);
        }

        public void testListerTousLesEcsDe_UE(Ec ec)
        {
            Console.WriteLine("Lister tous les ECs de cette UE ");
            foreach (Ec c in ec.UePropriete.EcsPropriete)
            {
                Console.WriteLine(c.id + " | " + c.NomPropriete);
            }
        }

        public void testCours_Ec(Ec ec)
        {
            Console.WriteLine("Lister les Cours de cet EC ");
            foreach(Cours c in ec.ListeCoursPropriete){
                Console.WriteLine(c.id+" | "+c.GroupePropriete+ " | "+c.NbHeureTotalPropriete);
            }
        }

        public List<Ec> testFindBy(EcDAO ecDAO)
        {
            Dictionary<string, string> contraintes = new Dictionary<string, string>();
            contraintes.Add("nom", "Amérique");
            List<Ec> lc = ecDAO.findBy(contraintes);

            foreach (Ec c in lc) { Console.WriteLine("Test FindBy Ec : " + c.id + " | " + c.NomPropriete); }
            return lc;
        }

        public void testFindAll(EcDAO ecDAO)
        {
            Console.WriteLine("*** FindAll Ec ***");
            foreach (Ec p in ecDAO.findAll())
            {
                Console.WriteLine(p.id + " | " + p.NomPropriete);
            }
        }
    }
}
