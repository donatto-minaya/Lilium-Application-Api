using System.ComponentModel.DataAnnotations;

namespace api2.Models
{
    public class Sectors
    {
        [Key]
        public int sector_id { get; set; }
        public string sector_description { get; set; }
    }
}
