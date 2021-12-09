using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IPanier_AdherentService
    {
        public List<Panier_Adherent> GetAll();
        public Panier_Adherent GetByID(int ID);
        public Panier_Adherent Insert(Panier_Adherent f);
        public Panier_Adherent Update(Panier_Adherent f);
        public void Delete(Panier_Adherent f);
    }
}
