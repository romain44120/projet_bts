using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class AdherentService : IAdherentService
    {
        public AdherentMethod_DAL depot = new AdherentMethod_DAL();

        public List<Adherent> GetAll()
        {
            var adherent = depot.GetAll()
                    .Select(f => new Adherent(f.ID, f.SOCIETE,f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.DATEADHESION, f.STATUS))
                    .ToList();

            return adherent;
        }

        public Adherent GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Adherent(f.ID, f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.DATEADHESION, f.STATUS);
        }

        public Adherent Insert(Adherent f)
        {
            var adherentDal = new Adherent_DAL(f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.DATEADHESION, f.STATUS);
            depot.Insert(adherentDal);

            f.ID = adherentDal.ID;

            return f;
        }

        public Adherent Update(Adherent f)
        {
            var adherentDal = new Adherent_DAL(f.ID, f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.DATEADHESION, f.STATUS);
            depot.Update(adherentDal);

            return f;
        }

        public void Delete(Adherent f)
        {
            var adherentDal = new Adherent_DAL(f.ID, f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.DATEADHESION, f.STATUS );
            depot.Delete(adherentDal);
        }
    }
}
