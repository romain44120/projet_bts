using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Raminagrobis.DAL
{
    public class Panier_AdherentMethod_DAL : Depot_DAL<Panier_Adherent_DAL>
    {
        public override void Delete(Panier_Adherent_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from panier_adherents where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", panier.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le panier avec l'ID {panier.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Panier_Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_adherents";
            var reader = commande.ExecuteReader();

            var listePanierAdherents = new List<Panier_Adherent_DAL>();

            while (reader.Read())
            {
                var panierAdherentTmp = new Panier_Adherent_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2)
                                        );

                listePanierAdherents.Add(panierAdherentTmp);
            }
            DetruireConnexionEtCommande();

            return listePanierAdherents;
        }

        public override Panier_Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from panier_adherents where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var panier_Adherent = new Panier_Adherent_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));
                return panier_Adherent;
            }
            else
                throw new Exception($"Pas de panier adhérent avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Panier_Adherent_DAL Insert(Panier_Adherent_DAL panierAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_adherents(semaine, id_adherents)"
                                    + " values (@semaine, @id_adherents); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@semaine", panierAdherent.SEMAINE));
            commande.Parameters.Add(new SqlParameter("@id_adherents", panierAdherent.ID_ADHERENT));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panierAdherent.ID = ID;

            DetruireConnexionEtCommande();


            return panierAdherent;
        }

        public override Panier_Adherent_DAL Update(Panier_Adherent_DAL panierAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_adherents set semaine=@SEMAINE, id_adherents=@ID_ADHERENTS where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", panierAdherent.ID));
            commande.Parameters.Add(new SqlParameter("@SEMAINE", panierAdherent.SEMAINE));
            commande.Parameters.Add(new SqlParameter("@ID_ADHERENTS", panierAdherent.ID_ADHERENT));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier adhérent {panierAdherent.ID}");
            }

            DetruireConnexionEtCommande();

            return panierAdherent;
        }
    }
}
