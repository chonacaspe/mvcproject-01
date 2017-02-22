using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADRIENDEMO.Dal
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public int? Age { get; set; }
        public String Gender { get; set; }
    }
}
