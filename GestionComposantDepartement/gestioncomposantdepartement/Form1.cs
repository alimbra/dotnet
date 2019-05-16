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

            Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);
            skyBluePen.Width = 8.0F;
            skyBluePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            //ChangeBorderColor(btnPersonnel, Color.DarkSeaGreen);


            donneesPersonnel.Visible = false;
            donneesCategorie.Visible = false;
            panelCat.Visible = false;
            panelAnnee.Visible = false;
            panelDetail.Hide();

            largeur = panelAffichage.Size.Width;
            hauteur = panelAffichage.Size.Height;
            MysqlDaoFactory mysql = new MysqlDaoFactory();

            PersonnelDAO p = (PersonnelDAO)mysql.getPersonnelDAO();

            foreach (Personnel personnel in p.findAll())
            {
                this.donneesPersonnel.Rows.Add(personnel.id, personnel.NomPropriete, personnel.PrenomPropriete,
                    personnel.CategoriePropriete.NomUniquePropriete,personnel.CategoriePropriete.NbHeuresPropriete);
            }

            CategorieDAO cd = (CategorieDAO)mysql.getCategorieDAO();

            foreach (Categorie categorie in cd.findAll())
            {
                this.donneesCategorie.Rows.Add(categorie.NomUniquePropriete, categorie.NbHeuresPropriete);
            }

            DiplomeDAO diplomeDAO = (DiplomeDAO)mysql.getDiplomeDAO();
            this.donneeDiplome.Rows.Clear();
            foreach (Diplome dip in diplomeDAO.findAll())
            {
                this.donneeDiplome.Rows.Add(dip.id, dip.intitule);
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
            donneeDiplome.Visible = false;


            panelAffichage.Controls.Add(panelPersonnel);
            panelAffichage.Controls.Add(panelDiplome);
            panelAffichage.Controls.Add(panelCategorieProf);
            panelAffichage.Controls.Add(panelUE);
            panelAffichage.Controls.Add(panelCategorieCours);

            panelPersonnel.Location = new Point(10, 18);
            panelDiplome.Location = new Point(largeur / 2 + 25, 18);
            panelCategorieProf.Location = new Point(10, hauteur / 2 + 18);
            panelUE.Location = new Point(largeur / 3 + 25, hauteur / 2 + 18);
            panelCategorieCours.Location = new Point(2 * largeur / 3 + 25, hauteur / 2 + 18);


            panelPersonnel.Size = new Size(largeur / 2 - 25, hauteur / 2 - 30);//new Size(487, 250);
            panelDiplome.Size = new Size(largeur / 2 - 35, hauteur / 2 - 30);
            panelCategorieProf.Size = new Size(largeur / 3 - 15, (hauteur / 2) - 40);
            panelUE.Size = new Size(largeur / 3 - 15, (hauteur / 2) - 40);
            panelCategorieCours.Size = new Size(largeur / 3 - 35, (hauteur / 2) - 40);


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

            MysqlDaoFactory mysql = new MysqlDaoFactory();
            UeDAO ueDAO = (UeDAO)mysql.getUeDAO();
            this.donneeDiplome.Rows.Clear();
            foreach (Ue u in ueDAO.findAll())
            {
                this.donneesUe.Rows.Add(u.id, u.NomPropriete, u.SemestrePropriete.titre);
            }

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
            donneeDiplome.Visible = true;
            lesdiplomesLabel.Visible = true;
            
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
            CoursDAO coursDAO = (CoursDAO)mysql.getCoursDAO();
            int index = donneesPersonnel.CurrentRow.Index;

            if (e != null)
            {
                if (donneesPersonnel.Columns[e.ColumnIndex].Name == "modifierPersonnel")
                {
                    lblModifAjoutPersonnel.Text = "Modifier Personnel";
                    btnValiderPersonnel.Text = "Modifier";
                    panelModifPersonnel.Visible = true;
                    panelDetail.Visible = false;

                    txtBoxIdPersonnel.Text = donneesPersonnel[0, index].Value.ToString();
                    txtBoxNomPersonnel.Text = donneesPersonnel[1, index].Value.ToString();
                    txtBoxPrenomPersonnel.Text = donneesPersonnel[2, index].Value.ToString();

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
                            this.donneesPersonnel.Rows.Add(person.id, person.NomPropriete, person.PrenomPropriete,
                                person.CategoriePropriete.NomUniquePropriete,person.CategoriePropriete.NbHeuresPropriete);
                        }
                        //Action si l'utilisateur est sûr

                    }
                }
                else if (donneesPersonnel.Columns[e.ColumnIndex].Name == "detailPersonnel")
                {
                    panelDetail.Visible = true;
                    panelModifPersonnel.Visible = false;
                    txtBoxIdPersonnel.Text = donneesPersonnel[0, index].Value.ToString();

                    details_nom_prenom.Text =  donneesPersonnel[1, index].Value.ToString()+" "+
                        donneesPersonnel[2, index].Value.ToString();
                    labelCategDetail.Text = donneesPersonnel[3, index].Value.ToString();
                    nbHeureCategorie.Text = donneesPersonnel[4, index].Value.ToString();

                    Dictionary<String, String> dico = new Dictionary<string, string>();
                    txtBoxIdPersonnel.Text = donneesPersonnel[0, index].Value.ToString();

                    dico.Add("personnel_id", donneesPersonnel[0, index].Value.ToString());


                    this.listeDesCoursAffecte.Rows.Clear();

                    foreach (Cours cours in coursDAO.findBy(dico))
                    {
                        this.listeDesCoursAffecte.Rows.Add(cours.GroupePropriete,cours.EcPropriete.NomPropriete,
                            cours.NbHeureTotalPropriete,cours.heuresPropriete);
                    
                    }

                    dico.Clear();
                    this.listeDesCoursNonAffecte.Rows.Clear();

                    foreach (Cours cours in coursDAO.findNonAffecte())
                    {
                        this.listeDesCoursNonAffecte.Rows.Add(cours.id,cours.GroupePropriete, cours.EcPropriete.NomPropriete,
                            cours.NbHeureTotalPropriete, cours.heuresPropriete);

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

            if (btnValiderPersonnel.Text == "Ajouter")
            {
                try
                {

                    Personnel personne = new Personnel();
                    personne.NomPropriete = txtBoxNomPersonnel.Text.ToString();
                    personne.PrenomPropriete = txtBoxPrenomPersonnel.Text.ToString();
                    Categorie cat = categorie.findByNom(comboBox1.SelectedItem.ToString());
                    personne.CategoriePropriete = cat;

                    personnel.create(personne);
                    MessageBox.Show("nouveau personnel créé");
                    panelModifPersonnel.Visible = false;

                }
                catch (MySqlException me)
                {

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
                    MessageBox.Show(me.ToString());
                    //panelModifPersonnel.Visible = false;
                }


            }

            donneesPersonnel.Rows.Clear();
            PersonnelDAO p = (PersonnelDAO)mysql.getPersonnelDAO();

            foreach (Personnel person in p.findAll())
            {
                this.donneesPersonnel.Rows.Add(person.id, person.NomPropriete, person.PrenomPropriete,
                    person.CategoriePropriete.NomUniquePropriete,person.CategoriePropriete.NbHeuresPropriete);
            }
        }


        private void btnAjouterPersonnel_Click(object sender, EventArgs e)
        {
            lblModifAjoutPersonnel.Text = "Ajouter Personnel";
            btnValiderPersonnel.Text = "Ajouter";
            panelModifPersonnel.Visible = true;
            panelDetail.Visible = false;
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
            Categorie categorie = new Categorie();
            categorie.NomUniquePropriete = nomCategorie;
            categorie.NbHeuresPropriete = nombreHeure;

            CategorieDAO categorieDao = new CategorieDAO();
            try
            {
                categorieDao.create(categorie);
                MessageBox.Show("nouvelle categorie créée");
                this.donneesCategorie.Rows.Clear();
                foreach (Categorie cat in categorieDao.findAll())
                {
                    this.donneesCategorie.Rows.Add(cat.NomUniquePropriete, cat.NbHeuresPropriete);
                }

            }
            catch (MySqlException me)
            {
                MessageBox.Show("erreur de creation de la nouvelle catégorie " + me);

            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ajouterAnnee_Click(object sender, EventArgs e)
        {
            panelAnnee.Visible = true;
            labelajoutAnnee.Text = "Ajouter Année";
            validerAnnee.Text = "Valider";
            annee_etude.Text = "";
        }

        private void validerAnnee_Click(object sender, EventArgs e)
        {
            AnneeDAO anneeDao = new AnneeDAO();
            Annee annee = new Annee();
            MysqlDaoFactory mysql = new MysqlDaoFactory();

            DiplomeDAO diplomeDAO = (DiplomeDAO)mysql.getDiplomeDAO();

            if (validerAnnee.Text == "Valider")
            {
                String intitule = diplomeIntitule.Text;
                annee.etude = annee_etude.Text.ToString();
                annee.DiplomePropriete = diplomeDAO.find(Convert.ToInt16(hiddenDiplomeId.Text));

                try
                {
                    anneeDao.create(annee);
                    MessageBox.Show("nouvelle annee créée");

                }
                catch (MySqlException me)
                {
                    MessageBox.Show("erreur de creation de la nouvelle annee" + me);

                }
            }
            else if (validerAnnee.Text == "Modifier")
            {

                annee.etude = annee_etude.Text.ToString();
                annee.id = Convert.ToInt16(anneeId.Text);

                annee.DiplomePropriete = diplomeDAO.find(Convert.ToInt16(hiddenDiplomeId.Text));

                try
                {
                    anneeDao.update(annee);
                    MessageBox.Show(" annee modifiée");

                }
                catch (MySqlException me)
                {
                    MessageBox.Show("erreur de modification de l´annee :" + me);

                }
            }

            AnneeDAO anneeDAO = (AnneeDAO)mysql.getAnneeDAO();

            this.donneeAnnee.Rows.Clear();
            Diplome diplome = new Diplome();

            diplome.id = Convert.ToInt32(hiddenDiplomeId.Text);
            foreach (Annee an in anneeDAO.findByDiplome(diplome))
            {
                this.donneeAnnee.Rows.Add(an.id, an.etude);
            }
            panelAnnee.Visible = false;

        }

        private void validerDiplome_Click(object sender, EventArgs e)
        {
            DiplomeDAO diplomeDAO = new DiplomeDAO();
            Diplome diplome = new Diplome();

            if (validerDiplome.Text == "Valider")
            {
                String intitule = diplomeIntitule.Text;
                diplome.intitule = intitule;

                try
                {
                    diplomeDAO.create(diplome);
                    MessageBox.Show("nouveau diplome créée");


                }
                catch (MySqlException me)
                {
                    MessageBox.Show("erreur de creation du nouveau diplome" + me);

                }
            }
            else if (validerDiplome.Text == "Modifier")
            {
                try
                {

                    diplome.intitule = diplomeIntitule.Text;
                    diplome.id = Convert.ToInt32(idDiplomeHidden.Text);
                    diplomeDAO.update(diplome);
                    MessageBox.Show("diplome mis a jour");
                    panelAjoutModifDiplome.Visible = false;

                }
                catch (MySqlException me)
                {
                    MessageBox.Show(me.ToString());
                    //panelModifPersonnel.Visible = false;
                }
            }
            this.donneeDiplome.Rows.Clear();
            foreach (Diplome dip in diplomeDAO.findAll())
            {
                this.donneeDiplome.Rows.Add(dip.id, dip.intitule);
            }
            panelAjoutModifDiplome.Visible = false;
        }

        private void donneeDiplome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            DiplomeDAO diplomeDAO = (DiplomeDAO)mysql.getDiplomeDAO();
            int index = donneeDiplome.CurrentRow.Index;

            if (e != null)
            {
                if (donneeDiplome.Columns[e.ColumnIndex].Name == "modifierDiplome")
                {
                    labelAJoutModifDiplome.Text = "Modifier Diplome";
                    validerDiplome.Text = "Modifier";
                    panelAjoutModifDiplome.Visible = true;

                    idDiplomeHidden.Text = donneeDiplome[0, index].Value.ToString();
                    diplomeIntitule.Text = donneeDiplome[1, index].Value.ToString();

                }
                else if (donneeDiplome.Columns[e.ColumnIndex].Name == "supprimerDiplome")
                {
                    if (MessageBox.Show(this, "Etes-vous sûr de suprrimer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Convert.ToInt32(donneeDiplome[0, index].Value);
                        try
                        {
                            diplomeDAO.delete(Convert.ToInt32(donneeDiplome[0, index].Value));
                        }
                        catch (MySqlException me)
                        {
                            MessageBox.Show("erreur de suppression : verifiez votre connexion ou vous devez supprimer vos années vant");

                        }
                        this.donneeDiplome.Rows.Clear();
                        foreach (Diplome dip in diplomeDAO.findAll())
                        {
                            this.donneeDiplome.Rows.Add(dip.id, dip.intitule);
                        }

                    }
                }
                else if (donneeDiplome.Columns[e.ColumnIndex].Name == "detailDiplome")
                {
                    panelAjoutModifDiplome.Visible = false;
                    donneeAnnee.Visible = false;
                    donneeSemestre.Visible = false;
                    ajouter_semestre.Visible = false;
                    ajouterAnnee.Visible = false;

                    donneeAnnee.Visible = true;
                    ajouterAnnee.Visible = true;
                    //int index = donneeDiplome.CurrentRow.Index;

                    Diplome diplome = new Diplome();


                    diplome.id = Convert.ToInt32(donneeDiplome[0, index].Value);
                    diplome.intitule = donneeDiplome[1, index].Value.ToString();

                    //MessageBox.Show(diplome.intitule);
                    MysqlDaoFactory mysql1 = new MysqlDaoFactory();
                    AnneeDAO anneeDAO = (AnneeDAO)mysql1.getAnneeDAO();

                    this.donneeAnnee.Rows.Clear();
                    foreach (Annee annee in anneeDAO.findByDiplome(diplome))
                    {
                        this.donneeAnnee.Rows.Add(annee.id, annee.etude);
                    }
                    hiddenDiplomeId.Text = diplome.id.ToString();
                }

            }
        }

        private void ajouterDiplome_Click(object sender, EventArgs e)
        {
            panelAjoutModifDiplome.Visible = true;
            labelAJoutModifDiplome.Text = "Ajouter Diplome";
        }

        private void donneeDiplome_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void donneeAnnee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            MysqlDaoFactory mysql = new MysqlDaoFactory();
            AnneeDAO anneeDAO = (AnneeDAO)mysql.getAnneeDAO();

            int index = donneeAnnee.CurrentRow.Index;

            if (e != null)
            {
                if (donneeAnnee.Columns[e.ColumnIndex].Name == "modifierAnnee")
                {
                    labelajoutAnnee.Text = "Modifier annee";
                    validerAnnee.Text = "Modifier";
                    panelAnnee.Visible = true;

                    anneeId.Text = donneeAnnee[0, index].Value.ToString();
                    annee_etude.Text = donneeAnnee[1, index].Value.ToString();


                }
                else if (donneeAnnee.Columns[e.ColumnIndex].Name == "supprimerAnnee")
                {
                    if (MessageBox.Show(this, "Etes-vous sûr de suprrimer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Convert.ToInt32(donneeAnnee[0, index].Value);
                        anneeDAO.delete(Convert.ToInt32(donneeAnnee[0, index].Value));


                        this.donneeAnnee.Rows.Clear();
                        Diplome diplome = new Diplome();

                        diplome.id = Convert.ToInt32(hiddenDiplomeId.Text);
                        foreach (Annee an in anneeDAO.findByDiplome(diplome))
                        {
                            this.donneeAnnee.Rows.Add(an.id, an.etude);
                        }
                        panelAnnee.Visible = false;

                    }
                }
                else if (donneeAnnee.Columns[e.ColumnIndex].Name == "detailAnnee")
                {
                    panelAjoutModifDiplome.Visible = false;

                    donneeSemestre.Visible = false;
                    ajouter_semestre.Visible = false;

                    donneeSemestre.Visible = true;
                    ajouter_semestre.Visible = true;

                    Annee annee = new Annee();


                    annee.id = Convert.ToInt32(donneeAnnee[0, index].Value);
                    //annee.etude = donneeAnnee[1, index].Value.ToString();

                    MysqlDaoFactory mysql1 = new MysqlDaoFactory();
                    SemestreDAO semestreDAO = (SemestreDAO)mysql1.getSemestreDAO();

                    HiddenAnneeId.Text = donneeAnnee[0, index].Value.ToString();

                    this.donneeSemestre.Rows.Clear();
                    foreach (Semestre semestre in semestreDAO.findByAnnee(annee))
                    {
                        this.donneeSemestre.Rows.Add(semestre.id, semestre.titre);
                    }

                }
  
            }
        }



        private void donneeAnnee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void ajouter_semestre_Click(object sender, EventArgs e)
        {
            panelSemestre.Visible = true;
            textBoxSemestreTitre.Text = "";
            validerSemestre.Text = "Valider";
            labelAjoutSemestre.Text = "Ajouter Semestre";

        }

        private void validerSemestre_Click(object sender, EventArgs e)
        {
            SemestreDAO semestreDAO = new SemestreDAO();
            Semestre semestre = new Semestre();
            Annee an=new Annee();
            Console.WriteLine();
            an.id = Convert.ToInt32(HiddenAnneeId.Text);
            if (validerSemestre.Text == "Valider")
            {
                String titre= textBoxSemestreTitre.Text;
                semestre.titre = titre;
                semestre.AnneePropriete = an;

                try
                {
                    semestreDAO.create(semestre);
                    MessageBox.Show("nouveau semestre créé");

                }
                catch (MySqlException me)
                {
                    MessageBox.Show("erreur de creation du nouveau semestre" + me);

                }
            }
            else if (validerSemestre.Text == "Modifier")
            {
                try
                {
                    String titre = textBoxSemestreTitre.Text;
                    semestre.id = Convert.ToInt32(txtBoxIdSemestre.Text);
                    semestre.titre = titre;
                    semestre.AnneePropriete = an;

                    semestreDAO.update(semestre);
                    MessageBox.Show("semestre mis a jour");
                    panelAjoutModifDiplome.Visible = false;

                }
                catch (MySqlException me)
                {
                    MessageBox.Show(me.ToString());
                    //panelModifPersonnel.Visible = false;
                }
            }


            this.donneeSemestre.Rows.Clear();
     
            foreach (Semestre s in semestreDAO.findByAnnee(an))
            {
                this.donneeSemestre.Rows.Add(s.id, s.titre);
            }
            panelSemestre.Visible = false;

        }

        private void donneeSemestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            SemestreDAO semestreDAO = (SemestreDAO)mysql.getSemestreDAO();
            UeDAO ueDAO = (UeDAO)mysql.getUeDAO();

            int index = donneeSemestre.CurrentRow.Index;

            if (e != null)
            {
                if (donneeSemestre.Columns[e.ColumnIndex].Name == "modifierSemestre")
                {
                    labelAjoutSemestre.Text = "Modifier Semestre";
                    validerSemestre.Text = "Modifier";
                    panelSemestre.Visible = true;

                    txtBoxIdSemestre.Text = donneeSemestre[0, index].Value.ToString();
                    textBoxSemestreTitre.Text = donneeSemestre[1, index].Value.ToString();


                }
                else if (donneeSemestre.Columns[e.ColumnIndex].Name == "supprimerSemestre")
                {
                    if (MessageBox.Show(this, "Etes-vous sûr de suprrimer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Convert.ToInt32(donneeSemestre[0, index].Value);
                        semestreDAO.delete(Convert.ToInt32(donneeSemestre[0, index].Value));


                        this.donneeSemestre.Rows.Clear();
                        Annee annee = new Annee();

                        annee.id = Convert.ToInt32(HiddenAnneeId.Text);
                        foreach (Semestre s in semestreDAO.findByAnnee(annee))
                        {
                            this.donneeSemestre.Rows.Add(s.id, s.titre);
                        }

                        panelSemestre.Visible = false;

                    }
                }
                else if (donneeAnnee.Columns[e.ColumnIndex].Name == "detailSemestre")
                {
                   /* donneesUe.Visible = true;
                    ajouter_ue.Visible = true;
                    Dictionary<String, String> dico1 = new Dictionary<string, string>();

                    dico1.Add("semestre_id", donneeSemestre[0, index].Value.ToString());


                    foreach (Ue ue in ueDAO.findBy(dico1))
                    {
                        donneesUe.Rows.Add(ue.id, ue.NomPropriete, donneeSemestre[0, index].Value.ToString());
                    }
                    */

                }
                

            }
        }

        private void annulerDiplome_Click(object sender, EventArgs e)
        {
            panelAjoutModifDiplome.Visible = false;
        }

        private void annuler_semestre_Click(object sender, EventArgs e)
        {
            panelSemestre.Visible = false;
        }

        private void annuler_annee_Click(object sender, EventArgs e)
        {
            panelAnnee.Visible = false ;
        }

        private void masquerDetail_Click(object sender, EventArgs e)
        {
            panelDetail.Hide();
        }

        private void listeDesCoursNonAffecte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            CoursDAO coursDAO =(CoursDAO) mysql.getCoursDAO();
            int index = listeDesCoursNonAffecte.CurrentRow.Index;

            if (e != null)
            {
                if (listeDesCoursNonAffecte.Columns[e.ColumnIndex].Name == "lier")
                {
                    int idcours = Convert.ToInt32(listeDesCoursNonAffecte[0, index].Value.ToString());
                    int nbHeureCat = Convert.ToInt32(nbHeureCategorie.Text.ToString());
                    int nbHeureTotal = Convert.ToInt32(listeDesCoursNonAffecte[3, index].Value.ToString());

                    if (nbHeureCat<nbHeureTotal){
                        MessageBox.Show("impossible d´affecter! le nombre d´heure du personnel est inferieur à celui du cours");

                    }
                    else
                    {
                        try {
                            Cours co = coursDAO.findByNull(idcours);
                            Personnel personnel = new Personnel();

                            personnel.id = Convert.ToInt32(txtBoxIdPersonnel.Text.ToString());
                            
                            co.PersonnelPropriete = personnel;
                            coursDAO.update(co);
                            MessageBox.Show("affectation reussi");


                            Dictionary<String, String> dico1 = new Dictionary<string, string>();

                            //MessageBox.Show(txtBoxIdPersonnel.Text.ToString());
                            dico1.Add("personnel_id", txtBoxIdPersonnel.Text.ToString());


                            this.listeDesCoursAffecte.Rows.Clear();

                            foreach (Cours crs in coursDAO.findBy(dico1))
                            {
                                this.listeDesCoursAffecte.Rows.Add(crs.GroupePropriete, crs.EcPropriete.NomPropriete,
                                    crs.NbHeureTotalPropriete, crs.heuresPropriete);

                            }

                            dico1.Clear();
                            this.listeDesCoursNonAffecte.Rows.Clear();

                            foreach (Cours cours in coursDAO.findNonAffecte())
                            {
                                this.listeDesCoursNonAffecte.Rows.Add(cours.id, cours.GroupePropriete, cours.EcPropriete.NomPropriete,
                                    cours.NbHeureTotalPropriete, cours.heuresPropriete);

                            }


                        }
                        catch (MySqlException me)
                        {
                            MessageBox.Show("erreur d´affectation au cours :" + me);

                        }

                    }
                }
            }
        }

  

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void donneesUe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ajouterUe_Click(object sender, EventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            UeDAO ueDAO = (UeDAO)mysql.getUeDAO();
            SemestreDAO semestreDAO = (SemestreDAO)mysql.getSemestreDAO();


            UePanel.Visible = true;

            foreach (Semestre s in semestreDAO.findAll())
            {
                this.listeSem.Items.Add( s.titre);
            }
        }

        private void donneesUe_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            UeDAO ueDAO = (UeDAO)mysql.getUeDAO();

            int index = donneesUe.CurrentRow.Index;

            if (e != null)
            {
                if (donneesUe.Columns[e.ColumnIndex].Name == "modifierUe")
                {
                    label_ajout_ue.Text = "Modifier Semestre";
                    validerUe.Text = "Modifier";
                    panelUE.Visible = true;

                    idUe.Text = donneesUe[0, index].Value.ToString();
                    nomUe.Text = donneesUe[1, index].Value.ToString();


                }
                else if (donneesUe.Columns[e.ColumnIndex].Name == "supprimerSemestre")
                {
                    if (MessageBox.Show(this, "Etes-vous sûr de suprrimer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Convert.ToInt32(donneeSemestre[0, index].Value);
                        //ueDAO.delete(Convert.ToInt32(donneeSemestre[0, index].Value));



                        panelUE.Visible = false;
                        this.donneeDiplome.Rows.Clear();
                        foreach (Ue u in ueDAO.findAll())
                        {
                            this.donneesUe.Rows.Add(u.id, u.NomPropriete, u.SemestrePropriete.titre);
                        }

                    }
                }
                else if (donneeAnnee.Columns[e.ColumnIndex].Name == "detailSemestre")
                {
                    /* donneesUe.Visible = true;
                     ajouter_ue.Visible = true;
                     Dictionary<String, String> dico1 = new Dictionary<string, string>();

                     dico1.Add("semestre_id", donneeSemestre[0, index].Value.ToString());


                     foreach (Ue ue in ueDAO.findBy(dico1))
                     {
                         donneesUe.Rows.Add(ue.id, ue.NomPropriete, donneeSemestre[0, index].Value.ToString());
                     }
                     */

                }


            }
        }

        private void validerUe_Click(object sender, EventArgs e)
        {
            MysqlDaoFactory mysql = new MysqlDaoFactory();
            
            UeDAO ueDAO = (UeDAO)mysql.getUeDAO();
            SemestreDAO semDAO = (SemestreDAO)mysql.getSemestreDAO();

            Ue ue = new Ue();
            ue.NomPropriete = nomUe.Text.ToString();

            Dictionary<String, String> dico1 = new Dictionary<string, string>();


            Semestre semestre = semDAO.findByNom(listeSem.SelectedItem.ToString())[0];
            ue.SemestrePropriete = semestre;
              
            ueDAO.create(ue);

            
        }


    }
}
