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
    // Contient la méthode save spécifique aux objets emplacements
    // la classe emplacement hérite de XmlEmplacement pour avoir accès à la méthode
    abstract class XmlSaveEmplacement : XmlSave<Emplacement>
    {
        public override void save(Emplacement emplacement)
        {
            // False = create, true = update
            // bool updateOrCreate = false;
            XDocument docu = XDocument.Load(IFabrique.getPathXml("emplacement"));
            IEnumerable<XElement> elem = from m in docu.Root.Descendants("emplacement")
                                          where m.Attribute("numero").Value == emplacement.numero.ToString()
                                          select m;
            if (elem.Count() > 0)
            {
                foreach (XElement e in elem)
                {
                    e.Attribute("numero").SetValue(emplacement.numero.ToString());
                    IEnumerable<XElement> childNodes = e.Descendants();
                    int i = 0;
                    String[] propName = new String[emplacement.getNumberPropriete()];
                    foreach (XElement n in childNodes)
                    {
                        switch (n.Name.ToString())
                        {
                            case "type":
                                {
                                    n.SetValue(emplacement.type);
                                }
                                break;
                            case "piece":
                                {
                                    n.SetValue(emplacement.nbPiece.ToString());
                                }
                                break;
                            default:
                                {
                                    if (!propName.Contains(n.Name.ToString()))
                                    {
                                        propName[i] = n.Name.ToString();
                                        i++;
                                        Object o;
                                        emplacement.getPropriete(n.Name.ToString(), out o);
                                        n.SetValue(emplacement.modifToString(o));
                                    }
                                }
                                break;
                        }
                        if (i < emplacement.getNumberPropriete())
                        {
                            ICollection proprietes = emplacement.getListePropriete();
                            foreach (String s in proprietes)
                            {
                                if (!propName.Contains(s))
                                {
                                    object o;
                                    emplacement.getPropriete(s, out o);
                                    e.Add(new XElement(s, emplacement.modifToString(o)));
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                XElement tmpElem = new XElement("emplacement");
                tmpElem.SetAttributeValue("numero", emplacement.numero.ToString());
                tmpElem.Add(new XElement("type", emplacement.type));
                tmpElem.Add(new XElement("piece", emplacement.nbPiece.ToString()));
                docu.Root.Add(tmpElem);
            }
            docu.Save(IFabrique.getPathXml("emplacement"));
            //XmlDocument doc = MyXml.getXmlDocument(path);
            //XmlNodeList nodes = doc.GetElementsByTagName("emplacement");
            
            //int nb = nodes.Count;
            //for (int i = 0; i < nb; i++)
            //{
            //    XmlAttributeCollection coll = nodes[i].Attributes;
            //    XmlAttribute num = coll["numero"];
            //    if (num.InnerXml == emplacement.numero.ToString())
            //    {
            //        nodes[i].Attributes["categorie"].Value = emplacement.getNomCategorie();
            //        XmlNodeList childNode = nodes[i].ChildNodes;
            //        foreach (XmlNode n in childNode)
            //        {
            //            switch (n.Name)
            //            {
            //                case "type":
            //                    {
            //                        n.InnerText = emplacement.type;
            //                    }
            //                    break;
            //                case "piece":
            //                    {
            //                        n.InnerText = emplacement.nbPiece.ToString();
            //                    }
            //                    break;
            //            }
            //        }
            //        updateOrCreate = true;
            //    }
            //}
            //if (!updateOrCreate)
            //{
            //    XmlElement elem = doc.CreateElement("emplacement");
            //    XmlAttribute attr = doc.CreateAttribute("numero");
            //    attr.InnerXml = emplacement.numero.ToString();
            //    elem.Attributes.Append(attr);
            //    XmlElement type = doc.CreateElement("type");
            //    type.InnerText = "Tortue";
            //    elem.AppendChild(type);
            //    doc.DocumentElement.AppendChild(elem);
            //}
            //MyXml.saveXmlDocument(doc, path);
            
        }

        
    }
}
