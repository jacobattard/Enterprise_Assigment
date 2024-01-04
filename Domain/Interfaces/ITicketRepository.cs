﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketRepository
    {
        void Book(Ticket ticket);
        void Cancel(Guid ticketId);
        List<Ticket> GetTickets();
    }
}
