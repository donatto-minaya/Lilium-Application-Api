using System.ComponentModel.DataAnnotations;

namespace api2.Models
{
    public class Business
    {
        [Key]
        public int business_id { get; set; }
        public string sector { get; set; }
        public string business_name { get; set; }
        public string business_description { get; set; }
        public string business_location { get; set; }
    }
}
