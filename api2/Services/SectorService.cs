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
    public class SectorService : ISectorsService
    {
        List<Sectors> _sectores = new List<Sectors>();

        public List<Sectors> obtenerSectores()
        {
            _sectores = new List<Sectors>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Sectors>("obtenerSectores", commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _sectores = query;
                }
            }

            return _sectores;
        }
    }
}
