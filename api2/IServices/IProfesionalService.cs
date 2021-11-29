using api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.IServices
{
    public interface IProfesionalService
    {
        Profesional insertarProfesional(Profesional p);
        Profesional actualizarProfesional(Profesional p);
        Profesional eliminarCuenta(int id);
        List<Profesional> listarProfesionales();
        List<Profesional> listarProfesionalesPorNombre(string nombre);
    }
}
