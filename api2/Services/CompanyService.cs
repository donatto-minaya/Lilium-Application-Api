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
    public class CompanyService : ICompanyService
    {
        Company _empresa = new Company();
        List<Company> _empresas = new List<Company>();

        public Company actualizarEmpresa(Company c)
        {
            _empresa = new Company();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Company>("editarEmpresa",
                        this.SetParametersEdit(c), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _empresa = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _empresa;
        }

        public Company eliminarEmpresa(int id)
        {
            throw new NotImplementedException();
        }

        public Company insertarEmpresa(Company c)
        {
            _empresa = new Company();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Company>("crearEmpresa",
                        this.SetParameters(c), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _empresa = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _empresa;
        }

        public List<Company> listarEmpresas()
        {
            _empresas = new List<Company>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Company>("obtenerEmpresas", commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _empresas = query;
                }
            }

            return _empresas;
        }

        public List<Company> listarEmpresasPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        //Edit
        private DynamicParameters SetParametersEdit(Company c)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", c.company_id);

            if(c.company_name != "")
                p.Add("@nombre", c.company_name); 

            else
                p.Add("@nombre", null); 

            if(c.company_age != "")
                p.Add("@edad", c.company_age); 

            else
             p.Add("@edad", null); 

            if(c.company_email != "")
                p.Add("@correo", c.company_email);
            else
                p.Add("@correo", null);


            if(c.company_password != "")
                p.Add("@clave", c.company_password);
            else
                p.Add("@clave", null);

            if (c.company_phone != "")
                p.Add("@telefono", c.company_phone);

            else
                p.Add("@telefono", null);
            return p;
        }

        // Post
        private DynamicParameters SetParameters(Company c)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@empresa", c.company_name);
            p.Add("@correoEmpresa", c.company_email);
            p.Add("@claveEmpresa", c.company_password);

            if (c.company_age != "")
            {
                p.Add("@edad", c.company_age);
            }

            else
            {
                p.Add("@edad", null);
            }

            if (c.company_paypal_email != "")
            {
                p.Add("@correoPaypal", c.company_paypal_email);
            } 
            
            else
            {
                p.Add("@correoPaypal", null);
            }
            return p;
        }
    }
}
