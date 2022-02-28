using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class ReferenceService : IReferenceService
    {
        private ReferenceMethod_DAL depot = new ReferenceMethod_DAL();

        public List<Reference> GetAll()
        {
            var reference = depot.GetAll()
                    .Select(f => new Reference(f.ID, f.REFERENCE, f.LIBELLE, f.MARQUE))
                    .ToList();

            return reference;
        }

        public Reference GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Reference(f.ID, f.REFERENCE, f.LIBELLE, f.MARQUE);
        }

        public Reference Insert(Reference f)
        {
            var referenceDal = new Reference_DAL(f.REFERENCE, f.LIBELLE, f.MARQUE);
            depot.Insert(referenceDal);

            f.ID = referenceDal.ID;

            return f;
        }

        public Reference Update(Reference f)
        {
            var referenceDal = new Reference_DAL(f.ID, f.REFERENCE, f.LIBELLE, f.MARQUE);
            depot.Update(referenceDal);

            return f;
        }

        public void Delete(Reference f)
        {
            var referenceDal = new Reference_DAL(f.ID, f.REFERENCE, f.LIBELLE, f.MARQUE);
            depot.Delete(referenceDal);
        }

        public List<Reference> GetByReference(string reference)
        {
            var r = depot.GetByReference(reference)
                    .Select(f => new Reference(f.ID, f.REFERENCE, f.LIBELLE, f.MARQUE))
                    .ToList();

            return r;

        }
    }
}
