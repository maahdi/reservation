using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{

    interface IFabriqueComplexe<R, T>
    {
        Dictionary<String, R> getAllXml(Dictionary<String,T> listeObjet);
        R getOneXml(String nodeName);
    }
}
