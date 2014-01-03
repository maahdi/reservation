using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using module_reservation.classes;

namespace module_reservation
{
    public partial class ReservationForm : Form
    {
        private Builder builder;

        public ReservationForm()
        {
            builder = new Builder();
            //initializeEmplacements();
            InitializeComponent();
        }
        // Garder pour faire des tests affichage
        private void initializeEmplacements()
        {
            Emplacement e = builder.getOneEmplacements("110");
            Reservation res = new Reservation();
            Date date = new Date(new DateTime(2013, 09, 07), new DateTime(2013, 09, 08));
            res.setEmplacement(e, date);
            double c = res.calculCout();
            MessageBox.Show("Le cout pour " + res.getDate().calculDuree() + " jours est de : " + c + "\t pour la periode : " + res.ToStringPeriode() + "\t Reservation Aux dates :" + date.ToString());
        }

        private void rechercherButton_Click(object sender, EventArgs e)
        {
            listEmplacement.Items.Clear();
            Date date = new Date(dateTimePicker1.Value.Date.AddHours(11), dateTimePicker2.Value.Date.AddHours(13));
            //dureeSejour.Text = date.calculDuree().ToString();
            //showLabelDuree();
            object categorie = listCategorie.SelectedItem;
            List<Emplacement> emplacementsDisponible = builder.getListeEmplacementsDisponibles(date, categorie.ToString());
            foreach (Emplacement tmpEmplacementDispo in emplacementsDisponible)
            {
                listEmplacement.Items.Add(tmpEmplacementDispo.numero);
            }
            listEmplacement.Visible = true;
            label_listEmplacement.Visible = true;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            
            int i = 0;
            Dictionary<String, Categorie> categories = builder.getListeCategories();
            int nb = categories.Count;
            String[] catTab = new String[nb];
            foreach (KeyValuePair<String, Categorie> cat in categories)
            {
                catTab[i] = cat.Value.name;
                i++;
            }
            listCategorie.Items.AddRange(catTab);
            listCategorie.SelectedIndex = -1;
            // changement de date après initialisation de la liste des catégories
            // les events change sur datetimepicker utilise cette liste
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Now.AddDays(1);
        }

        private void selectCategorie(object sender, EventArgs e)
        {
            majCalculCout();
        }

        private void selectionPremiereDate(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            majDuree();
            majCalculCout();
            listEmplacement.Items.Clear();
        }

        private void resetSearch(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            listCategorie.SelectedIndex = -1;
            listEmplacement.Items.Clear();
            listEmplacement.Visible = false;
            label_listEmplacement.Visible = false;
            button_reserver.Visible = false;
            majDuree();
            majCalculCout();
        }

        private void selectionSecondeDate(object sender, EventArgs e)
        {
            majDuree();
            majCalculCout();
            listEmplacement.Items.Clear();
        }

        private void majDuree()
        {
            Date date = getSelectedDate();
            dureeSejour.Text = date.calculDuree().ToString();
        }

        private Date getSelectedDate()
        {
            Date date = new Date(dateTimePicker1.Value.AddHours(11), dateTimePicker2.Value.AddHours(13));
            return date;
        }

        private void majCalculCout()
        {
            if (listCategorie.SelectedItem != null)
            {
                Object s = listCategorie.SelectedItem;
                Date date = getSelectedDate();
                tarif.Text = builder.calculCoutNewReservation(date, s.ToString()).ToString();
            }
            else
            {
                tarif.Text = "0";
            }
            
        }

        private void saveReservation(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrement de la reservation.", "Souhaitez-vous continuez l'action :", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }

        private void selectionEmplacement(object sender, EventArgs e)
        {
            button_reserver.Visible = true;
        }

       
    }
}
