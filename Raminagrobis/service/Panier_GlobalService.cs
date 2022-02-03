using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Panier_GlobalService : IPanier_GlobalService
    {
        private Panier_Global_Method_DAL depot = new Panier_Global_Method_DAL();

        public List<Panier_Global> GetAll()
        {
            var panier_global = depot.GetAll()
                    .Select(f => new Panier_Global(f.ID, f.SEMAINE))
                    .ToList();

            return panier_global;
        }

        public Panier_Global GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Panier_Global(f.ID, f.SEMAINE);
        }

        public Panier_Global Insert(Panier_Global f)
        {
            var panier_globalDal = new Panier_Global_DAL(f.SEMAINE);
            depot.Insert(panier_globalDal);

            f.ID = panier_globalDal.ID;

            return f;
        }

        public Panier_Global Update(Panier_Global f)
        {
            var panier_globalDal = new Panier_Global_DAL(f.ID, f.SEMAINE);
            depot.Update(panier_globalDal);

            return f;
        }

        public void Delete(Panier_Global f)
        {
            var panier_globalDal = new Panier_Global_DAL(f.ID,  f.SEMAINE);
            depot.Delete(panier_globalDal);
        }
    }
}
