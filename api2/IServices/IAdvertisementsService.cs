using api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.IServices
{
    public interface IAdvertisementsService
    {
        Advertisements insertarAnuncio(Advertisements a);
        List<Advertisements> listarTrabajos();
        List<Advertisements> listarTrabajosDeEmpresa(string id);
        void eliminarTrabajo(string id);
    }
}
