using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace module_reservation.classes
{
    class FabriqueCategorie : IFabrique, IFabriqueSimple<Categorie> 
    {
        private String tagName = "categorie";
        private Categorie categorie;

        public Dictionary<String, Categorie> getAllXml()
        {
            Dictionary<String, Categorie> liste = new Dictionary<String, Categorie>();
            XmlNodeList nodes = MyXml.getNodeList(getPathXml(tagName), tagName);
            for (int i = 0; i < nodes.Count; i++)
            {
                categorie = new Categorie();
                XmlAttributeCollection collName = nodes[i].Attributes;
                XmlAttribute name = collName["name"];
                categorie.name = name.InnerXml;
                XmlNodeList nodesList = nodes[i].ChildNodes;
                foreach (XmlNode n in nodesList)
                {
                    switch (n.Name)
                    {
                        case "places":
                            {
                                int places;
                                int.TryParse(n.InnerText, out places);
                                categorie.places = places;
                            }
                            break;
                        case "tarif":
                            {
                                double tarif;
                                double.TryParse(n.InnerText, out tarif);
                                categorie.tarif = tarif;
                            }
                            break;
                    }
                }
                liste.Add(categorie.name, categorie);
            }
            return liste;
        }

        public Categorie getOneXml(String nodeName)
        {
            XmlNodeList nodes = MyXml.getNodeList(getPathXml(tagName), tagName);
            Categorie categorie = new Categorie();
            for (int i = 0; i < nodes.Count; i++)
            {
               
                XmlAttributeCollection collName = nodes[i].Attributes;
                XmlAttribute name = collName["name"];
                if (name.InnerXml == nodeName)
                {
                    categorie.name = name.InnerXml;
                    foreach (XmlNode n in nodes)
                    {
                        switch (n.Name)
                        {
                            case "places":
                                {
                                    int places;
                                    int.TryParse(n.InnerText, out places);
                                    categorie.places = places;
                                }
                                break;
                            case "tarif":
                                {
                                    float tarif;
                                    float.TryParse(n.InnerText, out tarif);
                                    categorie.tarif = tarif;
                                }
                                break;
                        }
                    }
                }
            }
            return categorie;
        }

    }
}
