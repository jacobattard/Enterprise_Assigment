using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Flight
    {
        public int Id { get; set; }
        public string Rows { get; set; }
        public string Columns { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public string WholesalePrice { get; set; }
        public string CommisionRate { get; set; }
    }
}
