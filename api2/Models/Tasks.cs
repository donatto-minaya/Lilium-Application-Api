using System.ComponentModel.DataAnnotations;

namespace api2.Models
{
    public class Tasks
    {
        [Key]
        public string task_id { get; set; }
        public string company_id { get; set; }
        public string title { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTerminada { get; set; }

    }
}
