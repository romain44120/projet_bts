using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Panier_Adherent_DetailsService : IPanier_Adherent_DetailsService
    {
        private Panier_Adherent_Details_Method_DAL depot = new Panier_Adherent_Details_Method_DAL();

        public List<Panier_Adherent_Details> GetAll()
        {
            var panier_adherent_details = depot.GetAll()
                    .Select(f => new Panier_Adherent_Details(f.ID, f.QUANTITE, f.ID_REFERENCE, f.ID_PANIER_ADHERENT))
                    .ToList();

            return panier_adherent_details;
        }

        public Panier_Adherent_Details GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Panier_Adherent_Details(f.ID, f.QUANTITE, f.ID_REFERENCE, f.ID_PANIER_ADHERENT);
        }

        public Panier_Adherent_Details Insert(Panier_Adherent_Details f)
        {
            var panier_adherent_detailsDal = new Panier_Adherent_Details_DAL(f.QUANTITE, f.ID_REFERENCE, f.ID_PANIER_ADHERENT);
            depot.Insert(panier_adherent_detailsDal);

            f.ID = panier_adherent_detailsDal.ID;

            return f;
        }

        public Panier_Adherent_Details Update(Panier_Adherent_Details f)
        {
            var panier_adherent_detailsDal = new Panier_Adherent_Details_DAL(f.ID, f.QUANTITE, f.ID_REFERENCE, f.ID_PANIER_ADHERENT);
            depot.Update(panier_adherent_detailsDal);

            return f;
        }

        public void Delete(Panier_Adherent_Details f)
        {
            var panier_adherent_detailsDal = new Panier_Adherent_Details_DAL(f.ID, f.QUANTITE, f.ID_REFERENCE, f.ID_PANIER_ADHERENT);
            depot.Delete(panier_adherent_detailsDal);
        }
    }
}
