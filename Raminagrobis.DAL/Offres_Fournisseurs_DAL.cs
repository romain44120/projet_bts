using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Offres_Fournisseurs_DAL
    {
        public int ID { get; set; }
        public string OFFRES { get; set; }
        public int ID_FOURNISSEURS { get; set; }
        public int ID_PANIER_GLOBALS_DETAILS { get; set; }
       

        public Offres_Fournisseurs_DAL( string offres, int id_fournisseurs, int id_panier_globals_details)
            => (OFFRES, ID_FOURNISSEURS, ID_PANIER_GLOBALS_DETAILS) = (offres, id_fournisseurs, id_panier_globals_details);

        public Offres_Fournisseurs_DAL(int id, string offres, int id_fournisseurs, int id_panier_globals_details)
                    => (ID, OFFRES, ID_FOURNISSEURS, ID_PANIER_GLOBALS_DETAILS) = (id, offres, id_fournisseurs, id_panier_globals_details);

        

    }
}