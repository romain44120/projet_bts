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

        private string quantite_global;
        public string QUANTITE_GLOBAL
        {
            get { return quantite_global; }
             set { quantite_global = value; }
        }

        //id panier adherent
        private int id_panier_adherent;
        public int ID_PANIER_ADHERENT
        {
            get { return id_panier_adherent; }
             set { id_panier_adherent = value; }
        }

        public int ID { get; set; }

      

    }
}
