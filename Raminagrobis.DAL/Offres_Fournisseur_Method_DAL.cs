using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;

namespace Raminagrobis.DAL
{
    public class Offres_Fournisseurs_Method_DAL : Depot_DAL<Offres_Fournisseurs_DAL>
    {
        public override void Delete(Offres_Fournisseurs_DAL offres_fournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from offres_fournisseurs where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", offres_fournisseurs.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le offres_fournisseurs d'ID {offres_fournisseurs.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Offres_Fournisseurs_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from offres_fournisseurs";
            var reader = commande.ExecuteReader();

            var listeOffres_Fournisseur = new List<Offres_Fournisseurs_DAL>();

            while (reader.Read())
            {
                var offres_fournisseurTmp = new Offres_Fournisseurs_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );

                listeOffres_Fournisseur.Add(offres_fournisseurTmp);
            }
            DetruireConnexionEtCommande();

            return listeOffres_Fournisseur;
        }

        public override Offres_Fournisseurs_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from offres_fournisseurs where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var offres_fournisseurs = new Offres_Fournisseurs_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );
                return offres_fournisseurs;
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Offres_Fournisseurs_DAL Insert(Offres_Fournisseurs_DAL offres_fourni)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into offres_fournisseurs(offres, id_fournisseurs, id_panier_globals_details)"
                                    + " values (@offres, @id_fournisseurs,@id_panier_globals_details); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@offres", offres_fourni.OFFRES));
            commande.Parameters.Add(new SqlParameter("@id_fournisseurs", offres_fourni.ID_FOURNISSEURS));
            commande.Parameters.Add(new SqlParameter("@id_panier_globals_details", offres_fourni.ID_PANIER_GLOBALS_DETAILS));


            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            offres_fourni.ID = ID;

            DetruireConnexionEtCommande();


            return offres_fourni;
        }

        public override Offres_Fournisseurs_DAL Update(Offres_Fournisseurs_DAL offres_fournisseurs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update offres_fournisseurs set societe=@OFFRES, civilite=@ID_FOURNISSEURS, nom=@ID_PANIER_GLOBALS_DETAILS where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", offres_fournisseurs.ID));
            commande.Parameters.Add(new SqlParameter("@OFFRES", offres_fournisseurs.OFFRES));
            commande.Parameters.Add(new SqlParameter("@ID_FOURNISSEURS", offres_fournisseurs.ID_FOURNISSEURS));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBALS_DETAILS", offres_fournisseurs.ID_PANIER_GLOBALS_DETAILS));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le offres_fournisseur d'ID {offres_fournisseurs.ID}");
            }

            DetruireConnexionEtCommande();

            return offres_fournisseurs;
        }
    }
}