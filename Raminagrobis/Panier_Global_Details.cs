using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    public class Panier_Global_Details
    {
        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }

        private int quantite_global;
        public int QUANTITE_GLOBAL
        {
            get { return quantite_global; }
            private set { quantite_global = value; }
        }

        //id panier adherent
        private int id_panier_global;
        public int ID_PANIER_GLOBAL
        {
            get { return id_panier_global; }
            private set { id_panier_global = value; }
        }

        public int ID { get; set; }

        public Panier_Global_Details(int quantite_global,int id_reference, int id_panier_global)
        {
            QUANTITE_GLOBAL = quantite_global;
            ID_REFERENCE = id_reference;
            ID_PANIER_GLOBAL = id_panier_global;

        }
        public Panier_Global_Details(int id, int quantite_global, int id_reference, int id_panier_global)
            : this(quantite_global, id_reference, id_panier_global)
        {
            ID = id;
        }

    }
}
