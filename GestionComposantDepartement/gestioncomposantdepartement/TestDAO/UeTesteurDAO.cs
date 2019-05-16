using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    public class UeTesteurDAO : TesteurDAO
    {

        public UeTesteurDAO() : base()
        {

        }

        override
        public void tester()
        {
            Console.WriteLine("Test UE DAO : CREATION");
            UeDAO ueDAO = (UeDAO)daoFactory.getUeDAO();
            Ue ue = testCreer(ueDAO);
            Ue ue1 = testFind(1, ueDAO);
            testECs_de_UE(ue1);
            List<Ue> ues = testFindBy(ueDAO); 
            this.testFindAll(ueDAO);
        }

        public Ue testCreer(UeDAO ueDAO)
        {
            Ue ue = new Ue();
            ue.NomPropriete = "Géographie";
            ueDAO.create(ue);
            return ue;
        }

        public Ue testFind(int id, UeDAO ueDAO){
            return ueDAO.find(id);
        }

        public void testECs_de_UE(Ue ue)
        {
            foreach (Ec c in ue.EcsPropriete)
            {
                Console.Write(c.id + " | ");
                Console.Write(c.NomPropriete + " | ");
                Console.WriteLine(c.UePropriete.id);
            }
        }

        public List<Ue> testFindBy(UeDAO ueDAO)
        {
            Dictionary<string, string> contraintes = new Dictionary<string, string>();
            contraintes.Add("nom", "Géographie");
            List<Ue> lc = ueDAO.findBy(contraintes);

            foreach (Ue c in lc) { Console.WriteLine("Test FindBy Ue : " + c.id + " | " + c.NomPropriete); }
            return lc;
        }

        public void testFindAll(UeDAO ueDAO)
        {
            Console.WriteLine("*** FindAll Ue ***");
            foreach (Ue p in ueDAO.findAll())
            {
                Console.WriteLine(p.id + " | " + p.NomPropriete);
            }
        }
    }
}
