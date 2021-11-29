using api2.Common;
using api2.IServices;
using api2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Services
{
    public class BusinessService : IBusinessService
    {
        Business _negocio = new Business();
        List<Business> _negocios = new List<Business>();

        public Business actualizarNegocio(Business b)
        {
            throw new NotImplementedException();
        }

        public void eliminarNegocio(int id)
        {
            throw new NotImplementedException();
        }

        public Business insertarNegocio(Business b)
        {
            throw new NotImplementedException();
        }

        public List<Business> listarNegocios()
        {
            _negocios = new List<Business>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Business>("obtenerNegocios", commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _negocios = query;
                }
            }

            return _negocios;
        }

        public List<Business> listarNegociosPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
