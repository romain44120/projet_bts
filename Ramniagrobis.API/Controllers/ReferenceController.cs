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
        private IReference_detailsService serviceReferenceDetail;

        public ReferenceController(IReferenceService srv, IReference_detailsService srvRefDetail)
        {
            service = srv;
            serviceReferenceDetail = srvRefDetail;
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

        [HttpGet("GetByReference/{reference}")]
        public Reference_DTO GetByReference([FromRoute] string reference)
        {
            var r = service.GetByReference(reference);

            return new Reference_DTO()
            {
                ID = r[0].ID,
                REFERENCE = r[0].REFERENCE,
                LIBELLE = r[0].LIBELLE,
                MARQUE = r[0].MARQUE,
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

        [HttpPost("ImportCSV")]
        public void ImportCSV(string[] referencesCSV, int idFournisseur)
        {
            serviceReferenceDetail.DeleteByIDFournisseur(idFournisseur); //on supprime toutes les anciennes références proposés

            for (var i = 1; i < referencesCSV.Length - 1; i++) // on itère sur chaque ligne
            {
                var referenceCSV = referencesCSV[i].Split(";"); //on split la ligne en fonction des ;

                var referenceBDD = service.GetByReference(referenceCSV[0]);

                if (referenceBDD.Count > 0) //si la référence existe déjà en base de donnée
                {
                    serviceReferenceDetail.Insert(new Reference_details(idFournisseur, referenceBDD[0].ID));
                }
                else //si la référence n'existe pas en base de donnée
                {
                    var referenceTmp = service.Insert(new Reference(referenceCSV[0], referenceCSV[1], referenceCSV[2]));
                    serviceReferenceDetail.Insert(new Reference_details(idFournisseur, referenceTmp.ID));
                }
            }
        }
    }
}
