using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    class Fournisseur_DAL
    {
        public int ID { get; set; }
        public string SOCIETE { get; set; }
        public bool CIVILITE { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public string EMAIL { get; set; }
        public string ADRESSE { get; set; }
        public bool STATUS { get; set; }

        public Fournisseur_DAL(string societe, bool civilite, string nom, string prenom, string email, string adresse, bool status)
            => (SOCIETE, CIVILITE, NOM, PRENOM, EMAIL, ADRESSE, STATUS) = (societe, civilite, nom, prenom, email, adresse, status);

        public Fournisseur_DAL(int id, string societe, bool civilite, string nom, string prenom, string email, string adresse, bool status)
                    => (ID, SOCIETE, CIVILITE, NOM, PRENOM, EMAIL, ADRESSE, STATUS) = (id, societe, civilite, nom, prenom, email, adresse, status);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into adherents(societe,civilite,nom,prenom,email,adresse,satuts)"
                                + " values (@SOCIETE, @CIVILITE, @NOM, @PRENOM, @EMAIL, @ADRESSE, @STATUS)";
                commande.Parameters.Add(new SqlParameter("@SOCIETE", SOCIETE));
                commande.Parameters.Add(new SqlParameter("@CIVILITE", CIVILITE));
                commande.Parameters.Add(new SqlParameter("@NOM", NOM));
                commande.Parameters.Add(new SqlParameter("@PRENOM", PRENOM));
                commande.Parameters.Add(new SqlParameter("@EMAIL", EMAIL));
                commande.Parameters.Add(new SqlParameter("@ADRESSE", ADRESSE));
                commande.Parameters.Add(new SqlParameter("@STATUS", STATUS));

                commande.ExecuteNonQuery();
            }
        }

    }
}