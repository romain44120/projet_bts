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
    public class ReferenceController : Controller
    {
        private IReferenceService service;

        public ReferenceController(IReferenceService srv)
        {
            service = srv;
        }

        [HttpGet("AllReferences")]
        public IEnumerable<Reference_DTO> GetAllReference()
        {
            return service.GetAll().Select(f => new Reference_DTO()
            {
                ID = f.ID,
                REFERENCE = f.REFERENCE,
                LIBELLE = f.LIBELLE,
                MARQUE =f.MARQUE           
            });
        }

        [HttpPost]
        public Reference_DTO Insert(Reference_DTO f)
        {
            var f_metier = service.Insert(new Reference(f.REFERENCE, f.LIBELLE, f.MARQUE));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }

        [HttpGet("{id}")]
        public Reference_DTO GetReferenceByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Reference_DTO()
            {
                ID = f.ID,
                REFERENCE = f.REFERENCE,
                LIBELLE = f.LIBELLE,
                MARQUE = f.MARQUE
            };
        }

        [HttpPut]
        public Reference_DTO PutFournisseur(Reference_DTO f)
        {
            var f_metier = service.Update(new Reference(f.ID,f.REFERENCE, f.LIBELLE, f.MARQUE));
            f.ID = f_metier.ID;
            f.REFERENCE = f_metier.REFERENCE;
            f.LIBELLE = f_metier.LIBELLE;
            f.MARQUE = f_metier.MARQUE;
           

            return f;
        }

        [HttpDelete]
        public void DeleteReference(int id)
        {
            var f_metier = service.GetByID(id);

            service.Delete(f_metier);
        }
    }
}
