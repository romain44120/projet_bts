using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Panier_Global_DetailsService : IPanier_Global_DetailsService
    {
        private Panier_Global_Details_Method_DAL depot = new Panier_Global_Details_Method_DAL();

        public List<Panier_Global_Details> GetAll()
        {
            var panier_global_details = depot.GetAll()
                    .Select(f => new Panier_Global_Details(f.ID, f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL))
                    .ToList();

            return panier_global_details;
        }
   
        public Panier_Global_Details GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Panier_Global_Details(f.ID, f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL);
        }


        public Panier_Global_Details Insert(Panier_Global_Details f)
        {
            var panier_global_detailsDal = new Panier_Global_Details_DAL(f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL);
            depot.Insert(panier_global_detailsDal);

            f.ID = panier_global_detailsDal.ID;

            return f;
        }

        public Panier_Global_Details Update(Panier_Global_Details f)
        {
            var panier_global_detailsDal = new Panier_Global_Details_DAL(f.ID, f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL);
            depot.Update(panier_global_detailsDal);

            return f;
        }

        public void Delete(Panier_Global_Details f)
        {
            var panier_global_detailsDal = new Panier_Global_Details_DAL(f.ID, f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL);
            depot.Delete(panier_global_detailsDal);
        }

        public List<Panier_Global_Details> GetByIDPanierGlobal(int ID)
        {
            var panier_global_details = depot.GetByIDPanierGlobal(ID)
                    .Select(f => new Panier_Global_Details(f.ID, f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL))
                    .ToList();

            return panier_global_details;
        }
    }
}
