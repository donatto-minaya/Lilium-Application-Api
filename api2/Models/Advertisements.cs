using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Models
{
    public class Advertisements
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string empresa { get; set; }
        public string negocio { get; set; }
        public string descripcionNegocio { get; set; }
        public string tipoJornada { get; set; }
        public string fechaCreacion { get; set; }

        // post
        public string jobId { get; set; }
        public string title { get; set; }
        public string company_id { get; set; }
        public string description { get; set; }
        public string tipoJornadaId { get; set; }
        public string fechaCreada { get; set; }
    }
}
