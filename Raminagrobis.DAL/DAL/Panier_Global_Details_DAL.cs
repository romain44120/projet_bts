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
        public int QUANTITE_GLOBAL { get; set; }
        public int ID_REFERENCE { get; set; }
        public int ID_PANIER_GLOBAL { get; set; }
    

        public Panier_Global_Details_DAL(int quantite_global, int id_reference, int id_panier_global)
            => (QUANTITE_GLOBAL, ID_REFERENCE, ID_PANIER_GLOBAL) = (quantite_global, id_reference, id_panier_global);



        public Panier_Global_Details_DAL(int id, int quantite_global, int id_reference, int id_panier_global)
                   => (ID, QUANTITE_GLOBAL, ID_REFERENCE, ID_PANIER_GLOBAL) = (id, quantite_global, id_reference, id_panier_global);

        

    }
}