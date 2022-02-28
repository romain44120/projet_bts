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
    public class PanierGlobalDetailController : Controller
    {
        private IPanier_Global_DetailsService service;

        public PanierGlobalDetailController(IPanier_Global_DetailsService srv)
        {
            service = srv;
        }

        [HttpGet("AllPanierGlobalDetail")]
        public IEnumerable<Panier_Global_Details_DTO> GetAllPanierGlobal()
        {
            return service.GetAll().Select(f => new Panier_Global_Details_DTO()
            {
                ID = f.ID,
                ID_REFERENCE = f.ID_REFERENCE,
                QUANTITE_GLOBAL = f.QUANTITE_GLOBAL,
                ID_PANIER_GLOBAL = f.ID_PANIER_GLOBAL,
            });
        }
        [HttpGet("GetGlobalDetailByPanier")]
        public IEnumerable<Panier_Global_Details_DTO> GetPanierGlobalDetailByPanier(int ID)
        {
            return service.GetByIDPanierGlobal(ID).Select(f => new Panier_Global_Details_DTO()
            {
                ID = f.ID,
                ID_REFERENCE = f.ID_REFERENCE,
                QUANTITE_GLOBAL = f.QUANTITE_GLOBAL,
                ID_PANIER_GLOBAL = f.ID_PANIER_GLOBAL,
            });
        }


        [HttpPost]
        public Panier_Global_Details_DTO Insert(Panier_Global_Details_DTO f)
        {
            var f_metier = service.Insert(new Panier_Global_Details(f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }

        [HttpGet("{id}")]
        public Panier_Global_Details_DTO GetFournisseurByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Panier_Global_Details_DTO()
            {
                ID = f.ID,
                ID_REFERENCE = f.ID_REFERENCE,
                QUANTITE_GLOBAL = f.QUANTITE_GLOBAL,
                ID_PANIER_GLOBAL = f.ID_PANIER_GLOBAL,

            };
        }

        [HttpPut]
        public Panier_Global_Details_DTO PutFournisseur(Panier_Global_Details_DTO f)
        {
            var f_metier = service.Update(new Panier_Global_Details(f.ID, f.QUANTITE_GLOBAL, f.ID_REFERENCE, f.ID_PANIER_GLOBAL));
            f.ID = f_metier.ID;
            f.QUANTITE_GLOBAL = f_metier.QUANTITE_GLOBAL;
            f.ID_REFERENCE = f_metier.ID_REFERENCE;
            f.ID_PANIER_GLOBAL = f_metier.ID_PANIER_GLOBAL;

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
