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
    public class TaskService : ITasksService
    {
        Tasks _actividad = new Tasks();
        List<Tasks> _actividades = new List<Tasks>();

        public Tasks actividadCompletada(int id)
        {
            _actividad = new Tasks();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Tasks>("actividadTerminada",
                        this.finalize(id), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _actividad = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _actividad;
        }

        public Tasks actualizarActividad(Tasks t)
        {
            _actividad = new Tasks();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Tasks>("editarActividad",
                        this.SetParametersEdit(t), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _actividad = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _actividad;
        }

        public void eliminarActividad(int id)
        {
            throw new NotImplementedException();
        }

        public Tasks insertarActividad(Tasks t)
        {
            _actividad = new Tasks();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Tasks>("crearActividad",
                        this.SetParameters(t), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _actividad = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _actividad;
        }

        public List<Tasks> listarActividadesPorEmpresa(int companyId)
        {
            _actividades = new List<Tasks>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Tasks>("obtenerActividadesPorEmpresa", this.SetParameter(companyId), commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _actividades = query;
                }
            }

            return _actividades;
        }

        private DynamicParameters finalize(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@idTask", id);
            return p;
        }

        private DynamicParameters SetParametersEdit(Tasks t)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@idTask", t.task_id);
            p.Add("@titulo", t.title);
            return p;
        }

        private DynamicParameters SetParameter(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", id);
            return p;
        }

        private DynamicParameters SetParameters(Tasks t)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", t.company_id);
            p.Add("@titulo", t.title);
            return p;
        }
    }
}
