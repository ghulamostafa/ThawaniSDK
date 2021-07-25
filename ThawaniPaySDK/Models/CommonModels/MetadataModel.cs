using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThawaniPaySDK.Models.CommonModels
{
    public class MetadataModel
    {
        [Required]
        public string customer_name { get; set; }
        [Required]
        [EmailAddress]
        public string customer_email { get; set; }
        [Required]
        [Phone]
        public string customer_phone { get; set; }
        public string customer_id { get; set; } = "";
        public string order_id { get; set; } = "";
    }
}
