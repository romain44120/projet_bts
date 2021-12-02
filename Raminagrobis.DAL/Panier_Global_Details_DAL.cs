using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Panier_Global_Details_DAL
    {
        public int ID { get; set; }
        public string QUANTITE_GLOBAL { get; set; }
        public int ID_REFERENCE { get; set; }
        public int ID_PANIER_ADHERENT { get; set; }
    

        public Panier_Global_Details_DAL(string quantite_global, int id_reference, int id_panier_adherent)
            => (QUANTITE_GLOBAL, ID_REFERENCE, ID_PANIER_ADHERENT) = (quantite_global, id_reference, id_panier_adherent);



        public Panier_Global_Details_DAL(int id, string quantite_global, int id_reference, int id_panier_adherent)
                   => (ID, QUANTITE_GLOBAL, ID_REFERENCE, ID_PANIER_ADHERENT) = (id, quantite_global, id_reference, id_panier_adherent);

        

    }
}