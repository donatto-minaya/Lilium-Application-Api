using api2.Models;
using System.Collections.Generic;

namespace api2.IServices
{
    public interface ICustomerService
    {
        Customer insertarCliente(Customer c);
        Customer actualizarCliente(Customer c);
        void eliminarClientePorCompleto(int id); // Eliminar por completo
        Customer eliminarCliente(int id); // Desactivar cuenta
        List<Customer> listarClientes();
        List<Customer> listarClientesPorTag(string tag);
    }
}
