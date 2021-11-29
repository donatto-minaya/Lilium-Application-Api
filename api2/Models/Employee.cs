using System.ComponentModel.DataAnnotations;

namespace api2.Models
{
    public class Employee
    {
        [Key]
        public int id_employee { get; set; }
        public string user_id { get; set; }
        public string rol_id { get; set; }
        public string employee_number { get; set; }
        public string employee_email { get; set; }
    }
}
