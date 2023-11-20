using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class FlightDBRepository
    {
        public FlightDBRepository() { }

        public Flight GetFlight(Guid id)
        {
            return null;
        }

        public IQueryable<Flight> GetFlights()
        {
            return null;
        }
    }
}
