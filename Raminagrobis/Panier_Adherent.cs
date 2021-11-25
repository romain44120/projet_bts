using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    class Panier_Adherent
    {
        private string semaine;
        public string SEMAINE
        {
            get { return semaine; }
            private set { semaine = value; }
        }
      

        //rajouter id adherent
        public int ID { get; private set; }

        public Panier_Adherent(string semaine)
        {
            SEMAINE = semaine;

        }
        public Panier_Adherent(int id, string semaine)
            : this(semaine)
        {
            ID = id;
        }

    }
}
