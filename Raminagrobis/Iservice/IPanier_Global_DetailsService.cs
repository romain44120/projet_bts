using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IPanier_Global_DetailsService
    {
        public List<Panier_Global_Details> GetAll();
        public Panier_Global_Details GetByID(int ID);
        public Panier_Global_Details Insert(Panier_Global_Details f);
        public Panier_Global_Details Update(Panier_Global_Details f);
        public void Delete(Panier_Global_Details f);

        public List<Panier_Global_Details> GetByIDPanierGlobal(int ID);
    }
}
