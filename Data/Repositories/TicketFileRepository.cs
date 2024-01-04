using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Data.Repositories
{
    public class TicketFileRepository : ITicketRepository
    {
        public const string FilePath = "C:\\Users\\Jacob\\Desktop\\Assigments\\Enterprise\\Jacob_Attard_62A\\Presentation\\JsonData\\tickets.json";

        public void Book(Ticket ticket)
        {
            List<Ticket> tickets = GetTickets();
            ticket.Id = Guid.NewGuid();
            tickets.Add(ticket);

            SaveTickets(tickets);
        }

        public void Cancel(Guid ticketId)
        {
            List<Ticket> tickets = GetTickets();
            Ticket ticketToCancel = tickets.Find(t => t.Id == ticketId);

            if (ticketToCancel != null)
            {
                ticketToCancel.Cancelled = true;
                SaveTickets(tickets);
            }
        }

        public List<Ticket> GetTickets()
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Ticket>>(json);
        }

        private void SaveTickets(List<Ticket> tickets)
        {
            string json = JsonSerializer.Serialize(tickets, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
