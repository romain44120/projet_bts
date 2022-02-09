using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Raminagrobis.DAL
{
    public class AdherentMethod_DAL : Depot_DAL<Adherent_DAL>
    {
        public override void Delete(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from adherents where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent avec l'(ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from adherents";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var adherentTmp = new Adherent_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetBoolean(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetDateTime(7),
                                        reader.GetBoolean(8)
                                        );

                listeAdherents.Add(adherentTmp);
            }
            DetruireConnexionEtCommande();

            return listeAdherents;
        }

        public override Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from adherents where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var adherent = new Adherent_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetBoolean(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetDateTime(7),
                                        reader.GetBoolean(8)
                                        );
                return adherent;
            }
            else
            {
                throw new Exception($"Impossible de récupérer l'adhérents avec l'(ID {ID}");
            }
            DetruireConnexionEtCommande();
        }

        public override Adherent_DAL Insert(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into adherents(societe, civilite, nom, prenom, email, adresse, dateAdhesion, status)"
                                    + " values (@societe, @civilite, @nom, @prenom, @email, @adresse, @dateAdhesion, @status); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@societe", adherent.SOCIETE));
            commande.Parameters.Add(new SqlParameter("@civilite", adherent.CIVILITE));
            commande.Parameters.Add(new SqlParameter("@nom", adherent.NOM));
            commande.Parameters.Add(new SqlParameter("@prenom", adherent.PRENOM));
            commande.Parameters.Add(new SqlParameter("@email", adherent.EMAIL));
            commande.Parameters.Add(new SqlParameter("@adresse", adherent.ADRESSE));
            commande.Parameters.Add(new SqlParameter("@dateAdhesion", adherent.DATEADHESION));
            commande.Parameters.Add(new SqlParameter("@status", adherent.STATUS));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            adherent.ID = ID;

            DetruireConnexionEtCommande();


            return adherent;
        }

        public override Adherent_DAL Update(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update adherents set societe=@SOCIETE, civilite=@CIVILITE, nom=@NOM, prenom=@PRENOM, email=@EMAIL, adresse=@ADRESSE, dateAdhesion=@DATEADHESION,status=@STATUS where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            commande.Parameters.Add(new SqlParameter("@SOCIETE", adherent.SOCIETE));
            commande.Parameters.Add(new SqlParameter("@CIVILITE", adherent.CIVILITE));
            commande.Parameters.Add(new SqlParameter("@NOM", adherent.NOM));
            commande.Parameters.Add(new SqlParameter("@PRENOM", adherent.PRENOM));
            commande.Parameters.Add(new SqlParameter("@EMAIL", adherent.EMAIL));
            commande.Parameters.Add(new SqlParameter("@ADRESSE", adherent.ADRESSE));
            commande.Parameters.Add(new SqlParameter("@DATEADHESION", adherent.DATEADHESION));
            commande.Parameters.Add(new SqlParameter("@STATUS", adherent.STATUS));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'adhérent avec l'ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();

            //todo 


            return adherent;
        }
    }
}
