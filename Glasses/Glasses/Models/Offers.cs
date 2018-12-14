using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glasses.Models
{
    public class Offers
    {
        public int Offers_ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal totalOffer { get; set; }
    }
}
