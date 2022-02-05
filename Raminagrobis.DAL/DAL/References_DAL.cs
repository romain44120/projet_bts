using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Reference_DAL
    {
        public int ID { get; set; }
        public string REFERENCE { get; set; }
        public string LIBELLE { get; set; }
        public string MARQUE { get; set; }


        public Reference_DAL(string reference, string libelle, string marque)
            => (REFERENCE, LIBELLE, MARQUE) = (reference, libelle, marque);



        public Reference_DAL(int id, string reference, string libelle, string marque)
                 => (ID, REFERENCE, LIBELLE, MARQUE) = (id, reference, libelle, marque);

        

    }
}