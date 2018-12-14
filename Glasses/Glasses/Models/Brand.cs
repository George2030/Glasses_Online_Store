using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glasses.Models
{
    public class Brand
    {
        [Key]
        public int Brand_ID { get; set; }
        public string Glassbrand { get; set; }
        
        public ICollection<Glass> Glasses { get; set; } = new List<Glass>();

    }
}
