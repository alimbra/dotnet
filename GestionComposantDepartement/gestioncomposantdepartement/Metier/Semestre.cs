using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Semestre
    {
        public int id;
        public int numero;

        public string titre;

        private Annee annee;

        public Annee AnneePropriete
        {
            get { return annee; }
            set { annee = value; }
        }

        private List<Ue> listeUe;

        internal List<Ue> ListeUePropriete
        {
            get { return listeUe; }
            set { listeUe = value; }
        }

    }
}
