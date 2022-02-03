using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    public class Panier_Adherent
    {
        private string semaine;
        public string SEMAINE
        {
            get { return semaine; }
            private set { semaine = value; }
        }


        //rajouter id adherent
        private int id_adherent;
        public int ID_ADHERENT
        {
            get { return id_adherent; }
            private set { id_adherent = value; }
        }
        public int ID { get;  set; }

        public Panier_Adherent(string semaine, int id_adherent)
        {
            SEMAINE = semaine;
            ID_ADHERENT = id_adherent;
        }
        public Panier_Adherent(int id, string semaine, int id_adherent)
            : this(semaine, id_adherent)
        {
            ID = id;
        }

    }
}
