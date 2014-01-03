using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Remise : CalculRemise
    {
        private double m_tauxRemise;
        // m_taux remise vaudra 0.95 si 5% de remise
        // plus qu'a multiplier le cout directement avec remise
        public double remise { set { m_tauxRemise = (100 - value) / 100; } get { return m_tauxRemise; } }
        // ex : de 1 a 7 jours remise de 5%.
        private Duree duree;
        private String m_name;
        public String name { get { return m_name; } set { m_name = value; } }

        public Remise(int premier, int dernier) 
        {
            this.duree = new Duree(premier, dernier);
        }

        public Remise() { }

        public void setDuree(int premier, int dernier)
        {
            this.duree = new Duree(premier, dernier);
        }

        //public new void initiateCalculRemise()
        //{
        //    base.initiateCalculRemise();
        //}

        //public new void setDureeCalculee(int duree)
        //{
        //    base.setDureeCalculee(duree);
        //}

        public bool CalculRemise(int dureePeriode, out double [] txANDnbJour)
        {
            txANDnbJour = new Double[2];
            if (dureeCalculee == 0)
            {
                // ex : 
                // A faire dans une boucle de la classe reservation
                // duree = 12
                // duree remise = de 1 a 7
                // return true , out nbJour = 7 -> calcul 7 jours * coutjournee * m_tauxRemise
                // duree remise = de 8 a 14
                // return true , out nbJour = 5 -> calcul 4 jours * coutjournee * m_tauxRemise
                if (dureePeriode >= this.duree.premier && dureePeriode <= this.duree.dernier)
                {
                    // + 1 pour prendre en compte le premier jour enlever lors de la soustraction
                    // duree = 6
                    // duree remise de 1 a 7
                    // return true, out nbJour = 6 - 1 = 5 + 1 = 6 jours
                    txANDnbJour[1] = dureePeriode - this.duree.premier + 1;
                    txANDnbJour[0] = m_tauxRemise;
                    return true;
                }
                else if (dureePeriode > this.duree.premier && dureePeriode > this.duree.dernier)
                {
                    txANDnbJour[1] = this.duree.dernier - this.duree.premier + 1;
                    txANDnbJour[0] = m_tauxRemise;
                    return true;
                }
                else
                {
                    txANDnbJour = null;
                    return false;
                }
            }
            else
            {
                if (dureeCalculee >= this.duree.premier && dureePeriode <= this.duree.dernier)
                {
                    // + 1 pour prendre en compte le premier jour enlever lors de la soustraction
                    // duree = 6
                    // duree remise de 1 a 7
                    // return true, out nbJour = 6 - 1 = 5 + 1 = 6 jours
                    if (dureePeriode > dureeCalculee)
                    {
                        txANDnbJour[1] = dureePeriode - dureeCalculee + 1;
                    }
                    else
                    {
                        txANDnbJour[1] = dureeCalculee - dureePeriode;
                    }
                    
                    txANDnbJour[0] = m_tauxRemise;
                    return true;
                }
                else if (dureeCalculee >= this.duree.premier && dureePeriode > this.duree.dernier)
                {
                    txANDnbJour[1] = this.duree.dernier - dureeCalculee + 1;
                    txANDnbJour[0] = m_tauxRemise;
                    return true;
                }
                else if (dureeCalculee < this.duree.premier && dureePeriode > this.duree.premier && dureePeriode > this.duree.dernier)
                {
                    txANDnbJour[1] = this.duree.dernier - this.duree.premier + 1;
                    txANDnbJour[0] = m_tauxRemise;
                    return true;
                }
                else if (dureeCalculee < this.duree.premier && dureePeriode >= this.duree.premier && dureePeriode <= this.duree.dernier)
                {
                    txANDnbJour[1] = dureePeriode - this.duree.premier + 1;
                    txANDnbJour[0] = m_tauxRemise;
                    return true;
                }
                else
                {
                    txANDnbJour = null;
                    return false;
                }
            }
        }

        public override string ToString()
        {
            return "Coefficient de remise :" + m_tauxRemise;
        }
    }

    class Duree
    {
        private int m_premier;
        public int premier { get { return m_premier; } set { m_premier = value; } }
        private int m_dernier;
        public int dernier  { get { return m_dernier; } set { m_dernier = value; } }

        public Duree(int premier, int dernier)
        {
            this.premier = premier;
            this.dernier = dernier;
        }
    }
}
