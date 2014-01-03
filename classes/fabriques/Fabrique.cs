using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using module_reservation.classes;

namespace module_reservation.classes
{
    class Fabrique<T> where T : new ()
    {
        private static T fabrique;

        static public T getFabrique()
        {
            fabrique = new T();
            return fabrique;
        }
    }
}
