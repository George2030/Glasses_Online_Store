using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glasses_Core_Project.Models
{
    public class Offers
    {
        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal totalOffer { get; set; }
    }
}
