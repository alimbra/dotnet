using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class HeurePresentielle
    {
        private DateTime dateDebut;

        public DateTime DateDebutPropriete
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }
        private DateTime dateFin;

        public DateTime DateFinPropriete
        {
            get { return dateFin; }
            set { dateFin = value; }
        }
        private Personnel personnel;

        internal Personnel PersonnelPropriete
        {
            get { return personnel; }
            set { personnel = value; }
        }

        private Cours cours;

        internal Cours CoursPropriete
        {
            get { return cours; }
            set { cours = value; }
        }
    }
}
