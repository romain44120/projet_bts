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
    public class PanierAdherentDetailController : Controller
    {
        private IPanier_Adherent_DetailsService service;

        public PanierAdherentDetailController(IPanier_Adherent_DetailsService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Panier_Adherent_Details_DTO> GetAllFournisseurs()
        {
            return service.GetAll().Select(p => new Panier_Adherent_Details_DTO()
            {
                ID = p.ID,
                ID_REFERENCE = p.ID_REFERENCE,
                QUANTITE = p.QUANTITE,
                ID_PANIER_ADHERENT = p.ID_PANIER_ADHERENT,

            });
        }

        [HttpPost]
        public Panier_Adherent_Details_DTO Insert(Panier_Adherent_Details_DTO p)
        {
            var p_metier = service.Insert(new Panier_Adherent_Details(p.QUANTITE, p.ID_REFERENCE, p.ID_PANIER_ADHERENT));

            //Je récupère l'ID
            p.ID = p_metier.ID;

            return p;
        }

        [HttpGet("{id}")]
        public Panier_Adherent_Details_DTO GetFournisseurByID([FromRoute] int id)
        {
            var p = service.GetByID(id);

            return new Panier_Adherent_Details_DTO()
            {
                ID = p.ID,
                ID_REFERENCE = p.ID_REFERENCE,
                ID_PANIER_ADHERENT = p.ID_PANIER_ADHERENT,
                QUANTITE = p.QUANTITE
                
            };
        }

        [HttpPut]
        public Panier_Adherent_Details_DTO PutFournisseur(Panier_Adherent_Details_DTO p)
        {
            var p_metier = service.Update(new Panier_Adherent_Details(p.ID, p.QUANTITE, p.ID_REFERENCE, p.ID_PANIER_ADHERENT));
            p.ID = p_metier.ID;
            p.QUANTITE = p_metier.QUANTITE;
            p.ID_REFERENCE = p_metier.ID_REFERENCE;


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
