using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class Panier_Adherent_Details_DTO
    {
        //id reference

        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
             set { id_reference = value; }
        }


        private int quantite;
        public int QUANTITE
        {
            get { return quantite; }
             set { quantite = value; }
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
