using api2.IServices;
using api2.Models;
using api2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornadasController : ControllerBase
    {
        private IJornadaService interfas;
        public JornadasController(IJornadaService interfas2)
        {
            interfas = interfas2;
        }

        [HttpGet]
        public IEnumerable<Jornadas> GetCustomer()
        {
            return interfas.listarJornadas();
        }
    }
}
