using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Presentation.Models.ViewModels
{
    public class ListFlightsViewModel
    {
        public Guid Id { get; set; } //31F61C7D-61EE-484B-9B39-4FB5BBC2D0B
        public int Rows { get; set; }
        public int Columns { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }
        public double WholesalePrice { get; set; }
        public double CommisionRate { get; set; }

    }
}
