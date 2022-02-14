using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Panier_Adherent_Details_DAL
    {
        public int ID { get; set; }
        public int QUANTITE { get; set; }
        public int ID_REFERENCE { get; set; }
        public int ID_PANIER_ADHERENT { get; set; }

        public Panier_Adherent_Details_DAL(int quantite, int id_reference, int id_panier_adherent)
            => (QUANTITE, ID_REFERENCE, ID_PANIER_ADHERENT) = (quantite, id_reference, id_panier_adherent);

        public Panier_Adherent_Details_DAL(int id, int quantite, int id_reference, int id_panier_adherent)
                    => (ID, QUANTITE, ID_REFERENCE, ID_PANIER_ADHERENT) = (id, quantite, id_reference, id_panier_adherent);

        

    }
}