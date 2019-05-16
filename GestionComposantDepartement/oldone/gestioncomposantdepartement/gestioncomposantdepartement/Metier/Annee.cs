using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioncomposantdepartement.Metier
{
    public class Annee
    {
        private int id;

        public int IdPropriete
        {
            get { return id; }
            set { id = value; }
        }
        private Diplome diplome;

        internal Diplome DiplomePropriete
        {
            get { return diplome; }
            set { diplome = value; }
        }
        private int anneeScolaire;

        public int AnneeScolairePropriete
        {
            get { return anneeScolaire; }
            set { anneeScolaire = value; }
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
