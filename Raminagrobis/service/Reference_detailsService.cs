using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Reference_detailsService : IReference_detailsService
    {
        private Reference_DEtails_Method_DAL depot = new Reference_DEtails_Method_DAL();

        public List<Reference_details> GetAll()
        {
            var reference_details = depot.GetAll()
                    .Select(f => new Reference_details(f.ID, f.ID_FOURNISSEURS, f.ID_REFERENCE))
                    .ToList();

            return reference_details;
        }

        public Reference_details GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Reference_details(f.ID, f.ID_FOURNISSEURS, f.ID_REFERENCE);
        }

        public Reference_details Insert(Reference_details f)
        {
            var reference_details = new Reference_details_DAL( f.ID_FOURNISSEURS, f.ID_REFERENCE);
            depot.Insert(reference_details);

            f.ID = reference_details.ID;

            return f;
        }

        public Reference_details Update(Reference_details f)
        {
            var reference_detailsDal = new Reference_details_DAL(f.ID, f.ID_FOURNISSEURS, f.ID_REFERENCE);
            depot.Update(reference_detailsDal);

            return f;
        }

        public void Delete(Reference_details f)
        {
            var reference_detailsDal = new Reference_details_DAL(f.ID, f.ID_FOURNISSEURS, f.ID_REFERENCE);
            depot.Delete(reference_detailsDal);
        }
        public void DeleteByIDFournisseur(int id)
        {
            depot.DeleteByIDFournisseur(id);
        }
        public List<Reference_details> GetByIDFournisseur(int ID)
        {
            var reference_details = depot.GetByIDFournisseur(ID)
                    .Select(f => new Reference_details(f.ID, f.ID_FOURNISSEURS, f.ID_REFERENCE))
                    .ToList();

            return reference_details;
        }
    }
}
