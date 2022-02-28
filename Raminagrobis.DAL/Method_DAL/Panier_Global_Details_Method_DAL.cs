using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;

namespace Raminagrobis.DAL
{
    public class Panier_Global_Details_Method_DAL : Depot_DAL<Panier_Global_Details_DAL>
    {
        public override void Delete(Panier_Global_Details_DAL panier_global_details)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_global_details where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier_global_details.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le panier_global_details d'ID {panier_global_details.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Panier_Global_Details_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_global_details";
            var reader = commande.ExecuteReader();

            var listepanier_global_details = new List<Panier_Global_Details_DAL>();

            while (reader.Read())
            {
                var panier_global_detailsTmp = new Panier_Global_Details_DAL(
                                       reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                        );

                listepanier_global_details.Add(panier_global_detailsTmp);
            }
            DetruireConnexionEtCommande();

            return listepanier_global_details;
        }
        public List<Panier_Global_Details_DAL> GetByIDPanierGlobal(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_global_details where id_panier_global=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listepanier_global_details = new List<Panier_Global_Details_DAL>();

            while (reader.Read())
            {
                var panier_global_detailsTmp = new Panier_Global_Details_DAL(
                                       reader.GetInt32(0),
                                        reader.GetInt32(2),
                                        reader.GetInt32(1),
                                        reader.GetInt32(3)
                                        );

                listepanier_global_details.Add(panier_global_detailsTmp);
            }
            DetruireConnexionEtCommande();

            return listepanier_global_details;
        }

        public override Panier_Global_Details_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_global_details where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var panier_global_details = new Panier_Global_Details_DAL(
                                        reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                     );
                return panier_global_details;
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Panier_Global_Details_DAL Insert(Panier_Global_Details_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global_details(quantite_global, id_reference,id_panier_global)"
                                    + " values (@quantite_global, @id_reference, @id_panier_global); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@quantite_global", panier.QUANTITE_GLOBAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", panier.ID_REFERENCE));
            commande.Parameters.Add(new SqlParameter("@id_panier_global", panier.ID_PANIER_GLOBAL));



            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.ID = ID;

            DetruireConnexionEtCommande();


            return panier;
        }

        public override Panier_Global_Details_DAL Update(Panier_Global_Details_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update fournisseurs set societe=@QUANTITE_GLOBAL, civilite=@ID_REFERENCE, nom=@ID_PANIER_ADHERENT where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", panier.ID));
            commande.Parameters.Add(new SqlParameter("@QUANTITE_GLOBAL", panier.QUANTITE_GLOBAL));
            commande.Parameters.Add(new SqlParameter("@ID_REFERENCE", panier.ID_REFERENCE));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_ADHERENT", panier.ID_PANIER_GLOBAL));
    
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier_global_details d'ID {panier.ID}");
            }

            DetruireConnexionEtCommande();

            return panier;
        }
    }
}
