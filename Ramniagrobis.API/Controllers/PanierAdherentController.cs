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
    public class PanierAdherentController : Controller
    {
        private IPanier_AdherentService service;

        public PanierAdherentController(IPanier_AdherentService srv)
        {
            service = srv;
        }

        [HttpGet("AllFournisseurs")]
        public IEnumerable<Panier_Adherent_DTO> GetAllFournisseurs()
        {
            return service.GetAll().Select(p => new Panier_Adherent_DTO()
            {
                ID = p.ID,
                SEMAINE = p.SEMAINE,
                ID_ADHERENT= p.ID_ADHERENT
            });
        }

        [HttpPost]
        public Panier_Adherent_DTO Insert(Panier_Adherent_DTO p)
        {
            var p_metier = service.Insert(new Panier_Adherent(p.SEMAINE, p.ID_ADHERENT));

            //Je récupère l'ID
            p.ID = p_metier.ID;

            return p;
        }

        [HttpGet("{id}")]
        public Panier_Adherent_DTO GetFournisseurByID([FromRoute] int id)
        {
            var p = service.GetByID(id);

            return new Panier_Adherent_DTO()
            {
                ID = p.ID,
                SEMAINE = p.SEMAINE,
                ID_ADHERENT = p.ID_ADHERENT
            };
        }

        [HttpPut]
        public Panier_Adherent_DTO PutFournisseur(Panier_Adherent_DTO p)
        {
            var p_metier = service.Update(new Panier_Adherent(p.SEMAINE, p.ID_ADHERENT));
            p.ID = p_metier.ID;
            p.SEMAINE = p_metier.SEMAINE;
            p.ID_ADHERENT = p_metier.ID_ADHERENT;

            return p;
        }

        [HttpDelete]
        public void DeleteFournisseur(int id)
        {
            var p_metier = service.GetByID(id);

            service.Delete(p_metier);
        }

    }
}
