using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    
    class Panier_Global
    {
        private string semaine;
        public string SEMAINE
        {
            get { return semaine; }
            private set { semaine = value; }
        }

   
        public int ID { get; private set; }

        public Panier_Global(string semaine)
        {
            SEMAINE = semaine;
        
        }
        public Panier_Global(int id ,string semaine)
            :this(semaine)
        {
            ID = id;
        }

    }
}
