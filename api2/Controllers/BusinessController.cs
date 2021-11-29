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
    public class BusinessController : ControllerBase
    {
        private IBusinessService interfas;

        public BusinessController(IBusinessService interfas2)
        {
            interfas = interfas2;
        }

        [HttpGet]
        public IEnumerable<Business> GetBusiness()
        {
            return interfas.listarNegocios();
        }
    }
}
