using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_reservation
{
    abstract class CalculRemise
    {
        protected static int dureeCalculee;

        public void initiazeCalculRemise()
        {
            dureeCalculee = 0;
        }

        public void setDureeCalculee(int duree)
        {
            dureeCalculee += duree;
        }
    }
}
