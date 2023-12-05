using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Models.ViewModels
{
    public class ListTicketsViewModel
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        [ForeignKey("Flight")]
        public Guid FlightIdFK { get; set; }
        public string Passport { get; set; }
        public double PricePaid { get; set; }
        public bool Cancelled { get; set; }
    }
}
