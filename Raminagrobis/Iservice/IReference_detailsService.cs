using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IReference_detailsService
    {
        public List<Reference_details> GetAll();
        public Reference_details GetByID(int ID);
        public Reference_details Insert(Reference_details f);
        public Reference_details Update(Reference_details f);
        public void Delete(Reference_details f);
        public void DeleteByIDFournisseur(int ID);
        public List<Reference_details> GetByIDFournisseur(int ID);
    }
}
