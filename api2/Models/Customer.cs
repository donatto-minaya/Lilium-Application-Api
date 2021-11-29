using System.ComponentModel.DataAnnotations;

namespace api2.Models
{
    public class Customer
    {
        [Key]
        public int user_id { get; set; }
        public string rol_id { get; set; }
        public string user_name { get; set; }
        public string user_lastname { get; set; }
        public string user_age { get; set; }
        public string user_phone { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
    }
}
