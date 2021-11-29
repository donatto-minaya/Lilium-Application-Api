using api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.IServices
{
    public interface ICompanyService
    {
        Company insertarEmpresa(Company c);
        Company actualizarEmpresa(Company c);
        Company eliminarEmpresa(int id); // Desactivar
        List<Company> listarEmpresas();
        List<Company> listarEmpresasPorNombre(string nombre);
    }
}
