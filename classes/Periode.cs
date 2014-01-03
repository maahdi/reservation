using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Periode
    {
        private List<Date> dates = new List<Date>();
        private double m_tarif;
        public double tarif { get { return m_tarif; } set { m_tarif = value; } }
        private String m_name;
        public String name { get { return m_name; } set { m_name = value; } }
        private String[] datesString = new String[2];
        private int indexDate;

        public Periode()
        {
        }

        private void resetListeDates()
        {
            dates.Clear();
        }

        // Methode pour ajuster les dates des périodes aux dates de reservation formulées par le client
        public void setDatePeriode(int year)
        {
            foreach (Date d in this.dates)
            {
                DateTime [] dates = this.defineYearDate(new DateTime(year, d.getDate("entree").Month, d.getDate("entree").Day),
                                                        new DateTime(year, d.getDate("sortie").Month, d.getDate("sortie").Day));
                this.dates.Remove(d);
                this.dates.Add(new Date(dates[0], dates[1]));
            }
        }

        // year[0] = date entree , year[1] = date sortie
        public void setDatePeriode(String entree, String sortie)
        {
            int year = DateTime.Now.Year;
            // Le délimiteur pour récupérer le mois et le jour des string
            Char [] c = new char[]{'/'};
            String[] e = new String[2];
            e = entree.Split(c);
            String [] s = new String[2];
            s = sortie.Split(c);
            DateTime [] dates = new DateTime[2];
            dates = this.defineYearDate(new DateTime(year, int.Parse(e[1]), int.Parse(e[0])),new DateTime(year, int.Parse(s[1]), int.Parse(s[0])));
            this.dates.Add(new Date(dates[0], dates[1]));
            indexDate++;
        }

        // si entree = 01/11/2013 et sortie = 01/04/2013
        // comme periode 1 vu que a la base instancie les 2 dates avec l'année actuelle
        // sortie doit être égale à 01/04/2014
        // retour DateTime[0] = entree
        //        DateTime[1] = sortie
        private DateTime[] defineYearDate(DateTime entree, DateTime sortie)
        {
            DateTime[] dates = new DateTime[2];

            if (entree.CompareTo(sortie) > 0 && sortie.CompareTo(DateTime.Now) < 0)
            {
                dates[0] = entree.AddHours(13);
                dates[1] = new DateTime(sortie.Year + 1, sortie.Month, sortie.Day).AddHours(11);
            }
            else
            {
                dates[0] = entree.AddHours(13);
                dates[1] = sortie.AddHours(10);
            }
            return dates;

        }

        // Méthode qui vérifie les dates pour définir le nombre de jours sur cette période
        public bool compareDate(Date date, out int nbJours)
        {
            bool retour = new bool();
            int calcul = new int();
            int nb = dates.Count;
            DateTime[] entree = new DateTime[nb];
            DateTime[] sortie = new DateTime[nb];
            int i = 0;
            foreach (Date d in dates)
            {
                entree[i] = d.getDate("entree");
                sortie[i] = d.getDate("sortie");
                i++;
            }
            ComparateurDate cd = new ComparateurDate();
            Array.Sort(entree, cd);
            Array.Sort(sortie, cd);
            // Parcours des dates d'une même periode
            // ces dates ne doivent pas se suivre donc test simples sur les dates d'une valeur du dictionnaire dates
            for (int j = 0; j < nb; j++)
            {
                // Periode du 01/01/2014 au 31/01/2014
                //
                // Comprise
                // date 02/01/2014 - 23/01/2014
                if (date.getDate("entree").CompareTo(entree[j]) >= 0 && date.getDate("sortie").CompareTo(sortie[j]) <= 0
                    && date.getDate("entree").CompareTo(sortie[j]) <= 0 && date.getDate("sortie").CompareTo(entree[j]) >= 0)
                {
                    calcul = date.calculDuree();
                    retour = true;
                    break;
                }
                // Entree antérieure
                // date 15/12/2013 - 15/01/2014
                else if (date.getDate("entree").CompareTo(entree[j]) < 0 && date.getDate("sortie").CompareTo(sortie[j]) <= 0
                    && date.getDate("sortie").CompareTo(entree[j]) >=0)
                {
                    TimeSpan ts = date.getDate("sortie") - entree[j];
                    calcul = (int)ts.TotalDays + 1;
                    retour = true;
                    break;
                }
                // Sortie postérieure
                // date 15/01/2014 - 15/02/2014
                else if (date.getDate("entree").CompareTo(entree[j]) >= 0 && date.getDate("sortie").CompareTo(sortie[j]) > 0
                    && date.getDate("entree").CompareTo(sortie[j]) <= 0)
                {
                    TimeSpan ts = sortie[j] - date.getDate("entree");
                    calcul = (int)ts.TotalDays + 1;
                    retour = true;
                    break;
                }
                // Entree antérieure et sortie postérieure
                // date 15/12/2014 - 15/02/2014
                else if (date.getDate("entree").CompareTo(entree[j]) < 0 && date.getDate("sortie").CompareTo(sortie[j]) > 0)
                {
                    TimeSpan ts = sortie[j] - entree[j];
                    calcul = (int) ts.TotalDays +1 ;
                    retour = true;
                    break;
                }
                else
                {
                    calcul = 0;
                    retour = false;
                }
            }
            nbJours = calcul;
            if (retour)
                return true;
            else
                return false;
        }

        public override String ToString()
        {
            return name;
        }

        public String toStringDates()
        {
            String concat = String.Empty;
            int j = 0;
            for (int i = 0; i < indexDate; i++)
            {
                if (j > 0)
                {
                    concat += " et "+this.dates[i].ToString();
                }
                else
                {
                    concat += this.dates[i].ToString();
                }
                j++;
            }
            return concat;
        }
        
    }
}
