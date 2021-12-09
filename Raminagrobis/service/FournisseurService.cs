using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class FournisseurService : IFournisseurService
    {
        private FournisseurMethod_DAL depot = new FournisseurMethod_DAL();

        public List<Fournisseur> GetAll()
        {
            var fournisseurs = depot.GetAll()
                    .Select(f => new Fournisseur(f.ID, f.SOCIETE,f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS))
                    .ToList();

            return fournisseurs;
        }

        public Fournisseur GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Fournisseur(f.ID, f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS);
        }

        public Fournisseur Insert(Fournisseur f)
        {
            var fournisseurDal = new Fournisseur_DAL(f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS);
            depot.Insert(fournisseurDal);

            f.ID = fournisseurDal.ID;

            return f;
        }

        public Fournisseur Update(Fournisseur f)
        {
            var fournisseurDal = new Fournisseur_DAL(f.ID, f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS);
            depot.Update(fournisseurDal);

            return f;
        }

        public void Delete(Fournisseur f)
        {
            var fournisseurDal = new Fournisseur_DAL(f.ID, f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS);
            depot.Delete(fournisseurDal);
        }
    }
}
