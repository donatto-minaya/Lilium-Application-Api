using api2.Common;
using api2.IServices;
using api2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Services
{
    public class CustomerService : ICustomerService
    {
        Customer _customer = new Customer();
        List<Customer> _customers = new List<Customer>();

        public Customer actualizarCliente(Customer c)
        {
            throw new NotImplementedException();
        }

        public Customer eliminarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void eliminarClientePorCompleto(int id)
        {
            try
            {
                _customer = new Customer()
                {
                    user_id = id
                };

                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Customer>("insertarCliente",
                        this.SetParameters(_customer), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _customer = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }
        }

        public Customer insertarCliente(Customer c)
        {
            _customer = new Customer();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Customer>("insertarCliente", 
                        this.SetParameters(c), commandType: CommandType.StoredProcedure);

                    if(query != null && query.Count() > 0)
                    {
                        _customer = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _customer;
        }

        public List<Customer> listarClientes()
        {
            _customers = new List<Customer>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Customer>("seleccionarClientes", commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _customers = query;
                }
            }

            return _customers;
        }

        public List<Customer> listarClientesPorTag(string tag)
        {
            throw new NotImplementedException();
        }

        private DynamicParameters SetParameters(Customer c)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@nombre", c.user_name);
            p.Add("@apellido", c.user_lastname);
            p.Add("@clave", c.user_password);
            p.Add("@correo", c.user_email);
            return p;
        }
    }
}
