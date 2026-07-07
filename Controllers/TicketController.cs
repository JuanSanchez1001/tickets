using Microsoft.AspNetCore.Mvc;
using System.Data;
using tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;

namespace tickets_web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicket _ticketRepo;

        public TicketController(ITicket iTicket)
        {
            _ticketRepo = iTicket;
        }

        public async Task<IActionResult> CrearTicket()
        {
            var category = await _ticketRepo.getAllCategorias();
            return View(category);
        }

    }
}
