using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometrie.DAL;

namespace Raminagrobis.DAL
{
    public class FournisseurGlobal_DAL : Depot_DAL<Fournisseur_DAL>
    {
        public override void Delete(Fournisseur_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<Fournisseur_DAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Fournisseur_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public override Fournisseur_DAL Insert(Fournisseur_DAL fourni)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs(societe, civilite, nom, prenom, email, adresse, status)"
                                    + " values (@societe, @civilite, @nom, @prenom, @email, @adresse, @status); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@societe", fourni.SOCIETE));
            commande.Parameters.Add(new SqlParameter("@civilite", fourni.CIVILITE));
            commande.Parameters.Add(new SqlParameter("@nom", fourni.NOM));
            commande.Parameters.Add(new SqlParameter("@prenom", fourni.PRENOM));
            commande.Parameters.Add(new SqlParameter("@email", fourni.EMAIL));
            commande.Parameters.Add(new SqlParameter("@adresse", fourni.ADRESSE));
            commande.Parameters.Add(new SqlParameter("@status", fourni.STATUS));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            fourni.ID = ID;

            DetruireConnexionEtCommande();


            return fourni;
        }

        public override Fournisseur_DAL Update(Fournisseur_DAL item)
        {
            throw new NotImplementedException();
        }
    }
}
