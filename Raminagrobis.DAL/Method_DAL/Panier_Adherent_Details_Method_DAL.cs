using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Raminagrobis.DAL
{
    public class Panier_Adherent_Details_Method_DAL : Depot_DAL<Panier_Adherent_Details_DAL>
    {
        public override void Delete(Panier_Adherent_Details_DAL panier_adherent_details)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_adherent_details where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier_adherent_details.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le panier_adherent_details d'ID {panier_adherent_details.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Panier_Adherent_Details_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_adherents_details";
            var reader = commande.ExecuteReader();

            var listepanier_adherent_details = new List<Panier_Adherent_Details_DAL>();

            while (reader.Read())
            {
                var panier_adherent_detailsTmp = new Panier_Adherent_Details_DAL(
                                        reader.GetInt32(0),
                                        reader.GetInt32(2),
                                        reader.GetInt32(1),
                                        reader.GetInt32(3)
                                       
                                        );

                listepanier_adherent_details.Add(panier_adherent_detailsTmp);
            }
            DetruireConnexionEtCommande();

            return listepanier_adherent_details;
        }

        public override Panier_Adherent_Details_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_adherent_details where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var panier_adherent_details = new Panier_Adherent_Details_DAL(
                                        reader.GetInt32(0),
                                        reader.GetInt32(2),
                                        reader.GetInt32(1),
                                        reader.GetInt32(3));
                return panier_adherent_details;
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Panier_Adherent_Details_DAL Insert(Panier_Adherent_Details_DAL fourni)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_adherents_details(id_references, quantite, id_panier_adherents)"
                                    + " values (@id_reference, @quantite, @id_panier_adherents); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@id_reference", fourni.ID_REFERENCE));
            commande.Parameters.Add(new SqlParameter("@quantite", fourni.QUANTITE));
            commande.Parameters.Add(new SqlParameter("@id_panier_adherents", fourni.ID_PANIER_ADHERENT));
          

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            fourni.ID = ID;

            DetruireConnexionEtCommande();


            return fourni;
        }

        public override Panier_Adherent_Details_DAL Update(Panier_Adherent_Details_DAL panier_adherent_details)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update fournisseurs set societe=@ID_REFERENCE, civilite=@QUANTITE, nom=@ID_PANIER_ADHERENT where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", panier_adherent_details.ID));
            commande.Parameters.Add(new SqlParameter("@ID_REFERENCE", panier_adherent_details.ID_REFERENCE));
            commande.Parameters.Add(new SqlParameter("@QUANTITE", panier_adherent_details.QUANTITE));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_ADHERENT", panier_adherent_details.ID_PANIER_ADHERENT));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier_adherent_details d'ID {panier_adherent_details.ID}");
            }

            DetruireConnexionEtCommande();

            return panier_adherent_details;
        }
    }
}
