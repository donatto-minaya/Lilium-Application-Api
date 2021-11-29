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
    public class ProfesionalController : ControllerBase
    {
        private IProfesionalService interfas;

        public ProfesionalController(IProfesionalService interfas2)
        {
            interfas = interfas2;
        }

        // GET: api/<ProfesionalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProfesionalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProfesionalController>
        [HttpPost]
        public Profesional  Post([FromBody] Profesional profesional)
        {
            if (ModelState.IsValid) return interfas.insertarProfesional(profesional);
            return null;
        }

        // PUT api/<ProfesionalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfesionalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
