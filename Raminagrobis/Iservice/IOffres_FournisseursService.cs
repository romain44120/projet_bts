using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IOffres_FournisseurService
    {
        public List<Offres_Fournisseurs> GetAll();
        public Offres_Fournisseurs GetByID(int ID);
        public Offres_Fournisseurs Insert(Offres_Fournisseurs f);
        public Offres_Fournisseurs Update(Offres_Fournisseurs f);
        public void Delete(Offres_Fournisseurs f);
    }
}
