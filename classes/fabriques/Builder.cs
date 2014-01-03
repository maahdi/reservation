using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class Builder
    {
        private Dictionary<String, Emplacement> listeEmplacements;
        private Dictionary<String, Categorie> listeCategories;
        private static Dictionary<String, Remise> listeRemises;
        private static Dictionary<String, Periode> listePeriodes;
        public bool initialized = false;

        public Builder()
        {
            listeRemises = Fabrique<FabriqueRemise>.getFabrique().getAllXml();
            listePeriodes = Fabrique<FabriquePeriode>.getFabrique().getAllXml();
            listeCategories = Fabrique<FabriqueCategorie>.getFabrique().getAllXml();
            IFabriqueSimple<Emplacement> tmpEmp = new AdaptateurFabriqueComplexe<Emplacement, Categorie>(Fabrique<FabriqueEmplacement>.getFabrique(), listeCategories);
            listeEmplacements = tmpEmp.getAllXml();
            initialized = true;
        }

        public static Dictionary<String, Remise> getListeRemises()
        {
            return listeRemises;
        }

        public void saveReservation(String numEmplacement, Reservation reservation, Date date)
        {
            Emplacement e;
            listeEmplacements.TryGetValue(numEmplacement, out e);
            reservation.setEmplacement(e, date);
            reservation.saveReservation();
        }

        private void ajusteYearPeriode(DateTime date)
        {
            foreach (Periode p in listePeriodes.Values)
            {
                p.setDatePeriode(date.Year);
            }
        }

        public Double calculCoutNewReservation(Date date, String categorie)
        {
            Reservation tmpReservation = new Reservation();
            Categorie cat;
            listeCategories.TryGetValue(categorie, out cat);
            this.ajusteYearPeriode(date.getDate("entree"));
            return tmpReservation.tmpCalculCout(cat, date);
        }

        // Utile pour permettre le calcul du cout d'une réservation en modifiant la valeur de la variable statique
        // dureeCalculee de la classe mère CalculRemise
        public static Remise getFirstRemise()
        {
            Remise remise = new Remise(); ;
            int i = 1;
            foreach (Remise r in listeRemises.Values)
            {
                if (i == 1)
                {
                    remise = null;
                    remise = r;
                    break;
                }
            }
            return remise;
        }

        public static Dictionary<String, Periode> getListePeriodes()
        {
            return listePeriodes;
        }

        public Dictionary<String, Categorie> getListeCategories()
        {
            return listeCategories;
           
        }

        public Categorie getOneCategorie(String name)
        {
            Categorie categorie;
            listeCategories.TryGetValue(name, out categorie);
            return categorie;
        }

        public Dictionary<String, Emplacement> getListeEmplacements()
        {
            if (initialized)
            {
                return listeEmplacements;
            }
            else
            {
                return null;
            }
        }

        public Emplacement getOneEmplacements(String name)
        {
            Emplacement emplacement;
            listeEmplacements.TryGetValue(name, out emplacement);
            return emplacement;
        }

        public List<Emplacement> getListeEmplacementsDisponibles(Date date, String categorie)
        {
            if (initialized)
            {
                List<Emplacement> emplacementDisponible = new List<Emplacement>();
                foreach (KeyValuePair<String, Emplacement> tmpEmplacement in listeEmplacements)
                {
                    String mess;
                    if (tmpEmplacement.Value.getNomCategorie() == categorie.ToString())
                    {
                        if (tmpEmplacement.Value.tryDateDispo(date, out mess))
                        {
                            emplacementDisponible.Add(tmpEmplacement.Value);
                        }
                    }
                }
                return emplacementDisponible;
            }
            else
            {
                return null;
            }
        }

    }
}
