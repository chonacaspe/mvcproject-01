using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace chnprjct.Areas.Privacy.Models
{
    public class UsersViewModel
    {
        public Guid ID  { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min of 3 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required, MaxLength(15, ErrorMessage ="Max of 15 characters")]
        public string LastName { get; set; }

        public int? Age { get; set; }
        public string Gender { get; set; }
    }
}