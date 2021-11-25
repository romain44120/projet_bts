using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{

    class Offres_Fournisseurs {
        //id Fournisseurs
        private int id_fournisseurs;
        public int ID_FOURNISSEURS
        {
            get { return id_fournisseurs; }
            private set { id_fournisseurs = value; }
        }
        private string offres;
        public string OFFRES
        {
            get { return offres; }
            private set { offres = value; }
        }

        //id panier globals details
        private int panier_globals_details;
        public int PANIER_GLOBALS_DETAILS
        {
            get { return id_fournisseurs; }
            private set { id_fournisseurs = value; }
        }

        public int ID { get; private set; }

        public Offres_Fournisseurs(string offres,int id_fournisseurs, int panier_globals_details)
        {
            OFFRES = offres;
            ID_FOURNISSEURS = id_fournisseurs;
            PANIER_GLOBALS_DETAILS = panier_globals_details;
        }
        public Offres_Fournisseurs(int id, string offres, int id_fournisseurs, int panier_globals_details)
            : this(offres, id_fournisseurs, panier_globals_details)
        {
            ID = id;
        }

    }
}
