using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis;
using Raminagrobis.DTO;

namespace Ramniagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OffreFournisseurController : Controller
    {
        private IOffres_FournisseurService service;

        public OffreFournisseurController(IOffres_FournisseurService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Offres_Fournisseurs_DTO> GetAllAdherent()
        {
            return service.GetAll().Select(f => new Offres_Fournisseurs_DTO
            {
                ID = f.ID,
                ID_FOURNISSEURS = f.ID_FOURNISSEURS,
                ID_PANIER_GLOBALS_DETAILS = f.ID_PANIER_GLOBALS_DETAILS,
                OFFRES = f.OFFRES,
            });
        }

        [HttpPost]
        public Offres_Fournisseurs_DTO Insert(Offres_Fournisseurs_DTO f)
        {
            var f_metier = service.Insert(new Offres_Fournisseurs(f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }

        [HttpGet("{id}")]
        public Offres_Fournisseurs_DTO GetAdherentByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Offres_Fournisseurs_DTO()
            {
                ID = f.ID,
                ID_FOURNISSEURS = f.ID_FOURNISSEURS,
                ID_PANIER_GLOBALS_DETAILS = f.ID_PANIER_GLOBALS_DETAILS,
                OFFRES = f.OFFRES,
            };
        }

        [HttpPut]
        public Offres_Fournisseurs_DTO PutFournisseur(Offres_Fournisseurs_DTO f)
        {
            var f_metier = service.Update(new Offres_Fournisseurs(f.ID, f.OFFRES, f.ID_FOURNISSEURS, f.ID_PANIER_GLOBALS_DETAILS));
            f.ID = f_metier.ID;
            f.ID_FOURNISSEURS = f_metier.ID_FOURNISSEURS;
            f.ID_PANIER_GLOBALS_DETAILS = f_metier.ID_PANIER_GLOBALS_DETAILS;

            return f;
        }

        [HttpDelete]
        public void DeleteAdherent(int id)
        {
            var f_metier = service.GetByID(id);

            service.Delete(f_metier);
        }
    }
}
