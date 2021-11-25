using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    class Panier_Adherent_Details
    {
        //id reference

        private string quantite;
        public string QUANTITE
        {
            get { return quantite; }
            private set { quantite = value; }
        }
        
        //id panier adherent

 
        public int ID { get; private set; }

        public Panier_Adherent_Details(string quantite)
        {
            QUANTITE = quantite;

        }
        public Panier_Adherent_Details(int id, string quantite)
            : this(quantite)
        {
            ID = id;
        }

    }
}
