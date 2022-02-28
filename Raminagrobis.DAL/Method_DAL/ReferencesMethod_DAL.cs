using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;

namespace Raminagrobis.DAL
{
    public class ReferenceMethod_DAL : Depot_DAL<Reference_DAL>
    {
        public override void Delete(Reference_DAL reference)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from [Raminagrobis].[dbo].[references] where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", reference.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la référence d'ID {reference.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Reference_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from  [Raminagrobis].[dbo].[references]";
            var reader = commande.ExecuteReader();

            var listReferences = new List<Reference_DAL>();

            while (reader.Read())
            {
                var referenceTmp = new Reference_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3)
                                        );

                listReferences.Add(referenceTmp);
            }
            DetruireConnexionEtCommande();

            return listReferences;
        }

        public override Reference_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from  [Raminagrobis].[dbo].[references] where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var references = new Reference_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3)
                                        );
                return references;
            }
            else
                throw new Exception($"Pas de référence avec l'ID {ID}");

            DetruireConnexionEtCommande();
        }

        public override Reference_DAL Insert(Reference_DAL reference)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into  [Raminagrobis].[dbo].[references] (reference, libelle, marque)"
                                    + " values (@reference, @libelle, @marque); select scope_identity()";

            commande.Parameters.Add(new SqlParameter("@reference", reference.REFERENCE));
            commande.Parameters.Add(new SqlParameter("@libelle", reference.LIBELLE));
            commande.Parameters.Add(new SqlParameter("@marque", reference.MARQUE));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            reference.ID = ID;

            DetruireConnexionEtCommande();


            return reference;
        }

        public override Reference_DAL Update(Reference_DAL reference)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update [Raminagrobis].[dbo].[references] set reference=@REFERENCE, libelle=@LIBELLE, marque=@MARQUE where id=@ID;";
            commande.Parameters.Add(new SqlParameter("@ID", reference.ID));
            commande.Parameters.Add(new SqlParameter("@REFERENCE", reference.REFERENCE));
            commande.Parameters.Add(new SqlParameter("@LIBELLE", reference.LIBELLE));
            commande.Parameters.Add(new SqlParameter("@MARQUE", reference.MARQUE));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la référence avec l'ID {reference.ID}");
            }

            DetruireConnexionEtCommande();

            return reference;
        }

        public List<Reference_DAL> GetByReference(string reference)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from  [Raminagrobis].[dbo].[references] where reference=@REFERENCE";
            commande.Parameters.Add(new SqlParameter("@REFERENCE", reference));
            var reader = commande.ExecuteReader();

            var listReferences = new List<Reference_DAL>();

            while (reader.Read())
            {
                var referenceTmp = new Reference_DAL(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3)
                                        );

                listReferences.Add(referenceTmp);
            }
           

            DetruireConnexionEtCommande();

            return listReferences;
        }

    }
}
