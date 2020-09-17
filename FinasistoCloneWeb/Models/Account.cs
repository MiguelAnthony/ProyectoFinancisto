using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinasistoCloneWeb.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }

        [Required(ErrorMessage = "Campo nombre olbigatorio")]
        public string Name { get; set; }
        public string Currency{ get; set; }
        public decimal Ammount { get; set; }
    }
}
