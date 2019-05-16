using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestioncomposantdepartement.TestDAO;
using gestioncomposantdepartement.DAO.MySql;

namespace gestioncomposantdepartement
{
    static class Program
    {


        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //initialisation MySql
            ConnexionMySql instance = ConnexionMySql.getInstance();
            instance.initConnexion("localhost", "root", "");
            instance.creerBaseDeDonnees();

            MysqlDaoFactory mysqlDaoFactory = new MysqlDaoFactory();
            mysqlDaoFactory.creerSchema();

            //tests
            TestsDAO testeur = new TestsDAO();
            //testeur.test1();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Accueil());
        }
    }
}
