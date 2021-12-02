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

        void eliminarActividadesCompletasEmpresa(int id);
        List<Tasks> listarActividadesPorEmpresa(int companyId);
        List<Tasks> listarActividadesCompletas(int companyId);
    }
}
