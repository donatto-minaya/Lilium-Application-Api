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
    public class CompanyController : ControllerBase
    {
        private ICompanyService interfas;

        public CompanyController(ICompanyService interfas2)
        {
            interfas = interfas2;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return interfas.listarEmpresas();
        }

        [HttpPost]
        public Company Post([FromBody] Company empresa)
        {
            if (ModelState.IsValid) return interfas.insertarEmpresa(empresa);
            return null;
        }

        [HttpPut]
        public Company Put([FromBody] Company empresa)
        {
            if (ModelState.IsValid) return interfas.actualizarEmpresa(empresa);
            return null;
        }
    }
}
