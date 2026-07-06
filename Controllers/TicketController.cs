using Microsoft.AspNetCore.Mvc;
using System.Data;
using tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;

namespace tickets_web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITciket _Iticket;

        public TicketController(ITciket iTicket)
        {
            _Iticket = iTicket;
        }

        public async Task<IActionResult> CrearTicket()
        {
            var category = await _Iticket.getAllCategoria();
            return View(category);
        }

    }
}
