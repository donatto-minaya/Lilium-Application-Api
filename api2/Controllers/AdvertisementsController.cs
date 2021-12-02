using api2.IServices;
using api2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private IAdvertisementsService interfas;

        public AdvertisementsController(IAdvertisementsService interfas2)
        {
            interfas = interfas2;
        }

        [HttpPost]
        public Advertisements PostAnuncio([FromBody] Advertisements advertisements)
        {
            if (ModelState.IsValid) return interfas.insertarAnuncio(advertisements);
            return null;
        }

        [HttpGet]
        public IEnumerable<Advertisements> GetCustomer()
        {
            return interfas.listarTrabajos();
        }

        [HttpGet("{id}")]
        public IEnumerable<Advertisements> GetTrabajos(string id)
        {
            return interfas.listarTrabajosDeEmpresa(id);
        }
        
        
        [HttpDelete("{id}")]
        public IEnumerable<Advertisements> Delete(string id)
        {
            interfas.eliminarTrabajo(id);
            return null;
        }
    }
}
