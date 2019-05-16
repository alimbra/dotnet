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
    }
}
