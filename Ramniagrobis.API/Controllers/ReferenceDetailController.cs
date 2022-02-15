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
    public class ReferenceDetailController : Controller
    {
        private IReference_detailsService service;

        public ReferenceDetailController(IReference_detailsService srv)
        {
            service = srv;
        }

        [HttpGet("AllReferencesDetails")]
        public IEnumerable<Reference_details_DTO> GetAllAdherent()
        {
            return service.GetAll().Select(f => new Reference_details_DTO()
            {
                ID = f.ID,
                ID_FOURNISSEURS = f.ID_FOURNISSEURS,
                ID_REFERENCE = f.ID_REFERENCE
            });
        }

        [HttpPost]
        public Reference_details_DTO Insert(Reference_details_DTO f)
        {
            var f_metier = service.Insert(new Reference_details(f.ID_FOURNISSEURS, f.ID_REFERENCE));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }
        [HttpGet("GetReferenceDetailsByFournisseur")]
        public IEnumerable<Reference_details_DTO> GetReferenceDetailByFournisseur(int ID)
        {
            return service.GetByIDFournisseur(ID).Select(f => new Reference_details_DTO()
            {
                ID = f.ID,
                ID_FOURNISSEURS = f.ID_FOURNISSEURS,
                ID_REFERENCE = f.ID_REFERENCE
            });
        }

        [HttpGet("{id}")]
        public Reference_details_DTO GetAdherentByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Reference_details_DTO()
            {
                ID = f.ID,
                ID_FOURNISSEURS = f.ID_FOURNISSEURS,
                ID_REFERENCE = f.ID_REFERENCE
            };
        }


        [HttpPut]
        public Reference_details_DTO PutFournisseur(Reference_details_DTO f)
        {
            var f_metier = service.Update(new Reference_details(f.ID, f.ID_FOURNISSEURS, f.ID_REFERENCE));
            f.ID = f_metier.ID;
            f.ID_FOURNISSEURS = f_metier.ID_FOURNISSEURS;
            f.ID_REFERENCE = f_metier.ID_REFERENCE;

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
