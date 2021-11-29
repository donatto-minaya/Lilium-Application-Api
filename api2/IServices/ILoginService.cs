using api2.Models;
using System.Collections.Generic;

namespace api2.IServices
{
    public interface ILoginService
    {
        List<Login> logearUsuario(string correo, string clave);
    }
}
