using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{

    public class Reference_DTO
    {
        private string reference;
        public string REFERENCE
        {
            get { return reference; }
             set { reference = value; }
        }
        private string libelle;
        public string LIBELLE
        {
            get { return libelle; }
             set { libelle = value; }
        }
        private string marque;
        public string MARQUE
        {
            get { return marque; }
             set { marque = value; }
        }
        public int ID { get;  set; }

      

    }
}
