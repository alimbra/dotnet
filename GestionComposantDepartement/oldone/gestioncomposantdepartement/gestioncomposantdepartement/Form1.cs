using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using gestioncomposantdepartement.Metier;
using gestioncomposantdepartement.DAO;
using gestioncomposantdepartement.DAO.MySql; 

namespace gestioncomposantdepartement
{
    public partial class Accueil : MaterialSkin.Controls.MaterialForm
    {
        private Label lbl;
        private int largeur, hauteur;
        public Accueil()
        {
            InitializeComponent();
            lbl = new Label();

            //ChangeBorderColor(btnPersonnel, Color.DarkSeaGreen);
            

            donneesPersonnel.Visible = false;
            donneesCategorie.Visible = false;
            panelCat.Visible = false;

            largeur = panelAffichage.Size.Width;
            hauteur = panelAffichage.Size.Height;
            MysqlDaoFactory mysql = new MysqlDaoFactory();

            PersonnelDAO p = (PersonnelDAO)mysql.getPersonnelDAO();

            foreach (Personnel personnel in p.findAll())
            {
                this.donneesPersonnel.Rows.Add(personnel.id, personnel.NomPropriete, personnel.PrenomPropriete, personnel.CategoriePropriete.NomUniquePropriete);
            }

            CategorieDAO cd = (CategorieDAO)mysql.getCategorieDAO();

            foreach (Categorie categorie in cd.findAll())
            {
                this.donneesCategorie.Rows.Add( categorie.NomUniquePropriete, categorie.NbHeuresPropriete);
            }
        }

        private void ChangeBorderColor(Control ctrl, Color color)
        {
            Pen pen = new Pen(color, 3);
            Rectangle rect = new Rectangle(0, 0, ctrl.Size.Width - 1, ctrl.Size.Height - 1);
            using (Graphics graphics = ctrl.CreateGraphics())
                graphics.DrawRectangle(pen, rect);
        }

        private void initDesPanels()
        {
            panelAffichage.Controls.Clear();

            donneesPersonnel.Visible = false;
            donneesCategorie.Visible = false;

            panelAffichage.Controls.Add(panelPersonnel);
            panelAffichage.Controls.Add(panelDiplome);
            panelAffichage.Controls.Add(panelCategorieProf);
            panelAffichage.Controls.Add(panelUE);
            panelAffichage.Controls.Add(panelCategorieCours);

            panelPersonnel.Location = new Point(10, 18);
            panelDiplome.Location = new Point(largeur/2  + 25, 18);
            panelCategorieProf.Location = new Point(10, hauteur/2 + 18);
            panelUE.Location = new Point(largeur/3 + 25, hauteur / 2 + 18);
            panelCategorieCours.Location = new Point(2*largeur/3 + 25, hauteur / 2 + 18);


            panelPersonnel.Size = new Size(largeur/2 - 25, hauteur/2 - 30);//new Size(487, 250);
            panelDiplome.Size = new Size(largeur/ 2 - 35, hauteur / 2 - 30);
            panelCategorieProf.Size = new Size(largeur/3 - 15, (hauteur/2)-40);
            panelUE.Size = new Size(largeur/3 - 15, (hauteur/2)-40);
            panelCategorieCours.Size = new Size(largeur/3 - 35, (hauteur/2)-40);

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.panelPersonnel.MouseHover += panelPersonnel_MouseHover;
        }

        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            panelAffichage.Controls.Clear();
            panelPersonnel.Size = panelAffichage.Size;
            panelModifPersonnel.Visible = false;
            donneesPersonnel.Visible = true;
            panelAffichage.Controls.Add(panelPersonnel);
        }


        private void btnUE_Click(object sender, EventArgs e)
        {
            panelAffichage.Controls.Clear();
            panelUE.Location = new Point(0, 0);
            panelUE.Size = panelAffichage.Size;
            panelAffichage.Controls.Add(panelUE);
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            initDesPanels();
        }

        private void btnCategorieProf_Click(object sender, EventArgs e)
        {
            panelAffichage.Controls.Clear();

            panelCategorieProf.Location = new Point(0, 0);
            panelCategorieProf.Size = panelAffichage.Size;
            donneesCategorie.Visible = true;
            panelAffichage.Controls.Add(panelCategorieProf);
        }

