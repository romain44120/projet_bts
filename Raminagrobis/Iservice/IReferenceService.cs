using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IReferenceService
    {
        public List<Reference> GetAll();
        public Reference GetByID(int ID);
        public Reference Insert(Reference f);
        public Reference Update(Reference f);
        public void Delete(Reference f);
        public List<Reference> GetByReference(string reference);
    }
}
