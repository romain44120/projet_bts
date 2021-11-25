using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    class Panier_Global_Details
    {
        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }

        private string quantite_global;
        public string QUANTITE_GLOBAL
        {
            get { return quantite_global; }
            private set { quantite_global = value; }
        }

        //id panier adherent
        private int id_panier_adherent;
        public int ID_PANIER_ADHERENT
        {
            get { return id_panier_adherent; }
            private set { id_panier_adherent = value; }
        }

        public int ID { get; private set; }

        public Panier_Global_Details(string quantite_global,int id_reference, int id_panier_adherent)
        {
            QUANTITE_GLOBAL = quantite_global;
            ID_REFERENCE = id_reference;
            ID_PANIER_ADHERENT = id_panier_adherent;

        }
        public Panier_Global_Details(int id, string quantite_global, int id_reference, int id_panier_adherent)
            : this(quantite_global, id_reference, id_panier_adherent)
        {
            ID = id;
        }

    }
}
