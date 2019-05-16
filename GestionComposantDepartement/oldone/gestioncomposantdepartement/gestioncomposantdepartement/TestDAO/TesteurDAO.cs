using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier; 

namespace gestioncomposantdepartement.TestDAO
{ 

    public abstract class TesteurDAO
    {

        public MysqlDaoFactory daoFactory; 

        public TesteurDAO(){
            daoFactory = new MysqlDaoFactory();
        }

        public abstract void tester();
 
    }
}
