using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADRIENDEMO.Areas.security.Models
{
    public class userview
    {
        public int id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min of 5 Characters")]
        [MaxLength(10, ErrorMessage = "Min of 10 Characters")]
        public string Firstname { get; set; }

        [Required, Display(Name = "Family Name")]
        public string Lastname { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
    }
}