using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    class Adherent_DTO
    {
        private string societe;
        public string SOCIETE
        {
            get { return societe; }
            private set { societe = value; }
        }

        private bool civilite;
        public bool CIVILITE
        {
            get { return civilite; }
            private set { civilite = value; }
        }
        private string nom;
        public string NOM
        {
            get { return nom; }
            private set { nom = value; }
        }
        private string prenom;
        public string PRENOM
        {
            get { return prenom; }
            private set { prenom = value; }
        }
        private string email;
        public string EMAIL
        {
            get { return email; }
            private set { email = value; }
        }
        private string adresse;
        public string ADRESSE
        {
            get { return adresse; }
            private set { adresse = value; }
        }

        private bool status;
        public bool STATUS
        {
            get { return status; }
            private set { status = value; }
        }

        private DateTime dateadhesion;
        public DateTime DATEADHESION
        {
            get { return dateadhesion; }
            private set { dateadhesion = value; }
        }
        public int ID { get; private set; }

      
    }
}
