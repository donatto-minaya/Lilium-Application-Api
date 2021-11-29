using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Models
{
    public class ApplicationSettings
    {
        public string jwt_secret { get; set; }
        public string client_url { get; set; }
    }
}
