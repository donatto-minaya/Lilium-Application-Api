using api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.IServices
{
    public interface IBusinessService
    {
        Business insertarNegocio(Business b);
        Business actualizarNegocio(Business b);
        void eliminarNegocio(int id); //Lo elimina por completo
        List<Business> listarNegocios();
        List<Business> listarNegociosPorNombre(string nombre);
    }
}
