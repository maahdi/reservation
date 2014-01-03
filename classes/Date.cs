using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Date
    {
        private Dictionary<String, DateTime> date = new Dictionary<string, DateTime>();

        public Date(DateTime entree, DateTime sortie)
        {
            this.date.Add("entree", entree);
            this.date.Add("sortie", sortie);
        }

        public DateTime getDate(String param)
        {
            DateTime d;
            date.TryGetValue(param, out d);
            return d;
        }

        public override String ToString()
        {
            return this.date["entree"].ToString()+ " - " + this.date["sortie"].ToString();
        }

        public Dictionary<String, DateTime> getDate()
        {
            return date;
        }

        // La méthode calcul l'intervalle entre 2 date
        // ex : si date(23/08/21013 et 30/08/2013)
        // return 6 alors je rajoute + 1 pour rajouter les 2 demi-journée du 23 et 30 
        // (cas reservation camping arrivé 13h départ 11h le jours des dates - rajouter + 2 si sa compte pour des jours entiers -
        // et pour un hotel sa correspond au nombre de nuits : 7 nuits du 23 au 29 pas de nuit le 30)..
        // ex : si date(23/08/2013 et 24/08/2013)
        // return 0; d'ou encore +1

        public int calculDuree()
        {
            TimeSpan ts = getDate("sortie") - getDate("entree");

            //return ts.Days + 1;
            return (int) ts.TotalDays;
        }
    }

    // A utiliser pour trier un tableau de date
    // ComparateurDate comparateur = new ComparateurDate();
    // DateTime[] MonTableauDeDates ;
    // ............
    // Array.Sort(MonTableauDeDates , comparateur );
    class ComparateurDate : IComparer<DateTime>
    {
        int IComparer<DateTime>.Compare(DateTime x, DateTime y)
        {
            if (x < y)
            {
                return -1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
