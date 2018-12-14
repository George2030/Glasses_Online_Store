using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Glasses.Models
{
    public class Glass
    {
        [Key]
        public int Glass_ID { get; set; }

        public string GName { get; set; }
        public decimal Price { get; set; }


        [ForeignKey("Brand")]
        public int Brand_ID { get; set; }
        public Brand Brand { get; set; }
    }
}
