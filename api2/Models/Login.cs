using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Models
{
    public class Login
    {
        //Post
        public string correo { get; set; }
        public string clave { get; set; }

        //Get
        public string user_id { get; set; }
        public string rol_id { get; set; }
        public string user_name { get; set; }
        public string user_lastname { get; set; }
        public string user_age { get; set; }
        public string user_phone { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }

        //Profesional
        public string credit_id { get; set; }
        public string user_card_email { get; set; }

        //Company
        public string company_id { get; set; }
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
