using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Panier_AdherentService : IPanier_AdherentService
    {
        private Panier_AdherentMethod_DAL depot = new Panier_AdherentMethod_DAL();

        public List<Panier_Adherent> GetAll()
        {
            var panier_adherent = depot.GetAll()
                    .Select(f => new Panier_Adherent(f.ID, f.SEMAINE, f.ID_ADHERENT))
                    .ToList();

            return panier_adherent;
        }

        public Panier_Adherent GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Panier_Adherent(f.ID, f.SEMAINE, f.ID_ADHERENT);
        }

        public Panier_Adherent Insert(Panier_Adherent f)
        {
            var panier_adherentDal = new Panier_Adherent_DAL(f.SEMAINE, f.ID_ADHERENT);
            depot.Insert(panier_adherentDal);

            f.ID = panier_adherentDal.ID;

            return f;
        }

        public Panier_Adherent Update(Panier_Adherent f)
        {
            var panier_adherentDal = new Panier_Adherent_DAL(f.ID, f.SEMAINE, f.ID_ADHERENT);
            depot.Update(panier_adherentDal);

            return f;
        }

        public void Delete(Panier_Adherent f)
        {
            var panier_adherentDal = new Panier_Adherent_DAL(f.ID, f.SEMAINE, f.ID_ADHERENT);
            depot.Delete(panier_adherentDal);
        }
    }
}
