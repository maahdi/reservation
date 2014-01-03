using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    interface IFabriqueSimple<R> where R : new()
    {
        Dictionary<String, R> getAllXml() ;
        R getOneXml(String nodeName);
    }
}
