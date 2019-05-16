using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    class CategorieTesteurDAO:TesteurDAO
    {

        public CategorieTesteurDAO() : base(){ }

        override
        public void tester()
        {
            Console.WriteLine("Test Categorie DAO");
            CategorieDAO categorieDAO = (CategorieDAO)daoFactory.getCategorieDAO();
            //Categorie categorie = testCreer(categorieDAO);
            Categorie categorie1 = testFind(1, categorieDAO); 
        }

        public Categorie testCreer(CategorieDAO categorieDAO)
        {
            Categorie categorie = new Categorie();
            categorie.NomUniquePropriete = "Enseignant Chercheur";
            categorie.NbHeuresPropriete = 200; 
            categorieDAO.create(categorie);
            Console.WriteLine("Catégorie créée avec succès"); 
            return categorie;
        }

        public Categorie testFind(int id,CategorieDAO categorieDAO)
        {
            Categorie categorie = categorieDAO.find(id);
            Console.WriteLine(categorie.id + " | " + categorie.NomUniquePropriete + " | " + categorie.NbHeuresPropriete);
            Console.WriteLine("Personnels de cette catégrorie");
            foreach(Personnel p in categorie.personnelsPropriete){
                Console.WriteLine(p.id+" | "+p.PrenomPropriete+" | "+p.NomPropriete);
            }
 
            return categorie; 
        }

    }
}
