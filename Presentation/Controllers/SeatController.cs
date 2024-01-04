using Data.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Presentation.Models.ViewModels;


namespace Presentation.Controllers
{
    public class SeatController : Controller
    {

        //public ITickets _ticketRepository;
        public ITicketRepository _JsonTicketRepository;
        public IWebHostEnvironment _hostEnvironment;

        public SeatController(IWebHostEnvironment hostEnvironment, ITicketRepository ticketRepository)
        {
            _hostEnvironment = hostEnvironment;
            _JsonTicketRepository = ticketRepository;
        }

        [HttpPost]
        public IActionResult SeatBooking(Ticket ticket, IFormFile passportImage)
        {
            if (passportImage != null && passportImage.Length > 0)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + passportImage.FileName;
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    passportImage.CopyTo(fileStream);
                }

                ticket.PassportImagePath = filePath;
            }

            var bookedSeats = _JsonTicketRepository.GetTickets().Where(t =>
                t.FlightIdFK == ticket.FlightIdFK && t.Row == ticket.Row && t.Column == ticket.Column);

            if (bookedSeats.Any())
            {
                TempData["ErrorMessage"] = "Seat is already booked.";
                return RedirectToAction("Index", "Home");
            }

            _JsonTicketRepository.Book(ticket);

            return RedirectToAction("Index", "Home");
        }




    }
}
