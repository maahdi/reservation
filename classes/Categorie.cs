using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Categorie
    {
        private String m_name;
        public String name { get { return m_name; } set { m_name = value; } }
        private double m_tarif;
        public double tarif { get { return m_tarif; } set { m_tarif = value; } }
        private int m_places;
        public int places { get { return m_places; } set { m_places = value; } }

        public Categorie()
        {
            m_name = String.Empty;
            m_tarif = (double) 0.0;
            m_places = 0;
        }
    }
}
