using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Panier_Global
    {
        public int ID { get; set; }
        public string SEMAINE { get; set; }


        public Panier_Global(string semaine)
            => (SEMAINE) = (semaine);


        public Panier_Global(int id, string semaine)
                    => (ID, SEMAINE) = (id, semaine);

        

    }
}