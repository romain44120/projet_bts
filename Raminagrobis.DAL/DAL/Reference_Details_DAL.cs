using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Reference_details_DAL
    {
        public int ID { get; set; }
        public int ID_FOURNISSEURS { get; set; }
        public int ID_REFERENCE { get; set; }


        public Reference_details_DAL(int id_fournisseurs, int id_reference)
          => (ID_FOURNISSEURS, ID_REFERENCE) = (id_fournisseurs, id_reference);



        public Reference_details_DAL(int id, int id_fournisseurs, int id_reference)
                   => (ID, ID_FOURNISSEURS, ID_REFERENCE) = (id, id_fournisseurs, id_reference);

        

    }
}