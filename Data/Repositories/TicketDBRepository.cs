using Data.DataContext;
using Domain.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TicketDBRepository : ITickets
    {
        public AirlineDBContext _airlineDbContext {  get; set; }
        
        public TicketDBRepository(AirlineDBContext airlineDBContext) {
            _airlineDbContext = airlineDBContext;
        }

        public void Book(Ticket ticket)
        {
            _airlineDbContext.Tickets.Add(ticket);
            _airlineDbContext.SaveChanges();
        }

        public void Cancel()
        {

        }

        public IQueryable<Ticket> GetTickets()
        {
            return null;
        }
    }
}
