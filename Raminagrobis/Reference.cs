using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    public class Reference
    {
        private string reference;
        public string REFERENCE
        {
            get { return reference; }
            private set { reference = value; }
        }
        private string libelle;
        public string LIBELLE
        {
            get { return libelle; }
            private set { libelle = value; }
        }
        private string marque;
        public string MARQUE
        {
            get { return marque; }
            private set { marque = value; }
        }
        public int ID { get;  set; }

        public Reference(string reference, string libelle, string marque)
        {
            REFERENCE = reference;
            LIBELLE = libelle;
            MARQUE = marque;
        }
        public Reference(int id, string reference, string libelle, string marque)
            : this(reference,libelle, marque)
        {
            ID = id;
        }

    }
}
