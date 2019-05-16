using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;  

namespace gestioncomposantdepartement.DAO
{
    public abstract class DAO
    {
        protected MySqlCommand commande = ConnexionMySql.getInstance().getCommande();
        public abstract void createTable();
        public abstract void creerTuplesParDefaut();
        /*public abstract void create(Object o);
        public abstract Object find(int id); */
    }
}
