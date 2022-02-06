using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis;
using Raminagrobis.DAL;
using Raminagrobis.DTO;

namespace Ramniagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FournisseurController : Controller
    {
        private IFournisseurService service;

        public FournisseurController(IFournisseurService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Fournisseur_DTO> GetAllFournisseurs()
        {
            return service.GetAll().Select(f => new Fournisseur_DTO()
            {
                ID = f.ID,
                SOCIETE = f.SOCIETE,
                CIVILITE = f.CIVILITE,
                NOM = f.NOM,
                PRENOM = f.PRENOM,
                EMAIL = f.EMAIL,
                ADRESSE = f.ADRESSE,
                STATUS = f.STATUS,
            });
        }

        [HttpPost]
        public Fournisseur_DTO Insert(Fournisseur_DTO f)
        {
            var f_metier = service.Insert(new Fournisseur(f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }

        [HttpGet("{id}")]
        public Fournisseur_DTO GetFournisseurByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Fournisseur_DTO()
            {
                ID = f.ID,
                SOCIETE = f.SOCIETE,
                CIVILITE = f.CIVILITE,
                NOM = f.NOM,
                PRENOM = f.PRENOM,
                EMAIL = f.EMAIL,
                ADRESSE = f.ADRESSE,
                STATUS = f.STATUS
            };
        }

        [HttpPut]
        public Fournisseur_DTO PutFournisseur(Fournisseur_DTO f)
        {
            var f_metier = service.Update(new Fournisseur(f.ID, f.SOCIETE, f.CIVILITE , f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.STATUS));
            f.ID = f_metier.ID;
            f.SOCIETE = f_metier.SOCIETE;
            f.CIVILITE = f_metier.CIVILITE;
            f.NOM = f_metier.NOM;
            f.PRENOM = f_metier.PRENOM;
            f.EMAIL = f_metier.EMAIL;
            f.ADRESSE = f_metier.ADRESSE;
            f.STATUS = f_metier.STATUS;

            return f;
        }

        [HttpDelete]
        public void DeleteFournisseur(int id)
        {
            var f_metier = service.GetByID(id);

            service.Delete(f_metier);
        }
    }
}
