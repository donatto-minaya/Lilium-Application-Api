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
    public class LoginService : ILoginService
    {
        List<Login> _usuario = new List<Login>();

        public List<Login> logearUsuario(string correo, string clave)
        {
            _usuario = new List<Login>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Login>("loginUsuario", this.SetParameters(correo, clave),
                    commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _usuario = query;
                }
            }

            return _usuario;
        }

        private DynamicParameters SetParameters(string correo, string clave)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@correo", correo);
            p.Add("@clave", clave);
            return p;
        }
    }
}
