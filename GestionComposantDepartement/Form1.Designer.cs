namespace GestionComposantDepartement
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDiplome = new System.Windows.Forms.Button();
            this.btnCategorie = new System.Windows.Forms.Button();
            this.btnPersonnel = new System.Windows.Forms.Button();
            this.btnUE = new System.Windows.Forms.Button();
            this.panelAffichage = new System.Windows.Forms.Panel();
            this.btnAddCategorie = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nomCategorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfficherPersonnel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelAffichageCategorie = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelAffichage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelAffichageCategorie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnUE);
            this.panel1.Controls.Add(this.btnPersonnel);
            this.panel1.Controls.Add(this.btnCategorie);
            this.panel1.Controls.Add(this.btnDiplome);
            this.panel1.Location = new System.Drawing.Point(5, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 172);
            this.panel1.TabIndex = 0;
            // 
            // btnDiplome
            // 
            this.btnDiplome.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDiplome.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiplome.Image = global::GestionComposantDepartement.Properties.Resources.diplome;
            this.btnDiplome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDiplome.Location = new System.Drawing.Point(7, 23);
            this.btnDiplome.Name = "btnDiplome";
            this.btnDiplome.Size = new System.Drawing.Size(166, 109);
            this.btnDiplome.TabIndex = 0;
            this.btnDiplome.Text = "Diplôme";
            this.btnDiplome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDiplome.UseVisualStyleBackColor = false;
            this.btnDiplome.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCategorie
            // 
            this.btnCategorie.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCategorie.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorie.Image = global::GestionComposantDepartement.Properties.Resources.categorie;
            this.btnCategorie.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCategorie.Location = new System.Drawing.Point(285, 23);
            this.btnCategorie.Name = "btnCategorie";
            this.btnCategorie.Size = new System.Drawing.Size(166, 109);
            this.btnCategorie.TabIndex = 1;
            this.btnCategorie.Text = "Catégorie";
            this.btnCategorie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategorie.UseVisualStyleBackColor = false;
            this.btnCategorie.Click += new System.EventHandler(this.btnCategorie_Click);
            // 
            // btnPersonnel
            // 
            this.btnPersonnel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPersonnel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonnel.Image = global::GestionComposantDepartement.Properties.Resources.personnel;
            this.btnPersonnel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPersonnel.Location = new System.Drawing.Point(561, 23);
            this.btnPersonnel.Name = "btnPersonnel";
            this.btnPersonnel.Size = new System.Drawing.Size(166, 109);
            this.btnPersonnel.TabIndex = 2;
            this.btnPersonnel.Text = "Personnel";
            this.btnPersonnel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPersonnel.UseVisualStyleBackColor = false;
            this.btnPersonnel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUE
            // 
            this.btnUE.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUE.Image = global::GestionComposantDepartement.Properties.Resources.ue;
            this.btnUE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUE.Location = new System.Drawing.Point(808, 23);
            this.btnUE.Name = "btnUE";
            this.btnUE.Size = new System.Drawing.Size(166, 109);
            this.btnUE.TabIndex = 3;
            this.btnUE.Text = "UE";
            this.btnUE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUE.UseVisualStyleBackColor = false;
            // 
            // panelAffichage
            // 
            this.panelAffichage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelAffichage.Controls.Add(this.panelAffichageCategorie);
            this.panelAffichage.Location = new System.Drawing.Point(5, 243);
            this.panelAffichage.Name = "panelAffichage";
            this.panelAffichage.Size = new System.Drawing.Size(997, 326);
            this.panelAffichage.TabIndex = 1;
            // 
            // btnAddCategorie
            // 
            this.btnAddCategorie.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddCategorie.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategorie.Location = new System.Drawing.Point(17, 8);
            this.btnAddCategorie.Name = "btnAddCategorie";
            this.btnAddCategorie.Size = new System.Drawing.Size(128, 23);
            this.btnAddCategorie.TabIndex = 0;
            this.btnAddCategorie.Text = "+ Ajouter Catégorie";
            this.btnAddCategorie.UseVisualStyleBackColor = false;
            this.btnAddCategorie.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomCategorie,
            this.ModifUE,
            this.AfficherPersonnel});
            this.dataGridView1.Location = new System.Drawing.Point(17, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(950, 200);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nomCategorie
            // 
            this.nomCategorie.HeaderText = "Nom categorie";
            this.nomCategorie.Name = "nomCategorie";
            // 
            // ModifUE
            // 
            this.ModifUE.HeaderText = "ModifierUE";
            this.ModifUE.Name = "ModifUE";
            // 
            // AfficherPersonnel
            // 
            this.AfficherPersonnel.HeaderText = "Afficher Personnel";
            this.AfficherPersonnel.Name = "AfficherPersonnel";
            // 
            // panelAffichageCategorie
            // 
            this.panelAffichageCategorie.Controls.Add(this.dataGridView1);
            this.panelAffichageCategorie.Controls.Add(this.btnAddCategorie);
            this.panelAffichageCategorie.Location = new System.Drawing.Point(7, 3);
            this.panelAffichageCategorie.Name = "panelAffichageCategorie";
            this.panelAffichageCategorie.Size = new System.Drawing.Size(983, 313);
            this.panelAffichageCategorie.TabIndex = 2;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 641);
            this.Controls.Add(this.panelAffichage);
            this.Controls.Add(this.panel1);
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panelAffichage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelAffichageCategorie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDiplome;
        private System.Windows.Forms.Button btnPersonnel;
        private System.Windows.Forms.Button btnCategorie;
        private System.Windows.Forms.Button btnUE;
        private System.Windows.Forms.Panel panelAffichage;
        private System.Windows.Forms.Button btnAddCategorie;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomCategorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfficherPersonnel;
        private System.Windows.Forms.Panel panelAffichageCategorie;
    }
}

