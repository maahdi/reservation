using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation.classes
{
    class AdaptateurFabriqueComplexe<R,T> : IFabriqueSimple<R> where R : new()
    {
        private IFabriqueComplexe<R,T> fabrique;
        private Dictionary<String, T> liste;

        // <R,T> ou R est la fabrique que l'on souhaite et T la classe dont la fabrique a besoin
        public AdaptateurFabriqueComplexe(IFabriqueComplexe<R,T> fabComp, Dictionary<String, T> liste)
        {
            this.fabrique = fabComp;
            this.liste = liste;
        }
        
        public Dictionary<string, R> getAllXml()
        {
            return fabrique.getAllXml(liste);
        }

        public R getOneXml(string nodeName)
        {
            throw new NotImplementedException();
        }
    }
}