        private void btnDiplome_Click(object sender, EventArgs e)
        {
            panelAffichage.Controls.Clear();
            panelDiplome.Location = new Point(0, 0);
            panelDiplome.Size = panelAffichage.Size;
            panelAffichage.Controls.Add(panelDiplome);
        }

        private void btnCategorieCours_Click(object sender, EventArgs e)
        {
            panelAffichage.Controls.Clear();
            panelCategorieCours.Location = new Point(0, 0);
            panelCategorieCours.Size = panelAffichage.Size;
            panelAffichage.Controls.Add(panelCategorieCours);
        }


        private void donneesPersonnel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("Modifier Perso : " + modifierPersonnel.CellType);
            //modifierPersonnel.
            //modifierPersonnel.//Image.FromFile("/Resources/modifierIcone.PNG");
            /*if(e != null)
            {
                if(donneesPersonnel.Columns[e.ColumnIndex].Name == "modifierPersonnel")
                {
                    lblModifAjoutPersonnel.Text = "Modifier Personnel";
                    btnValiderPersonnel.Text = "Modifier";
                    panelModifPersonnel.Visible = true;
                }
            }*/
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            CategorieDAO c = (CategorieDAO)mysql.getCategorieDAO();
            PersonnelDAO personnelDao = (PersonnelDAO)mysql.getPersonnelDAO();
            int index = donneesPersonnel.CurrentRow.Index;

