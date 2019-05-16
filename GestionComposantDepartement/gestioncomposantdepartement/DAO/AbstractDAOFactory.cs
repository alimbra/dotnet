using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.DAO
{
    public abstract class AbstractDAOFactory
    {
        protected DAO ueDao = null;
        protected DAO ecDao = null;
        protected DAO typeCoursDAO = null;
        protected DAO categorieDAO = null;
        protected DAO personnelDAO = null;
        protected DAO coursDao = null;
        protected DAO coefficientDao = null;
        protected DAO diplomeDao = null;
        protected DAO anneeDao = null;
        protected DAO semestreDao = null;
        protected DAO departementDAO = null;

        public abstract DAO getUeDAO();
        public abstract DAO getEcDAO();
        public abstract DAO getTypeCoursDAO();
        public abstract DAO getCategorieDAO();
        public abstract DAO getDepartementDAO();
        public abstract DAO getPersonnelDAO();
        public abstract DAO getCoursDAO();
        public abstract DAO getCoefficientDAO();
        public abstract DAO getDiplomeDAO();
        public abstract DAO getAnneeDAO();
        public abstract DAO getSemestreDAO();
        public abstract void creerSchema();
    }
}
