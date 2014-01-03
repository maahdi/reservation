using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace module_reservation.classes
{
    abstract class XmlSave<T>
    {
        protected object modifToString(object data)
        {
            return data.ToString();
        }

        abstract public void save(T objet);
    }
}
