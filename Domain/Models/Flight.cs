using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Flight
    {
        public Flight() {
            //Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
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
