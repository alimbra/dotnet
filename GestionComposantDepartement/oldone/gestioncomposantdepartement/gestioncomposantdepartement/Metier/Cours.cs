using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Cours
    {
        public int id; 

        private String groupe;
        private Ec ec;
        private double heures;

        public double heuresPropriete
        {
            get { return heures; }
            set { heures = value;  }
        }

        public Ec EcPropriete
        {
            get { return ec; }
            set { ec = value; }
        }

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
        /*
        private List<HeurePresentielle> heuresPresentielles;

        private List<HeurePresentielle> HeuresPresentiellesPropriete
        {
            get { return heuresPresentielles; }
            set { heuresPresentielles = value; }
        }
        */
        private Personnel personnel;

        public Personnel PersonnelPropriete
        {
            get { return personnel; }
            set { personnel = value; }
        }


    }
}
