using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    class Offres_Fournisseurs_DTO
    {
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
        private int id_panier_globals_details;
        public int ID_PANIER_GLOBALS_DETAILS
        {
            get { return id_panier_globals_details; }
            private set { id_panier_globals_details = value; }
        }

        public int ID { get; set; }
    }
}
