using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace module_reservation.classes
{
    class FabriqueEmplacement : IFabrique, IFabriqueComplexe<Emplacement, Categorie>
    {
        private String tagName = "emplacement";

        public FabriqueEmplacement() {}

        public  Dictionary<String, Emplacement> getAllXml(Dictionary<String, Categorie> listeCategorie)
        {
            // Récupération de la liste des reservations
            // Utilisation de linq to xml pour charger les noeuds correspondant a chaque numero d'emplacement
            // au lieu de boucler sur le document entier de reservations pour chaque emplacement
            XDocument docu;
            docu = XDocument.Load(getPathXml("listeEmplacementReserve"));
            Dictionary<int ,List<Date>> listDateReserv = new Dictionary<int, List<Date>>();
            
            // Récupération de la liste des emplacements
            //String pathEmplacement = ConfigurationManager.AppSettings["emplacement"];
            Dictionary<String, Emplacement> liste = new Dictionary<String, Emplacement>();
            XmlNodeList nodes = MyXml.getNodeList(getPathXml(tagName), tagName);
           
            for (int i = 0; i < nodes.Count; i++)
            {
                Emplacement emplacement = new Emplacement();
                XmlAttributeCollection coll = nodes[i].Attributes;
                XmlAttribute catAttr = coll["categorie"];
                XmlAttribute num = coll["numero"];
                emplacement.numero = int.Parse(num.InnerXml);
                String cat = catAttr.InnerXml;

                // Ajout de la catégorie correspondante
                Categorie c;
                listeCategorie.TryGetValue(cat, out c);
                emplacement.setCategorie(c);

                // Parcours des noeuds
                XmlNodeList childNodes = nodes[i].ChildNodes;
                foreach (XmlNode n in childNodes)
                {
                    switch (n.Name)
                    {
                        case "type":
                            {
                                object type = n.InnerText;
                                emplacement.type = n.InnerText;
                            }
                            break;
                        case "piece":
                            {
                                int nb = new int();
                                int.TryParse(n.InnerText, out nb);
                                emplacement.nbPiece = nb;
                            }
                            break;
                            // Ici on rempli un hashtable contenant les proprietes non-fixes créer par l'utilisateur
                            // A voir comment sa va marcher pour afficher lol
                        default:
                            {
                                object retour = setOtherProperties(n);
                                emplacement.setPropriete(n.Name, retour);
                            }
                            break;
                            
                    }
                }
                // Permet de boucler uniquement sur une collection restreinte
                XElement root = docu.Root;
                IEnumerable<XElement> collReservation = from m in root.Descendants()
                                                        where m.Attribute("numero").Value == emplacement.numero.ToString()
                                                        select m;
                // Parcours des réservations pour remplir la liste des dates reservé sur chaque emplacement
                foreach (XElement elem in collReservation)
                {
                    String[] entree = new String[3];
                    String[] sortie = new String[3];
                    Char[] ch = new char[] { '/',' ',':' };
                    entree = elem.Attribute("entree").Value.Split(ch);
                    sortie = elem.Attribute("sortie").Value.Split(ch);
                    DateTime premier = new DateTime(int.Parse(entree[2]), int.Parse(entree[1]), int.Parse(entree[0]),
                                        int.Parse(entree[3]), int.Parse(entree[4]), int.Parse(entree[5]));
                    DateTime second = new DateTime(int.Parse(sortie[2]), int.Parse(sortie[1]), int.Parse(sortie[0]),
                                        int.Parse(sortie[3]), int.Parse(sortie[4]), int.Parse(sortie[5]));
                    Date date = new Date(premier, second);
                    // Rajout de la date dans la liste avec controle si le numero d'emplacement est deja utilisé
                    List<Date> tmpListeDate;
                    if (listDateReserv.ContainsKey(emplacement.numero))
                    {
                        listDateReserv.TryGetValue(emplacement.numero, out tmpListeDate);
                        tmpListeDate.Add(date);
                        listDateReserv.Remove(emplacement.numero);
                        listDateReserv.Add(emplacement.numero, tmpListeDate);
                    }
                    else
                    {
                        tmpListeDate = new List<Date>();
                        tmpListeDate.Add(date);
                        listDateReserv.Add(emplacement.numero, tmpListeDate);
                    }
                }

            //    for (int j = 0; j < nodesDate.Count; j++)
            //    {
            //        XmlAttributeCollection collDate = nodesDate[j].Attributes;
            //        XmlAttribute attrNum = collDate["numero"];

            //        // On ne rempli la liste que si la reservation correspond a l'emplacement actuel
            //        if (int.Parse(attrNum.InnerXml) == emplacement.numero)
            //        {
            //            XmlAttribute attrEntree = collDate["entree"];
            //            XmlAttribute attrSortie = collDate["sortie"];
            //            String[] entree = new String[3];
            //            String[] sortie = new String[3];
            //            Char[] ch = new char[] { '/',' ',':' };
            //            entree = attrEntree.InnerXml.Split(ch);
            //            sortie = attrSortie.InnerXml.Split(ch);
            //            DateTime premier = new DateTime(int.Parse(entree[2]), int.Parse(entree[1]), int.Parse(entree[0]),
            //                                int.Parse(entree[3]), int.Parse(entree[4]), int.Parse(entree[5]));
            //            DateTime second = new DateTime(int.Parse(sortie[2]), int.Parse(sortie[1]), int.Parse(sortie[0]),
            //                                int.Parse(sortie[3]), int.Parse(sortie[4]), int.Parse(sortie[5]));
            //            Date date = new Date(premier, second);
            //            // Rajout de la date dans la liste avec controle si le numero d'emplacement est deja utilisé
            //            if (listDateReserv.ContainsKey(emplacement.numero))
            //            {
            //                List<Date> tmpListeDate;
            //                listDateReserv.TryGetValue(emplacement.numero, out tmpListeDate);
            //                tmpListeDate.Add(date);
            //                listDateReserv.Remove(emplacement.numero);
            //                listDateReserv.Add(emplacement.numero, tmpListeDate);
            //            }
            //            else
            //            {
            //                List<Date> tmpListeDate = new List<Date>();
            //                tmpListeDate.Add(date);
            //                listDateReserv.Add(emplacement.numero, tmpListeDate);
            //            }
                        
            //        }
            //    }
                foreach (KeyValuePair<int, List<Date>> t in listDateReserv)
                {
                    if (t.Key == emplacement.numero)
                    {
                        emplacement.addListeDate(t.Value);
                    }
                }
                liste.Add(emplacement.numero.ToString(), emplacement);
            }
            return liste;
        }
       
        public Emplacement getOneXml(string nodeName)
        {
            throw new NotImplementedException();
        }
    }
}
