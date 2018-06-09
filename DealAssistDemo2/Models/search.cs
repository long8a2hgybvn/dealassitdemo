using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DealAssistDemo2.Models
{
    public class search
    {
        [Required]
        public string inputstring { get; set; }
    }
}