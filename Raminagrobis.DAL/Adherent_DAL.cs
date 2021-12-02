using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Adherent_DAL
    {
        public int ID { get; set; }
        public string SOCIETE { get; set; }
        public bool CIVILITE { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public string EMAIL { get; set; }
        public string ADRESSE { get; set; }
        public DateTime DATEADHESION { get; set; }
        public bool STATUS { get; set; }

        public Adherent_DAL(string societe, bool civilite, string nom, string prenom, string email, string adresse, DateTime dateadhesion, bool status)
            => (SOCIETE, CIVILITE, NOM, PRENOM, EMAIL, ADRESSE, DATEADHESION, STATUS) = (societe, civilite, nom, prenom, email, adresse, dateadhesion, status);

        public Adherent_DAL(int id, string societe, bool civilite, string nom, string prenom, string email, string adresse, DateTime dateadhesion, bool status)
                    => (ID, SOCIETE, CIVILITE, NOM, PRENOM, EMAIL, ADRESSE,DATEADHESION,STATUS) = (id, societe, civilite, nom, prenom, email, adresse, dateadhesion, status);

        

    }
}