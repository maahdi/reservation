namespace module_reservation
{
    partial class ReservationForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rechercherButton = new System.Windows.Forms.Button();
            this.label_picker1 = new System.Windows.Forms.Label();
            this.label_picker2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.selection = new System.Windows.Forms.Panel();
            this.tarif = new System.Windows.Forms.Label();
            this.label_listCategorie = new System.Windows.Forms.Label();
            this.label_tarif = new System.Windows.Forms.Label();
            this.label_dureeSejour = new System.Windows.Forms.Label();
            this.dureeSejour = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listCategorie = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.affichage = new System.Windows.Forms.Panel();
            this.button_reserver = new System.Windows.Forms.Button();
            this.label_listEmplacement = new System.Windows.Forms.Label();
            this.listEmplacement = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.selection.SuspendLayout();
            this.affichage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 48);
            this.dateTimePicker1.MinDate = new System.DateTime(2013, 8, 20, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.selectionPremiereDate);
            // 
            // rechercherButton
            // 
            this.rechercherButton.Location = new System.Drawing.Point(37, 231);
            this.rechercherButton.Name = "rechercherButton";
            this.rechercherButton.Size = new System.Drawing.Size(75, 23);
            this.rechercherButton.TabIndex = 1;
            this.rechercherButton.Text = "Rechercher";
            this.rechercherButton.UseVisualStyleBackColor = true;
            this.rechercherButton.Click += new System.EventHandler(this.rechercherButton_Click);
            // 
            // label_picker1
            // 
            this.label_picker1.AutoSize = true;
            this.label_picker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_picker1.Location = new System.Drawing.Point(31, 23);
            this.label_picker1.Name = "label_picker1";
            this.label_picker1.Size = new System.Drawing.Size(77, 13);
            this.label_picker1.TabIndex = 2;
            this.label_picker1.Text = "Date d\'entrée :";
            // 
            // label_picker2
            // 
            this.label_picker2.AutoSize = true;
            this.label_picker2.Location = new System.Drawing.Point(31, 87);
            this.label_picker2.Name = "label_picker2";
            this.label_picker2.Size = new System.Drawing.Size(79, 13);
            this.label_picker2.TabIndex = 3;
            this.label_picker2.Text = "Date de sortie :";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(37, 115);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.selectionSecondeDate);
            // 
            // selection
            // 
            this.selection.Controls.Add(this.tarif);
            this.selection.Controls.Add(this.label_listCategorie);
            this.selection.Controls.Add(this.label_tarif);
            this.selection.Controls.Add(this.label_dureeSejour);
            this.selection.Controls.Add(this.dureeSejour);
            this.selection.Controls.Add(this.button1);
            this.selection.Controls.Add(this.listCategorie);
            this.selection.Controls.Add(this.panel2);
            this.selection.Controls.Add(this.label_picker1);
            this.selection.Controls.Add(this.dateTimePicker2);
            this.selection.Controls.Add(this.dateTimePicker1);
            this.selection.Controls.Add(this.label_picker2);
            this.selection.Controls.Add(this.rechercherButton);
            this.selection.Location = new System.Drawing.Point(3, 2);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(301, 415);
            this.selection.TabIndex = 5;
            // 
            // tarif
            // 
            this.tarif.AutoSize = true;
            this.tarif.Location = new System.Drawing.Point(81, 318);
            this.tarif.Name = "tarif";
            this.tarif.Size = new System.Drawing.Size(13, 13);
            this.tarif.TabIndex = 5;
            this.tarif.Text = "0";
            // 
            // label_listCategorie
            // 
            this.label_listCategorie.AutoSize = true;
            this.label_listCategorie.Location = new System.Drawing.Point(31, 159);
            this.label_listCategorie.Name = "label_listCategorie";
            this.label_listCategorie.Size = new System.Drawing.Size(142, 13);
            this.label_listCategorie.TabIndex = 9;
            this.label_listCategorie.Text = "Selectionnez une catégorie :";
            // 
            // label_tarif
            // 
            this.label_tarif.AutoSize = true;
            this.label_tarif.Location = new System.Drawing.Point(38, 318);
            this.label_tarif.Name = "label_tarif";
            this.label_tarif.Size = new System.Drawing.Size(37, 13);
            this.label_tarif.TabIndex = 4;
            this.label_tarif.Text = "Tarif : ";
            // 
            // label_dureeSejour
            // 
            this.label_dureeSejour.AutoSize = true;
            this.label_dureeSejour.Location = new System.Drawing.Point(39, 283);
            this.label_dureeSejour.Name = "label_dureeSejour";
            this.label_dureeSejour.Size = new System.Drawing.Size(73, 13);
            this.label_dureeSejour.TabIndex = 6;
            this.label_dureeSejour.Text = "Durée séjour :";
            // 
            // dureeSejour
            // 
            this.dureeSejour.AutoSize = true;
            this.dureeSejour.Location = new System.Drawing.Point(118, 283);
            this.dureeSejour.Name = "dureeSejour";
            this.dureeSejour.Size = new System.Drawing.Size(13, 13);
            this.dureeSejour.TabIndex = 7;
            this.dureeSejour.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "resetSearch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.resetSearch);
            // 
            // listCategorie
            // 
            this.listCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listCategorie.FormattingEnabled = true;
            this.listCategorie.Location = new System.Drawing.Point(34, 185);
            this.listCategorie.MaxDropDownItems = 3;
            this.listCategorie.Name = "listCategorie";
            this.listCategorie.Size = new System.Drawing.Size(121, 21);
            this.listCategorie.TabIndex = 7;
            this.listCategorie.SelectionChangeCommitted += new System.EventHandler(this.selectCategorie);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(307, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 415);
            this.panel2.TabIndex = 6;
            // 
            // affichage
            // 
            this.affichage.Controls.Add(this.button_reserver);
            this.affichage.Controls.Add(this.label_listEmplacement);
            this.affichage.Controls.Add(this.listEmplacement);
            this.affichage.Controls.Add(this.monthCalendar1);
            this.affichage.Location = new System.Drawing.Point(310, 2);
            this.affichage.Name = "affichage";
            this.affichage.Size = new System.Drawing.Size(550, 415);
            this.affichage.TabIndex = 6;
            // 
            // button_reserver
            // 
            this.button_reserver.Location = new System.Drawing.Point(330, 239);
            this.button_reserver.Name = "button_reserver";
            this.button_reserver.Size = new System.Drawing.Size(95, 25);
            this.button_reserver.TabIndex = 3;
            this.button_reserver.Text = "Réserver";
            this.button_reserver.UseVisualStyleBackColor = true;
            this.button_reserver.Visible = false;
            this.button_reserver.Click += new System.EventHandler(this.saveReservation);
            // 
            // label_listEmplacement
            // 
            this.label_listEmplacement.AutoSize = true;
            this.label_listEmplacement.Location = new System.Drawing.Point(323, 23);
            this.label_listEmplacement.Name = "label_listEmplacement";
            this.label_listEmplacement.Size = new System.Drawing.Size(131, 13);
            this.label_listEmplacement.TabIndex = 2;
            this.label_listEmplacement.Text = "Emplacements disponibles";
            this.label_listEmplacement.Visible = false;
            // 
            // listEmplacement
            // 
            this.listEmplacement.FormattingEnabled = true;
            this.listEmplacement.Location = new System.Drawing.Point(326, 45);
            this.listEmplacement.Name = "listEmplacement";
            this.listEmplacement.Size = new System.Drawing.Size(189, 147);
            this.listEmplacement.TabIndex = 1;
            this.listEmplacement.Visible = false;
            this.listEmplacement.SelectedIndexChanged += new System.EventHandler(this.selectionEmplacement);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.monthCalendar1.Location = new System.Drawing.Point(53, 23);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // Reservation_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 418);
            this.Controls.Add(this.affichage);
            this.Controls.Add(this.selection);
            this.Name = "Reservation_form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.selection.ResumeLayout(false);
            this.selection.PerformLayout();
            this.affichage.ResumeLayout(false);
            this.affichage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button rechercherButton;
        private System.Windows.Forms.Label label_picker1;
        private System.Windows.Forms.Label label_picker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel selection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel affichage;
        private System.Windows.Forms.ComboBox listCategorie;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listEmplacement;
        private System.Windows.Forms.Label label_listEmplacement;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label tarif;
        private System.Windows.Forms.Label label_tarif;
        private System.Windows.Forms.Label dureeSejour;
        private System.Windows.Forms.Label label_dureeSejour;
        private System.Windows.Forms.Label label_listCategorie;
        private System.Windows.Forms.Button button_reserver;
    }
}

