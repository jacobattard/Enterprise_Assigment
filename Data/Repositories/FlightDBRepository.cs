using Data.DataContext;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FlightDBRepository : IFlights
    {
        public AirlineDBContext _airlineContext { get; set; }

        public FlightDBRepository(AirlineDBContext airlineContext)
        {
            _airlineContext = airlineContext;
        }

        public IQueryable<Flight> GetFlights()
        {
            return _airlineContext.Flights;
        }

        public Flight GetFlight(Guid id)    
        {
            return _airlineContext.Flights.SingleOrDefault(x => x.Id == id);
        }

    }
}
