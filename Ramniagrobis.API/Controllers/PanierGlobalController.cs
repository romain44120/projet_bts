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
    public class PanierGlobalController : Controller
    {
        private IPanier_GlobalService service;

        public PanierGlobalController(IPanier_GlobalService srv)
        {
            service = srv;
        }

        [HttpGet("AllPanierGlobal")]
        public IEnumerable<Panier_Global_DTO> GetAllFournisseurs()
        {
            return service.GetAll().Select(f => new Panier_Global_DTO()
            {
                ID = f.ID,
                SEMAINE = f.SEMAINE
            });
        }

        [HttpPost]
        public Panier_Global_DTO Insert(Panier_Global_DTO f)
        {
            var f_metier = service.Insert(new Panier_Global(f.ID, f.SEMAINE));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }

        [HttpGet("{id}")]
        public Panier_Global_DTO GetFournisseurByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Panier_Global_DTO()
            {
                ID = f.ID,
                SEMAINE = f.SEMAINE

            };
        }

        [HttpPut]
        public Panier_Global_DTO PutFournisseur(Panier_Global_DTO f)
        {
            var f_metier = service.Update(new Panier_Global(f.ID, f.SEMAINE));
            f.ID = f_metier.ID;
            f.SEMAINE = f_metier.SEMAINE;

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
