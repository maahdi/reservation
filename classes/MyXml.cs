using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace module_reservation.classes
{
    class MyXml
    {
        static public XmlNodeList getNodeList(String path, String tagName)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(path);
            }
            catch (Exception e)
            {
               
            }

            // Récupération des éléments du fichier Xml
            return xml.GetElementsByTagName(tagName);
        }

        static public XmlDocument getXmlDocument(String path)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(path);
            }
            catch (XmlException e)
            {
            }
            return xml;
        }

        static public void saveXmlDocument(XmlDocument doc, String path)
        {
            doc.PreserveWhitespace = true;
            XmlTextWriter wtr = new XmlTextWriter(path, Encoding.UTF8);
            wtr.Formatting = Formatting.Indented;
            doc.WriteTo(wtr);
            wtr.Close();
        }
    }
}
