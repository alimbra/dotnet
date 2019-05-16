using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionComposantDepartement
{
    public partial class Accueil : MaterialSkin.Controls.MaterialForm
    {
        public Accueil()
        {
            InitializeComponent();
            panelAffichage.Controls.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panelAffichageCategorie.Controls.Add(button3); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorie_Click(object sender, EventArgs e)
        {
            panelAffichage.Controls.Clear();
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
