using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Data.Models
{
    public class RecaptchaSettings
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
        public string ApiUrl { get; set; }
    }
}
