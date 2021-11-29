using api2.IServices;
using api2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private ISectorsService interfas;

        public SectorsController(ISectorsService interfas2)
        {
            interfas = interfas2;
        }

        [HttpGet]
        public IEnumerable<Sectors> GetSectors()
        {
            return interfas.obtenerSectores();
        }
    }
}
