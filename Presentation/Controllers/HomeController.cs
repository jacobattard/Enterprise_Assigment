using Domain.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Models.ViewModels;
using System.Diagnostics;
using Domain.Interfaces;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlights _flightRepository;

        public HomeController(ILogger<HomeController> logger, IFlights flightRepository)
        {
            _logger = logger;
            _flightRepository = flightRepository;
        }

        public IActionResult Index()
        {
            IQueryable<Flight> list = _flightRepository.GetFlights().OrderBy(x => x.Id);

            var output = (from p in list
                          select new ListFlightsViewModel()
                          {
                              Id = p.Id,
                              Rows = p.Rows,
                              Columns = p.Columns,
                              DepartureDate = p.DepartureDate,
                              ArrivalDate = p.ArrivalDate,
                              CountryFrom = p.CountryFrom,
                              CountryTo = p.CountryTo,
                              WholesalePrice = p.WholesalePrice,
                              CommisionRate = p.CommisionRate
                          }).ToList();

            return View(output);


        }

        public IActionResult Seats(Guid flightId)
        {

            var flightDetails = _flightRepository.GetFlight(flightId);

            if (flightDetails != null)
            {
                var viewModel = new ListFlightsViewModel
                {
                    Id = flightDetails.Id,
                    Rows = flightDetails.Rows,
                    Columns = flightDetails.Columns,
                    WholesalePrice = flightDetails.WholesalePrice,
                    CommisionRate= flightDetails.CommisionRate
                    // Other necessary details for the booking form
                };

                return View("Seats", viewModel); // Render the booking form view
            }

            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
