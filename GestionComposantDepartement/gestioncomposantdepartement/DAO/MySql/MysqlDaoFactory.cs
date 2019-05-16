using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace gestioncomposantdepartement.DAO.MySql
{
    public class MysqlDaoFactory:AbstractDAOFactory
    {

        override
        public void creerSchema()
        {
            MethodInfo[] methodes = this.GetType().GetMethods(); 
            string[] tab = {}; 
            foreach(MethodInfo m in methodes){
                if (m.ReturnType.ToString() == "gestioncomposantdepartement.DAO.DAO")
                {
                    DAO dao = (DAO) m.Invoke(this, tab);
                    //ici créer la table
                    dao.createTable();
                    //tuples par defaut
                    dao.creerTuplesParDefaut();
                    //Console.WriteLine(dao.GetType()); 
                }
            }
            Console.WriteLine("Schema de données crée avec succès"); 
        }

        override
        public DAO getUeDAO()
        {
            if (ueDao == null) ueDao = new UeDAO();
            return ueDao;
        }

        override
        public DAO getEcDAO()
        {
            if (ecDao == null) ecDao = new EcDAO();
            return ecDao;
        }

        override
        public DAO getTypeCoursDAO()
        {
            if (typeCoursDAO == null) typeCoursDAO = new TypeCoursDAO();
            return typeCoursDAO; 
        }

        override
        public DAO getCategorieDAO()
        {
            if (categorieDAO == null) categorieDAO = new CategorieDAO();
            return categorieDAO;
        }

        override
        public DAO getDepartementDAO()
        {
            if (departementDAO == null) departementDAO = new CategorieDAO();
            return departementDAO;
        }

        override
        public DAO getPersonnelDAO()
        {
            if (personnelDAO == null) personnelDAO = new PersonnelDAO();
            return personnelDAO;
        }

        override
        public DAO getCoursDAO()
        {
            if (coursDao == null) coursDao = new CoursDAO();
            return coursDao;
        }

        override
        public DAO getCoefficientDAO()
        {
            if (coefficientDao == null) coefficientDao = new CoefficientDAO();
            return coefficientDao;
        }

        override
        public DAO getDiplomeDAO()
        {
            if (diplomeDao == null) diplomeDao = new DiplomeDAO();
            return diplomeDao;
        }

        override
        public DAO getAnneeDAO()
        {
            if (anneeDao == null) anneeDao = new AnneeDAO();
            return anneeDao;
        }

        override
        public DAO getSemestreDAO()
        {
            if (semestreDao == null) semestreDao = new SemestreDAO();
            return semestreDao;
        }

    }
}
