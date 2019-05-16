using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Cours
    {
        private String groupe;

        public String GroupePropriete
        {
            get { return groupe; }
            set { groupe = value; }
        }
        private int nbHeureTotal;

        public int NbHeureTotalPropriete
        {
            get { return nbHeureTotal; }
            set { nbHeureTotal = value; }
        }
        private TypeCours typeCours;

        internal TypeCours TypeCoursPropriete
        {
            get { return typeCours; }
            set { typeCours = value; }
        }
        private List<HeurePresentielle> heuresPresentielles;

        private List<HeurePresentielle> HeuresPresentiellesPropriete
        {
            get { return heuresPresentielles; }
            set { heuresPresentielles = value; }
        }
        private List<Personnel> personnels;

        internal List<Personnel> PersonnelsPropriete
        {
            get { return personnels; }
            set { personnels = value; }
        }


    }
}
