using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Emplacement : XmlSaveEmplacement
    {
        private List<Date> dateReservation;
        private int m_numero;
        private Hashtable proprietes = new Hashtable();
        public int numero { get { return m_numero; } set { m_numero = value; } }
        private String m_type;
        public String type { get { return m_type; } set { m_type = value; } }
        private int m_nbPiece;
        public int nbPiece { get { return m_nbPiece; } set { m_nbPiece = value; } }
        private Categorie categorie;

        public Emplacement() { }

        public void save()
        {
            base.save(this);
        }

        public int getNumberPropriete()
        {
            return proprietes.Count;
        }

        public ICollection getListePropriete()
        {
            ICollection prop =  proprietes.Keys;
            return prop;
        }

        public void removeDateReservee(Date date)
        {
            dateReservation.Remove(date);
        }

        public Emplacement(Categorie categorie)
        {
            m_numero = 0;
            m_type = String.Empty;
            this.categorie = categorie;
        }

        public void setPropriete(String name, object value)
        {
            proprietes.Add(name, value);
        }

        public void modifPropriete(String name, object value)
        {
            proprietes[name] = value;
        }

        public void getPropriete(String name, out object value)
        {
            value = proprietes[name];
        }


        public void setPropriete(String name, String value)
        {
            proprietes.Add(name, value);
        }

        public String getNomCategorie()
        {
            return categorie.name;
        }

        public void setCategorie(Categorie categorie)
        {
            this.categorie = categorie;
        }

        public void addListeDate(List<Date> date)
        {
            this.dateReservation = date;
        }

        public void addDate(Date date)
        {
            dateReservation.Add(date);
        }

        public override string ToString()
        {
            String chaine = String.Empty;
            chaine = "Emplacement n°" + m_numero + " qui a " + m_nbPiece + " pièce !";
            chaine += "\rAux dates :\r";
            int i = 1;
            foreach (Date d in dateReservation)
            {
                chaine += i + " : " + d.ToString()+"\r";
                i++;
            }
            return chaine;
        }

        public bool tryDateDispo(Date date, out String mess)
        {
            if (dateReservation != null)
            {
                int nb = dateReservation.Count;
                DateTime[] entree = new DateTime[nb];
                DateTime[] sortie = new DateTime[nb];
                int i = 0;
                foreach (Date d in dateReservation)
                {
                    entree[i] = d.getDate("entree");
                    sortie[i] = d.getDate("sortie");
                    i++;
                }
                ComparateurDate cd = new ComparateurDate();
                Array.Sort(entree, cd);
                Array.Sort(sortie, cd);

                bool test = new Boolean();
                mess = String.Empty;
                for (int j = 0; j < nb; j++)
                {
                    // si < 0 la date en paramètre est supérieure, si > 0 la date en paramètre est inférieure
                    // Test d'abord si les dates rentrées sont les deux antérieures aux dates des réservations deja effectuées
                    if (date.getDate("entree").CompareTo(entree[j]) < 0 && date.getDate("sortie").CompareTo(entree[j]) <= 0 && date.getDate("entree").CompareTo(DateTime.Now.Subtract(new TimeSpan(DateTime.Now.Hour,0,0))) < 0)
                    {
                        //Date rentrée pas bonne car antérieure à la date du jour
                        mess = "Date d'entrée antérieure à la date actuelle";
                        test = false;
                        break;
                    }
                    else if (date.getDate("entree").CompareTo(entree[j]) < 0 && date.getDate("sortie").CompareTo(entree[j]) <= 0 
                            && date.getDate("entree").CompareTo(DateTime.Now.Subtract(new TimeSpan(DateTime.Now.Hour,0,0))) > 0)
                    {
                        mess = "Bonne date second if !";
                        test = true;
                        break;
                    }
                    // on compare ensuite si la date d'entrée est supérieure ou égale à la date de sortie actuelle
                    // et que la date de sortie est inférieure ou égales à la date d'entrée suivante
                    else if (date.getDate("entree").CompareTo(sortie[j]) >= 0 && date.getDate("sortie").CompareTo(entree[j + 1]) <= 0)
                    {
                        // Bonnes dates
                        mess = "Bonne date troisième if !!";
                        test = true;
                        break;
                    }
                    else
                    {
                        mess = "Dates non disponibles";
                        test = false;
                    }
                    // Test pour sortir de la boucle quand la date de sortie demandé dépasse la date d'entrée
                    // des date de réservations sinon prochain tour la dispo sera bonne vu que les 2 dates seront inférieures
                    // obligatoirement aux dates recherchées
                    if (date.getDate("sortie").Year == entree[j].Year && date.getDate("sortie").Month == entree[j].Month && date.getDate("sortie").Day > entree[j].Day)
                    {
                        mess = "la date de sortie est supérieure à la dernière date parcouru";
                        test = false;
                        break;
                    }
                    // On test ensuite quelles dates sont valides pour donner les dates de dispo
                    //else if (date.getDate("entree").CompareTo(sortie[j]) < 0 && date.getDate("sortie").CompareTo(entree[j + 1]) <= 0)
                    //{
                    //    // new date(sortie[j], date.getDate("sortie"));
                    //}
                    //else if (date.getDate("entree").CompareTo(sortie[j]) >= 0 && date.getDate("sortie").CompareTo(entree[j+1]) > 0)
                    //{
                    //    // new date(date.getDate("entree"),entree[j+1]);
                    //}
                    mess += "\n Compteur = " + j + "\n Dates : " + entree[j] + " - " + sortie[j];
                }
                if (test)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                mess = "Pas de date de réservée pour cet emplacement";
                return true;
            }
           
        }

        public double coutEmplacement()
        {
            return categorie.tarif;
        }
    }
}
