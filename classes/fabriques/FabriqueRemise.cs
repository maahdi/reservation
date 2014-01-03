using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace module_reservation.classes
{
    class FabriqueRemise : IFabrique, IFabriqueSimple<Remise> 
    {
        private String tagName = "remise";

        public FabriqueRemise() { }

        public Dictionary<String, Remise> getAllXml()
        {

            Dictionary<String, Remise> liste = new Dictionary<String, Remise>();

            XmlNodeList listeRemiseXml = MyXml.getNodeList(getPathXml(tagName), tagName);
            XmlNodeList nodes;
            
            for (int i = 0; i < listeRemiseXml.Count; i++)
            {
                Remise remise = new Remise();
                XmlAttributeCollection collName = listeRemiseXml[i].Attributes;
                XmlAttribute name = collName["name"];
                remise.name = name.InnerXml;
                // récupére les noeuds enfants des périodes
                nodes = listeRemiseXml[i].ChildNodes;
                // Parse les noeuds enfants
                // Les tableaux entree et sortie initialisé aux nombre de noeuds enfants histoire d'être sur qu'ils aient assez
                // de place, à priori les tableaux ne devrait pas contenir énormément de lignes
                // faire une boucle avec pour savoir combien de place requise pour optimiser la mémoire
                // récupération de chaque date d'entrée et de sortie séparément
                String[] premier = new String[nodes.Count];
                String[] dernier = new String[nodes.Count];
                foreach (XmlNode n in nodes)
                {
                    switch (n.Name)
                    {
                        case "duree":
                            {
                                XmlAttributeCollection coll = n.Attributes;
                                XmlAttribute attrPremier = coll["premier"];
                                XmlAttribute attrDernier = coll["dernier"];
                                remise.setDuree(int.Parse(attrPremier.InnerXml), int.Parse(attrDernier.InnerXml));
                            }
                            break;
                        case "pourcentage":
                            {
                                int r = new int();
                                int.TryParse(n.InnerText, out r);
                                remise.remise = r;
                            }
                            break;
                    }
                }
                liste.Add(remise.name, remise);
            }
            return liste;
        }

        public  Remise getOneXml(String nodeName)
        {
            XmlNodeList listeRemiseXml = MyXml.getNodeList(getPathXml(tagName), tagName);
            XmlNodeList nodes;
           
            Remise remise = new Remise();
            for (int i = 0; i < listeRemiseXml.Count; i++)
            {
                XmlAttributeCollection collName = listeRemiseXml[i].Attributes;
                XmlAttribute name = collName["name"];
                if (name.InnerXml == nodeName)
                {
                    remise.name = name.InnerXml;
                    // récupére les noeuds enfants des périodes
                    nodes = listeRemiseXml[i].ChildNodes;
                    // Parse les noeuds enfants
                    // Les tableaux entree et sortie initialisé aux nombre de noeuds enfants histoire d'être sur qu'ils aient assez
                    // de place, à priori les tableaux ne devrait pas contenir énormément de lignes
                    // faire une boucle avec pour savoir combien de place requise pour optimiser la mémoire
                    // récupération de chaque date d'entrée et de sortie séparément
                    String[] premier = new String[nodes.Count];
                    String[] dernier = new String[nodes.Count];
                    foreach (XmlNode n in nodes)
                    {
                        switch (n.Name)
                        {
                            case "duree":
                                {
                                    XmlAttributeCollection coll = n.Attributes;
                                    XmlAttribute attrEntree = coll["premier"];
                                    XmlAttribute attrSortie = coll["dernier"];
                                    remise.setDuree(int.Parse(attrEntree.InnerXml),int.Parse(attrSortie.InnerXml));
                                }
                                break;
                            case "pourcentage":
                                {
                                    float r = new float();
                                    float.TryParse(n.InnerText, out r);
                                    remise.remise = r;
                                }
                                break;
                        }
                    }
                }
            }
            return remise;
        }

    }
}
