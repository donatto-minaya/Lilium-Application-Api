using System.ComponentModel.DataAnnotations;

namespace api2.Models
{
    public class Jornadas
    {
        [Key]
        public string tipoJornadaId { get; set; }
        public string jornada { get; set; }
    }
}
