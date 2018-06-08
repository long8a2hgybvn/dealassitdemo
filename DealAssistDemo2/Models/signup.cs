using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealAssistDemo2.Models
{
    public class signup
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string id { get; set; }
        [Required]
        public string pass { get; set; }
        [Required]
        public string checkpass { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string sdt { get; set; }
        [Required]
        public string ngaysinh { get; set; }
        [Required]
        public string gender { get; set; }
    }
}