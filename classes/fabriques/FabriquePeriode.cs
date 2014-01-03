using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace module_reservation.classes
{
    class FabriquePeriode : IFabrique, IFabriqueSimple<Periode>
    {
        private static String tagName = "periode";

        public Dictionary<String, Periode> getAllXml()
        {

            Dictionary<String, Periode> periodeDict = new Dictionary<String, Periode>();
            
            // Récupération des différentes périodes
            XmlNodeList listePeriodeXml = MyXml.getNodeList(getPathXml(tagName), tagName);
            XmlNodeList nodes;
            // J'enregistre les dates de réservations sur l'année en cours pour l'instant
            // A voir comment faire plus tard (genre changer l'année suivant les demandes de réservations)
            var date = DateTime.Now;
            int year = date.Year;
            // Parse les périodes récupérées
            for (int i = 0; i < listePeriodeXml.Count; i++)
            {
                Periode periode = new Periode();
                XmlAttributeCollection collName = listePeriodeXml[i].Attributes;
                XmlAttribute name = collName["name"];
                periode.name = name.InnerXml;
                // récupére les noeuds enfants des périodes
                nodes = listePeriodeXml[i].ChildNodes;
                // Parse les noeuds enfants
                // Les tableaux entree et sortie initialisé aux nombre de noeuds enfants histoire d'être sur qu'ils aient assez
                // de place, à priori les tableaux ne devrait pas contenir énormément de lignes
                // faire une boucle avec pour savoir combien de place requise pour optimiser la mémoire
                // récupération de chaque date d'entrée et de sortie séparément
                String[] entree = new String[nodes.Count];
                String[] sortie = new String[nodes.Count];
                foreach (XmlNode n in nodes)
                {
                    switch (n.Name)
                    {
                        case "date":
                            {
                                XmlAttributeCollection coll = n.Attributes;
                                XmlAttribute attrEntree = coll["entree"];
                                XmlAttribute attrSortie = coll["sortie"];
                                periode.setDatePeriode(attrEntree.InnerXml, attrSortie.InnerXml);
                            }
                            break;
                        case "tarif":
                            {
                                double tarif = new Double();
                                double.TryParse(n.InnerText, out tarif);
                                periode.tarif = tarif;
                            }
                            break;
                    }
                }
                periodeDict.Add(periode.name, periode);
            }
            return periodeDict;
        }

        public Periode getOneXml(String nodeName)
        {
            XmlNodeList listePeriodeXml = MyXml.getNodeList(getPathXml(tagName), tagName);
            XmlNodeList nodes;
            // J'enregistre les dates de réservations sur l'année en cours pour l'instant
            // A voir comment faire plus tard (genre changer l'année suivant les demandes de réservations)
            var date = DateTime.Now;
            int year = date.Year;
            Periode periode = new Periode();
            // Parse les périodes récupérées
            for (int i = 0; i < listePeriodeXml.Count; i++)
            {
                XmlAttributeCollection collName = listePeriodeXml[i].Attributes;
                XmlAttribute name = collName["name"];
                if (name.InnerXml == nodeName)
                {
                    periode.name = name.InnerXml;
                    // récupére les noeuds enfants des périodes
                    nodes = listePeriodeXml[i].ChildNodes;
                    String[] entree = new String[nodes.Count];
                    String[] sortie = new String[nodes.Count];
                    foreach (XmlNode n in nodes)
                    {
                        switch (n.Name)
                        {
                            case "date":
                                {
                                    XmlAttributeCollection coll = n.Attributes;
                                    XmlAttribute attrEntree = coll["entree"];
                                    XmlAttribute attrSortie = coll["sortie"];
                                    periode.setDatePeriode(attrEntree.InnerXml, attrSortie.InnerXml);
                                }
                                break;
                            case "tarif":
                                {
                                    float tarif = new float();
                                    float.TryParse(n.InnerText, out tarif);
                                    periode.tarif = tarif;
                                }
                                break;
                        }
                    }
                }
            }
            return periode;
        }
    }
}
