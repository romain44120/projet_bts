using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Offres_FournisseursService : IOffres_FournisseursService
    {
        private Offres_Fournisseurs_Method_DAL depot = new Offres_Fournisseurs_Method_DAL();

        public List<Offres_Fournisseurs> GetAll()
        {
            var offres_fournisseurs = depot.GetAll()
                    .Select(f => new Offres_Fournisseurs(f.ID, f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS))
                    .ToList();

            return offres_fournisseurs;
        }

        public Offres_Fournisseurs GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Offres_Fournisseurs(f.ID, f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS);
        }

        public Offres_Fournisseurs Insert(Offres_Fournisseurs f)
        {
            var offres_fournisseursDal = new Offres_Fournisseurs_DAL(f.ID, f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS);
            depot.Insert(fournisseurDal);

            f.ID = offres_fournisseursDal.ID;

            return f;
        }

        public Offres_Fournisseurs Update(Offres_Fournisseurs f)
        {
            var offres_fournisseursDal = new Offres_Fournisseurs_DAL(f.ID, f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS);
            depot.Update(offres_fournisseursDal);

            return f;
        }

        public void Delete(Offres_Fournisseurs f)
        {
            var offres_fournisseursDal = new Offres_Fournisseurs_DAL(f.ID, f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS);
            depot.Delete(offres_fournisseursDal);
        }
    }
}
