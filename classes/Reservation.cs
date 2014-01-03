using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Reservation
    {
        private Emplacement emplacement;
        private Date date;
        private String m_client;
        public String client { get { return m_client; } set { m_client = value; } }
        private DateTime dateReservation;
        private Double cout;
        List<Periode> listPeriodes;

        public Reservation()
        {
            this.emplacement = null;
            this.listPeriodes = new List<Periode>();
            this.dateReservation = DateTime.Now;
            this.m_client = String.Empty;
            this.cout = 0;

        }

        public Date getDate()
        {
            return date;
        }

        public String ToStringPeriode()
        {
            String chaine = "";
            foreach (Periode p in listPeriodes)
            {
                chaine += p.ToString() + " Aux dates : " + p.toStringDates() + "\t";
            }
            return chaine;
        }

        public void saveReservation()
        {

        }

        //public void saveReservation(Emplacement emplacement, Date date)
        //{
        //    setEmplacement(emplacement, date);
        //    this.date = date;
        //}

        public void setEmplacement(Emplacement emplacement, Date date)
        {
            if (emplacement == null)
            {
                this.emplacement = emplacement;
                this.emplacement.addDate(date);
                this.date = date;
            }
            else
            {
                this.emplacement.removeDateReservee(this.date);
                this.emplacement = null;
                this.emplacement = emplacement;
                this.date = null;
                this.date = date;
            }
        }

        public Double tmpCalculCout(Categorie categorie, Date date)
        {
            this.emplacement = new Emplacement(categorie);
            this.date = date;
            Double cout = calculCout();
            emplacement = null;
            this.date = null;
            return cout;

        }

        public Double calculCout()
        {
            int duree = date.calculDuree();
            double cout = emplacement.coutEmplacement();
            Dictionary<String, Periode> periodes = Builder.getListePeriodes();
            Dictionary<String, Remise> remises = Builder.getListeRemises();
            Remise remise = Builder.getFirstRemise();
            foreach (KeyValuePair<String, Periode> p in periodes)
            {
                int nbJourPeriode;
                bool test = p.Value.compareDate(date, out nbJourPeriode);
                if (test)
                {
                    listPeriodes.Add(p.Value);
                    foreach (KeyValuePair<String, Remise> r in remises)
                    {
                        Double[] txAndNbJour;
                        if (r.Value.CalculRemise(nbJourPeriode, out txAndNbJour))
                        {
                            cout += p.Value.tarif * txAndNbJour[0] * txAndNbJour[1];
                            remise.setDureeCalculee((int) txAndNbJour[1]);
                        }
                    }
                }
            }
            remise.initiazeCalculRemise();
            return cout;
            
        }
    }
}
