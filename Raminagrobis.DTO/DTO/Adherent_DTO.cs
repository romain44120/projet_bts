using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class Adherent_DTO
    {
        private string societe;
        public string SOCIETE
        {
            get { return societe; }
             set { societe = value; }
        }

        private bool civilite;
        public bool CIVILITE
        {
            get { return civilite; }
             set { civilite = value; }
        }
        private string nom;
        public string NOM
        {
            get { return nom; }
             set { nom = value; }
        }
        private string prenom;
        public string PRENOM
        {
            get { return prenom; }
             set { prenom = value; }
        }
        private string email;
        public string EMAIL
        {
            get { return email; }
             set { email = value; }
        }
        private string adresse;
        public string ADRESSE
        {
            get { return adresse; }
             set { adresse = value; }
        }

        private bool status;
        public bool STATUS
        {
            get { return status; }
             set { status = value; }
        }

        private DateTime dateadhesion;
        public DateTime DATEADHESION
        {
            get { return dateadhesion; }
             set { dateadhesion = value; }
        }
        public int ID { get;  set; }

      
    }
}
