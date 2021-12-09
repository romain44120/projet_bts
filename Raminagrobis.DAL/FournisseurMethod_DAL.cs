using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometrie.DAL;

namespace Raminagrobis.DAL
{
    public class FournisseurMethod_DAL : Depot_DAL<Fournisseur_DAL>
    {
        public override void Delete(Fournisseur_DAL fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from fournisseurs where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", fournisseur.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le fournisseur d'ID {fournisseur.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Fournisseur_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from fournisseurs";
            var reader = commande.ExecuteReader();

            var listeFournisseurs = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                var fournisseurTmp = new Fournisseur_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetBoolean(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetBoolean(7)
                                        );

                listeFournisseurs.Add(fournisseurTmp);
            }
            DetruireConnexionEtCommande();

            return listeFournisseurs;
        }

        public override Fournisseur_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from fournisseurs where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var fournisseur = new Fournisseur_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetBoolean(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetBoolean(7));
                return fournisseur;
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();
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

        public override Fournisseur_DAL Update(Fournisseur_DAL fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update fournisseurs set societe=@SOCIETE, civilite=@CIVILITE, nom=@NOM, prenom=@PRENOM, email=@EMAIL, adresse=@ADRESSE, status=@STATUS where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", fournisseur.ID));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", fournisseur.SOCIETE));
            commande.Parameters.Add(new SqlParameter("@CIVILITE", fournisseur.CIVILITE));
            commande.Parameters.Add(new SqlParameter("@NOM", fournisseur.NOM));
            commande.Parameters.Add(new SqlParameter("@PRENOM", fournisseur.PRENOM));
            commande.Parameters.Add(new SqlParameter("@EMAIL", fournisseur.EMAIL));
            commande.Parameters.Add(new SqlParameter("@ADRESSE", fournisseur.ADRESSE));
            commande.Parameters.Add(new SqlParameter("@STATUS", fournisseur.STATUS));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur d'ID {fournisseur.ID}");
            }

            DetruireConnexionEtCommande();

            return fournisseur;
        }
    }
}
