using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.TestDAO;
using gestioncomposantdepartement.DAO.MySql;

namespace gestioncomposantdepartement.TestDAO
{
    public class TestsDAO
    {
        public TestsDAO() { }

        public void test1()
        {
            //Tests DAO
            //test ue
            UeTesteurDAO ueTesteur = new UeTesteurDAO();
            ueTesteur.tester();
            //test ec
            EcTesteurDAO ecTesteur = new EcTesteurDAO();
            ecTesteur.tester();
            //test TypeCours
            TypeCoursTesteurDAO typeCoursTesteur = new TypeCoursTesteurDAO();
            typeCoursTesteur.tester();
            //test Categorie
            CategorieTesteurDAO categorieTesteur = new CategorieTesteurDAO();
            categorieTesteur.tester();
            //Test personnel 
            PersonnelTesteurDAO personnelTesteur = new PersonnelTesteurDAO();
            personnelTesteur.tester();
            //test Département
            DepartementTesteurDAO departementTesteur = new DepartementTesteurDAO();
            departementTesteur.tester();
            //test cours
            CoursTesteurDAO coursTesteur = new CoursTesteurDAO();
            coursTesteur.tester();
        }
    }
}
