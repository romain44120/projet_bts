using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Panier_Adherent_DAL
    {
        public int ID { get; set; }
        public string SEMAINE { get; set; }
        public int ID_ADHERENT { get; set; }
     

        public Panier_Adherent_DAL(string semaine, int id_adherent)
            => (SEMAINE,ID_ADHERENT) = (semaine, id_adherent);

        public Panier_Adherent_DAL(int id, string semaine, int id_adherent)
                    => (ID, SEMAINE, ID_ADHERENT) = (id, semaine, id_adherent);

        

    }
}