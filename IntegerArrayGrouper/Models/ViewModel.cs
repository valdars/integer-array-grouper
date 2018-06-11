using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntegerArrayGrouper.Models
{
    public class ViewModel
    {
        [Required]
        [Display(Name = "Input")]
        public string Input { get; set; }

        [Display(Name = "Output")]
        public string Output { get; set; }

        public bool IsError { get; set; }
    }
}