using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;

namespace Raminagrobis.DAL
{
    public class Panier_Global_Method_DAL : Depot_DAL<Panier_Global_DAL>
    {
        public override void Delete(Panier_Global_DAL panier_global)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_global where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier_global.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le panier_global d'ID {panier_global.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Panier_Global_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_global";
            var reader = commande.ExecuteReader();

            var listePanier_global = new List<Panier_Global_DAL>();

            while (reader.Read())
            {
                var panier_globalTmp = new Panier_Global_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1)
                                        );

                listePanier_global.Add(panier_globalTmp);
            }
            DetruireConnexionEtCommande();

            return listePanier_global;
        }

        public override Panier_Global_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_global where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var panierglobal = new Panier_Global_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1)
                                        );
                return panierglobal;
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Panier_Global_DAL Insert(Panier_Global_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global(semaine)"
                                    + " values (@semaine); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@semaine", panier.SEMAINE));
   
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.ID = ID;

            DetruireConnexionEtCommande();


            return panier;
        }

        public override Panier_Global_DAL Update(Panier_Global_DAL panier_global)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_global set societe=@SOCIETE where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", panier_global.ID));
            commande.Parameters.Add(new SqlParameter("@SEMAINE", panier_global.SEMAINE));
   
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur d'ID {panier_global.ID}");
            }

            DetruireConnexionEtCommande();

            return panier_global;
        }
    }
}
