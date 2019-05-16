using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Annee
    {
        public int id;

        public string etude;
        private Diplome diplome;

        internal Diplome DiplomePropriete
        {
            get { return diplome; }
            set { diplome = value; }
        }


        public string etudePropriete
        {
            get { return etude; }
            set { etude = value; }
        }

        private List<Semestre> listeSemestre;

        internal List<Semestre> ListeSemestrePropriete
        {
            get { return listeSemestre; }
            set { listeSemestre = value; }
        }
        public void ajouterSemestre(Semestre semestre)
        {
            listeSemestre.Add(semestre);
        }

        public void supprimerSemestre(Semestre semestre)
        {
            listeSemestre.Remove(semestre);
        }


    }
}
