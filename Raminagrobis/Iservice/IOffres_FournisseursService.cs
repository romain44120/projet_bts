using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IOffres_FournisseurService
    {
        public List<Offres_Fournisseur> GetAll();
        public Offres_Fournisseur GetByID(int ID);
        public Offres_Fournisseur Insert(Offres_Fournisseur f);
        public Offres_Fournisseur Update(Offres_Fournisseur f);
        public void Delete(Offres_Fournisseur f);
    }
}
