using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionComposantDepartement
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
            instance.initConnexion();
            //instance.creerBaseDeDonnees();
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Accueil());
        }
    }
}
