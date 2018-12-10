using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glasses_Core_Project.Models
{
    public class Glasses
    {
        [Key]
        
        public string Glassbrand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
