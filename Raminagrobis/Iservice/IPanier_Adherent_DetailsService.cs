using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IPanier_Adherent_DetailsService
    {
        public List<Panier_Adherent_Details> GetAll();
        public Panier_Adherent_Details GetByID(int ID);
        public Panier_Adherent_Details Insert(Panier_Adherent_Details f);
        public Panier_Adherent_Details Update(Panier_Adherent_Details f);
        public void Delete(Panier_Adherent_Details f);
    }
}
