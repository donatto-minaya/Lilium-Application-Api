using api2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using api2.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService interfas;

        public LoginController(ILoginService interfas2)
        {
            interfas = interfas2;
        }

        [HttpGet("{correo}/{clave}")]
        public IEnumerable<Login> GetUsuario(string correo, string clave)
        {
            return interfas.logearUsuario(correo, clave);
        }
    }
}