            if(e != null)
            {
                if(donneesPersonnel.Columns[e.ColumnIndex].Name == "modifierPersonnel")
                {
                    lblModifAjoutPersonnel.Text = "Modifier Personnel";
                    btnValiderPersonnel.Text = "Modifier";
                    panelModifPersonnel.Visible = true;

                    txtBoxIdPersonnel.Text = donneesPersonnel[0, index].Value.ToString();
                    txtBoxNomPersonnel.Text    = donneesPersonnel[1,index].Value.ToString();
                    txtBoxPrenomPersonnel.Text = donneesPersonnel[2,index].Value.ToString();

                    comboBox1.Items.Clear();
                    foreach (Categorie cat in c.findAll())
                    {
                        comboBox1.Items.Add(cat.NomUniquePropriete);
                        if (donneesPersonnel[3, index].Value.ToString().Equals(cat.NomUniquePropriete))
                        {
                            comboBox1.Text = cat.NomUniquePropriete;
                            comboBox1.SelectedItem = cat.NomUniquePropriete;
                           // MessageBox.Show(comboBox1.SelectedItem.ToString());

                        }
                        
                    }             
                }
                else if (donneesPersonnel.Columns[e.ColumnIndex].Name == "supprimerPersonnel")
                {
                    if (MessageBox.Show(this, "Etes-vous sûr de suprrimer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Convert.ToInt32(donneesPersonnel[0, index].Value);
                        personnelDao.delete(Convert.ToInt32(donneesPersonnel[0, index].Value));

                        donneesPersonnel.Rows.Clear();

                        foreach (Personnel person in personnelDao.findAll())
                        {
                            this.donneesPersonnel.Rows.Add(person.id, person.NomPropriete, person.PrenomPropriete, person.CategoriePropriete.NomUniquePropriete);
                        }
                        //Action si l'utilisateur est sûr

                    }
                }   
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAnnulerPersonnel_Click(object sender, EventArgs e)
        {
            panelModifPersonnel.Visible = false;
            
        }

        private void btnValiderPersonnel_Click(object sender, EventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            PersonnelDAO personnel = (PersonnelDAO)mysql.getPersonnelDAO();
            CategorieDAO categorie = (CategorieDAO)mysql.getCategorieDAO();

            if (btnValiderPersonnel.Text=="Ajouter")
            {
                try
                {

                    Personnel personne=new Personnel();
                    personne.NomPropriete = txtBoxNomPersonnel.Text.ToString();
                    personne.PrenomPropriete = txtBoxPrenomPersonnel.Text.ToString();
                    Categorie cat=categorie.findByNom(comboBox1.SelectedItem.ToString());
                    personne.CategoriePropriete = cat;
                        
                    personnel.create(personne);
                    MessageBox.Show("nouveau personnel créé");
                    panelModifPersonnel.Visible = false;

                }
                catch (MySqlException me)
                {
                    Personnel personne = new Personnel();
                    personne.NomPropriete = txtBoxNomPersonnel.Text.ToString();
                    personne.PrenomPropriete = txtBoxPrenomPersonnel.Text.ToString();
                    Categorie cat = categorie.findByNom(comboBox1.SelectedItem.ToString());
                    personne.CategoriePropriete = cat;
                    MessageBox.Show(me.ToString());
                    //panelModifPersonnel.Visible = false;

                }
                
            }
            else if (btnValiderPersonnel.Text == "Modifier")
            {

                try
                {

                    Personnel personne = new Personnel();
                    personne.id = Convert.ToInt16(txtBoxIdPersonnel.Text);
                    personne.NomPropriete = txtBoxNomPersonnel.Text.ToString();
                    personne.PrenomPropriete = txtBoxPrenomPersonnel.Text.ToString();
                    Categorie cat = categorie.findByNom(comboBox1.SelectedItem.ToString());
                    personne.CategoriePropriete = cat;

                    personnel.update(personne, cat.id);
                    MessageBox.Show("personnel mis a jour");
                    panelModifPersonnel.Visible = false;

                }
                catch (MySqlException me)
                {
                    Personnel personne = new Personnel();
                    personne.NomPropriete = txtBoxNomPersonnel.Text.ToString();
                    personne.PrenomPropriete = txtBoxPrenomPersonnel.Text.ToString();
                    Categorie cat = categorie.findByNom(comboBox1.SelectedItem.ToString());
                    personne.CategoriePropriete = cat;
                    MessageBox.Show(me.ToString());
                    //panelModifPersonnel.Visible = false;

                }


            }

            donneesPersonnel.Rows.Clear();
            PersonnelDAO p = (PersonnelDAO)mysql.getPersonnelDAO();

            foreach (Personnel person in p.findAll())
            {
                this.donneesPersonnel.Rows.Add(person.id, person.NomPropriete, person.PrenomPropriete, person.CategoriePropriete.NomUniquePropriete);
            }
        }


        private void btnAjouterPersonnel_Click(object sender, EventArgs e)
        {
            lblModifAjoutPersonnel.Text = "Ajouter Personnel";
            btnValiderPersonnel.Text = "Ajouter";
            panelModifPersonnel.Visible = true;
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            CategorieDAO c = (CategorieDAO)mysql.getCategorieDAO();
            comboBox1.Items.Clear();
            foreach (Categorie cat in c.findAll())
            {

                comboBox1.Items.Add(cat.NomUniquePropriete);
            }
 
        }

        

        private void panelPersonnel_Paint_1(object sender, PaintEventArgs e)
        {
            ChangeBorderColor(panelPersonnel, Color.DarkSeaGreen);
        }

    

       

        private void lblModifAjoutPersonnel_Click(object sender, EventArgs e)
        {

        }

        private void panelDiplome_Paint_1(object sender, PaintEventArgs e)
        {
            ChangeBorderColor(panelDiplome, Color.Wheat);
        }

        private void panelCategorieProf_Paint_1(object sender, PaintEventArgs e)
        {
            ChangeBorderColor(panelCategorieProf, Color.LightBlue);
        }

        private void panelUE_Paint_1(object sender, PaintEventArgs e)
        {
            ChangeBorderColor(panelUE, Color.Khaki);
        }

        private void panelCategorieCours_Paint_1(object sender, PaintEventArgs e)
        {
            ChangeBorderColor(panelCategorieCours, Color.Thistle);
        }

        private void btnAjouterCategorie_Click(object sender, EventArgs e)
        {
            panelCat.Visible = true;
        }

        private void validerAjoutCat_Click(object sender, EventArgs e)
        {
            String nomCategorie = nomCat.Text;
            string nb = nbHeureCat.Text;
            int nombreHeure = Convert.ToInt32(nb);
            Categorie categorie=new Categorie();
            categorie.NomUniquePropriete = nomCategorie;
            categorie.NbHeuresPropriete = nombreHeure;
           
            CategorieDAO categorieDao = new CategorieDAO();
            try{
                categorieDao.create(categorie);
                MessageBox.Show("nouvelle categorie créée");

            }
            catch(MySqlException me){
                MessageBox.Show("erreur de creation de la nouvelle catégorie");

            }


        }

      
    }
}
