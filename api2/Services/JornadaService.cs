using api2.Common;
using api2.IServices;
using api2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace api2.Services
{
    public class JornadaService : IJornadaService
    {
        List<Jornadas> _jornadas = new List<Jornadas>();

        public List<Jornadas> listarJornadas()
        {
            _jornadas = new List<Jornadas>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Jornadas>("obtenerJornadas", commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _jornadas = query;
                }
            }

            return _jornadas;
        }
    }
}
