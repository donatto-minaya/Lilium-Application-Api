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
    public class TaskController : ControllerBase
    {
        private ITasksService interfas;

        public TaskController(ITasksService interfas2)
        {
            interfas = interfas2;
        }

        [HttpPost]
        public Tasks Post([FromBody] Tasks actividad)
        {
            if (ModelState.IsValid) return interfas.insertarActividad(actividad);
            return null;
        }

        [HttpGet("{id}")]
        public IEnumerable<Tasks> Get(string id)
        {
            return interfas.listarActividadesPorEmpresa(Convert.ToInt32(id));
        }

        [HttpPut]
        public Tasks Put([FromBody] Tasks actividad)
        {
            if (ModelState.IsValid) return interfas.actualizarActividad(actividad);
            return null;
        }

        [HttpPut("{id}")]
        public Tasks TaskFinalized(string id)
        {
            if (ModelState.IsValid) return interfas.actividadCompletada(Convert.ToInt32(id));
            return null;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Tasks> Delete(string id)
        {
            interfas.eliminarActividadesEmpresa(Convert.ToInt32(id));
            return null;
        }
    }
}
