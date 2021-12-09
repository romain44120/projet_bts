using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IPanier_GlobalService
    {
        public List<Panier_Global> GetAll();
        public Panier_Global GetByID(int ID);
        public Panier_Global Insert(Panier_Global f);
        public Panier_Global Update(Panier_Global f);
        public void Delete(Panier_Global f);
    }
}
