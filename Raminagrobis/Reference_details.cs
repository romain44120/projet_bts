using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    class Reference_details
    {
        //id fournisseur
        private int id_fournisseurs;
        public int ID_FOURNISSEURS
        {
            get { return id_fournisseurs; }
            private set { id_fournisseurs = value; }
        }

        //id references
        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
            private set { id_reference = value; }
        }


        public int ID { get; private set; }

        public Reference_details( int id_fournisseurs,int id_reference)
        {
            ID_FOURNISSEURS = id_fournisseurs;
            ID_REFERENCE = id_reference;

        }
        public Reference_details(int id,int id_fournisseurs, int id_reference )
            : this(id_fournisseurs, id_reference)
        {
            ID = id;
        }

    }
}
