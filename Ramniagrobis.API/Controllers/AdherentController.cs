using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis.DAL;
using Raminagrobis.DTO;
using Raminagrobis;

namespace Ramniagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdherentController : Controller
    {
        private Raminagrobis.IAdherentService service;

        public AdherentController(IAdherentService srv)
        {
            service = srv;
        }

        [HttpGet("All")]
        public IEnumerable<Adherent_DTO> GetAllAdherent()
        {
            return service.GetAll().Select(f => new Adherent_DTO()
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
        public Adherent_DTO Insert(Adherent_DTO f)
        {
            var f_metier = service.Insert(new Adherent(f.SOCIETE, f.CIVILITE, f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE,f.DATEADHESION, f.STATUS));

            //Je récupère l'ID
            f.ID = f_metier.ID;

            return f;
        }

        [HttpGet("{id}")]
        public Adherent_DTO GetAdherentByID([FromRoute] int id)
        {
            var f = service.GetByID(id);

            return new Adherent_DTO()
            {
                ID = f.ID,
                SOCIETE = f.SOCIETE,
                CIVILITE = f.CIVILITE,
                NOM = f.NOM,
                PRENOM = f.PRENOM,
                EMAIL = f.EMAIL,
                ADRESSE = f.ADRESSE,
                DATEADHESION = f.DATEADHESION,
                STATUS = f.STATUS
            };
        }

        [HttpPut]
        public Adherent_DTO PutFournisseur(Adherent_DTO f)
        {
            var f_metier = service.Update(new Adherent(f.ID, f.SOCIETE, f.CIVILITE , f.NOM, f.PRENOM, f.EMAIL, f.ADRESSE, f.DATEADHESION, f.STATUS));
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
        public void DeleteAdherent(int id)
        {
            var f_metier = service.GetByID(id);

            service.Delete(f_metier);
        }
    }
}
