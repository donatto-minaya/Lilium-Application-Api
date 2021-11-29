using api2.Common;
using api2.IServices;
using api2.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;

namespace api2.Services
{

    public class AdvertisementsService : IAdvertisementsService
    {
        Advertisements _anuncioTrabajo = new Advertisements();
        List<Advertisements> _listaAnuncios = new List<Advertisements>();

        public void eliminarTrabajo(string id)
        {
            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@id", id);
                cn.Execute("eliminarAnuncio", p, commandType: CommandType.StoredProcedure);
            }
        }

        public Advertisements insertarAnuncio(Advertisements a)
        {
            _anuncioTrabajo = new Advertisements();

            try
            {
                using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    var query = cn.Query<Advertisements>("crearAnuncio",
                        this.SetParameters(a), commandType: CommandType.StoredProcedure);

                    if (query != null && query.Count() > 0)
                    {
                        _anuncioTrabajo = query.FirstOrDefault();
                    }
                }
            }

            catch
            {
                throw;
            }

            return _anuncioTrabajo;
        }

        public List<Advertisements> listarTrabajos()
        {
            _listaAnuncios = new List<Advertisements>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Advertisements>("obtenerAnuncios", commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _listaAnuncios = query;
                }
            }

            return _listaAnuncios;
        }

        public List<Advertisements> listarTrabajosDeEmpresa(string id)
        {
            _listaAnuncios = new List<Advertisements>();

            using (IDbConnection cn = new SqlConnection(Global.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                var query = cn.Query<Advertisements>("obtenerAnuncioPorEmpresa", this.SetParameter(id), commandType: CommandType.StoredProcedure).ToList();

                if (query != null && query.Count() > 0)
                {
                    _listaAnuncios = query;
                }
            }

            return _listaAnuncios;
        }

        private DynamicParameters SetParameter(string id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", id);
            return p;
        }

        private DynamicParameters SetParameters(Advertisements a)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@titulo", a.title);
            p.Add("@id_empresa", a.company_id);
            p.Add("@descripcion", a.description);
            p.Add("@tipoJornada", a.tipoJornadaId);
            return p;
        }
    }

}
