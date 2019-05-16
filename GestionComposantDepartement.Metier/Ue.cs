using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComposantDepartement.Metier
{
    class Ue
    {
        private String nom;

        public String NomPropriete
        {
            get { return nom; }
            set { nom = value; }
        }
        private Semestre semestre;

        internal Semestre SemestrePropriete
        {
            get { return semestre; }
            set { semestre = value; }
        }
        private List<Ec> ecs;

        internal List<Ec> EcsPropriete
        {
            get { return ecs; }
            set { ecs = value; }
        }
    }
}
