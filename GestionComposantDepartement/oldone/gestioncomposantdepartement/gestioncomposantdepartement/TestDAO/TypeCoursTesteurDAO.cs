using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestioncomposantdepartement.DAO.MySql;
using gestioncomposantdepartement.Metier;

namespace gestioncomposantdepartement.TestDAO
{
    class TypeCoursTesteurDAO:TesteurDAO
    {

        public TypeCoursTesteurDAO()
            : base()
        {

        }

        override
        public void tester()
        {
            Console.WriteLine("Test TypeCours DAO ");
            TypeCoursDAO typeCoursDAO = (TypeCoursDAO)daoFactory.getTypeCoursDAO();
            TypeCours t = testFind(1, typeCoursDAO);
        }

        public TypeCours testCreer(TypeCoursDAO typeCoursDAO)
        {
            TypeCours typeCours = new TypeCours();
            typeCours.NomUniquePropriete = "CM";
            typeCoursDAO.create(typeCours);
            Console.WriteLine("Création type cours avec succès");
            return typeCours;
        }

        public TypeCours testFind(int id, TypeCoursDAO typeCoursDAO)
        {
            TypeCours typeCours = typeCoursDAO.find(id);
            Console.WriteLine(typeCours.id+" | "+typeCours.NomUniquePropriete);
            Console.WriteLine("Liste des cours de ce type");
            foreach(Cours c in typeCours.ListeCoursPropriete){
                Console.WriteLine(c.id+" | "+c.GroupePropriete+" | "+c.NbHeureTotalPropriete); 
            }
            return typeCours;
        }
    }
}
