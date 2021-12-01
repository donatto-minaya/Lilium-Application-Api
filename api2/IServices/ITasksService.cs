using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api2.Models;

namespace api2.IServices
{
    public interface ITasksService
    {
        Tasks insertarActividad(Tasks t);
        Tasks actualizarActividad(Tasks t);
        Tasks actividadCompletada(int id);
        void eliminarActividadesEmpresa(int id);
        List<Tasks> listarActividadesPorEmpresa(int companyId);
    }
}
