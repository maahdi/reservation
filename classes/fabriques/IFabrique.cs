using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace module_reservation.classes
{
    abstract class IFabrique
    {
        static public String getPathXml(String name)
        {
            return ConfigurationManager.AppSettings[name];
        }

        protected Object setOtherProperties(XmlNode node)
        {
            XmlAttributeCollection coll = node.Attributes; 
            XmlAttribute attr = coll["type"];
            String value = node.InnerXml;
            Object retour = new Object();
            changedTypeData(attr.InnerXml, value, out retour);
            return retour;
        }

        private void changedTypeData(String type, String data, out object retour)
        {
            switch (type)
            {
                case "Entier":
                    retour = int.Parse((String) data);
                    break;
                case "Decimal":
                    retour = double.Parse(data);
                    break;
                case "Boleen":
                    retour = bool.Parse(data);
                    break;
                case "Texte":
                default:
                    retour = data;
                    break;
            }
        }
    }
}
