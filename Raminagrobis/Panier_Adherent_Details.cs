using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    public class Panier_Adherent_Details
    {
        //id reference

        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }


        private int quantite;
        public int QUANTITE
        {
            get { return quantite; }
            private set { quantite = value; }
        }

        //id panier adherent
        private int id_panier_adherent;
        public int ID_PANIER_ADHERENT
        {
            get { return id_panier_adherent; }
            private set { id_panier_adherent = value; }
        }


        public int ID { get; set; }

        public Panier_Adherent_Details(int quantite,int id_reference, int id_panier_adherent)
        {
            QUANTITE = quantite;
            ID_REFERENCE = id_reference;
            ID_PANIER_ADHERENT = id_panier_adherent;
        }
        public Panier_Adherent_Details(int id, int quantite, int id_reference, int id_panier_adherent)
            : this(quantite, id_reference, id_panier_adherent)
        {
            ID = id;
        }

    }
}
