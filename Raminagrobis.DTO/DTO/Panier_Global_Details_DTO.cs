using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{

    public class Panier_Global_Details_DTO
    {
        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
             set { id_reference = value; }
        }

        private int quantite_global;
        public int QUANTITE_GLOBAL
        {
            get { return quantite_global; }
             set { quantite_global = value; }
        }

        //id panier adherent
        private int id_panier_global;
        public int ID_PANIER_GLOBAL
        {
            get { return id_panier_global; }
             set { id_panier_global = value; }
        }

        public int ID { get; set; }

      

    }
}
