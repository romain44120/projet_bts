using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{

    public class Panier_Adherent_DTO
    {
        private string semaine;
        public string SEMAINE
        {
            get { return semaine; }
             set { semaine = value; }
        }


        //rajouter id adherent
        private int id_adherent;
        public int ID_ADHERENT
        {
            get { return id_adherent; }
             set { id_adherent = value; }
        }
        public int ID { get; set; }

    }
}
