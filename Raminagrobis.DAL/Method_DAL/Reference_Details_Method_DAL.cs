using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;

namespace Raminagrobis.DAL
{
    public class Reference_DEtails_Method_DAL : Depot_DAL<Reference_details_DAL>
    {
        public override void Delete(Reference_details_DAL referencesDetails)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from references_details where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", referencesDetails.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la reference détails d'ID {referencesDetails.ID}");
            }

            DetruireConnexionEtCommande();
        }
        
        public void DeleteByIDFournisseur(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from references_details where id_fournisseur=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            DetruireConnexionEtCommande();
        }

        public List<Reference_details_DAL> GetByIDFournisseur(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from references_details where id_fournisseur=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeReferenceDetail = new List<Reference_details_DAL>();

            while (reader.Read())
            {
                var referenceDetailTmp = new Reference_details_DAL(
                                        reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );

                listeReferenceDetail.Add(referenceDetailTmp);
            }
            DetruireConnexionEtCommande();

            return listeReferenceDetail;
        }


        public override List<Reference_details_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from references_details";
            var reader = commande.ExecuteReader();

            var listeReferenceDetail = new List<Reference_details_DAL>();

            while (reader.Read())
            {
                var referenceDetailTmp = new Reference_details_DAL(
                                        reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );

                listeReferenceDetail.Add(referenceDetailTmp);
            }
            DetruireConnexionEtCommande();

            return listeReferenceDetail;
        }

        public override Reference_details_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from references_details where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var fournisseur = new Reference_details_DAL(
                                        reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        );
                return fournisseur;
            }
            else
                throw new Exception($"Pas de point dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Reference_details_DAL Insert(Reference_details_DAL referenceDetail)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into references_details( id_fournisseur, id_references)"
                                    + " values (@id_fournisseur, @id_references); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", referenceDetail.ID_FOURNISSEURS));
            commande.Parameters.Add(new SqlParameter("@id_references", referenceDetail.ID_REFERENCE));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            referenceDetail.ID = ID;

            DetruireConnexionEtCommande();


            return referenceDetail;
        }

        public override Reference_details_DAL Update(Reference_details_DAL referenceDetail)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update references_details set id_fournisseur=@IDFOURNISSEUR, id_references=@IDREFERENCES where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", referenceDetail.ID));
            commande.Parameters.Add(new SqlParameter("@IDFOURNISSEUR", referenceDetail.ID_FOURNISSEURS));
            commande.Parameters.Add(new SqlParameter("@IDREFERENCES", referenceDetail.ID_REFERENCE));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la reference détail avec l'ID {referenceDetail.ID}");
            }

            DetruireConnexionEtCommande();

            return referenceDetail;
        }

        
    }
}
