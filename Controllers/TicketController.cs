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
            //var category = await _ticketRepo.getAllCategorias();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getCategorias()
        {
            var category = await _ticketRepo.getAllCategorias();
            //Console.WriteLine(category);
            return Json(new {category});
        }
        [HttpGet]
        public async Task<IActionResult> getSubCategorias(int id_cat)
        {
            var subcategory = await _ticketRepo.getAllSubCategorias(id_cat);
            return Json(new {subcategory});
        }
        [HttpGet]
        public async Task<IActionResult> getFallos(int id_subcat)
        {
            var fallos = await _ticketRepo.getAllFallos(id_subcat);
            return Json(new {fallos});
        }
    }
}
