using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{

    public class Reference_details_DTO
    {
        //id fournisseur
        private int id_fournisseurs;
        public int ID_FOURNISSEURS
        {
            get { return id_fournisseurs; }
             set { id_fournisseurs = value; }
        }

        //id references
        private int id_reference;
        public int ID_REFERENCE
        {
            get { return id_reference; }
             set { id_reference = value; }
        }


        public int ID { get; set; }

      

    }
}
