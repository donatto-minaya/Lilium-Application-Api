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
    public class ProfesionalService : IProfesionalService
    {
        Profesional _profesional = new Profesional();
        List<Profesional> _profesionales = new List<Profesional>();

        public Profesional actualizarProfesional(Profesional p)
        {
            throw new NotImplementedException();
        }

        public Profesional eliminarCuenta(int id)
        {
            throw new NotImplementedException();
        }

        public Profesional insertarProfesional(Profesional p)
        {
            _profesional = new Profesional();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Profesional>("insertarProfesional",
                        this.SetParameters(p), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _profesional = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _profesional;
        }

        public List<Profesional> listarProfesionales()
        {
            _profesionales = new List<Profesional>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Profesional>("select * from [Accounts].[Profesional]").ToList();

                if (query != null && query.Count() > 0)
                {
                    _profesionales = query;
                }
            }

            return _profesionales;
        }

        public List<Profesional> listarProfesionalesPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        private DynamicParameters SetParameters(Profesional p)
        {
            DynamicParameters d = new DynamicParameters();
            d.Add("@nombre", p.user_name);
            d.Add("@apellido", p.user_lastname);
            d.Add("@correo", p.user_email);
            d.Add("@clave", p.user_password);

            return d;
        }
    }
}
