using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Models
{
    public class Company
    {
        [Key]
        public string company_id { get; set; }
        public string rol_id { get; set; }
        public string business_id { get; set; }
        public string company_name { get; set; }
        public string company_time_open { get; set; }
        public string company_time_close { get; set; }
        public string company_age { get; set; }
        public string company_email { get; set; }
        public string company_password { get; set; }
        public string company_paypal_email { get; set; }
        public string company_mastercard_email { get; set; }
        public string company_phone { get; set; }
    }
}
