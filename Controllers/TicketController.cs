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

        public async Task<IActionResult> CrearTicket() //Pantalla para crear un ticket
        {
            //var category = await _ticketRepo.getAllCategorias();
            return View();
        }
        public async Task<IActionResult> Table() //Pantalla para ver el listado de los tickets
        {
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
        [HttpGet]
        public async Task<IActionResult> getPrioridad()
        {
            var prioridades = await _ticketRepo.getAllPrioridad();
            return Json(new {prioridades});
        }
        [HttpGet]
        public async Task<IActionResult> getEstatus()
        {
            var estatus = await _ticketRepo.getAllEstatus();
            return Json(new {estatus});
        }
        [HttpGet]
        public async Task<IActionResult> getTableTickets(DateTime date_ini, DateTime date_fin, int idCat, int idSubcat, int idFallo, int idPrioridad, int idEstatus, int user)
        {
            var table = await _ticketRepo.getTicketsTable(date_ini, date_fin, idCat, idSubcat, idFallo, idPrioridad, idEstatus, user);
            return Json(new {table});
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewTicket(NewTicketDTO dto)
        {
            int id_ticket = await _ticketRepo.CreateNewTicket(dto);
            return Json(new{id_ticket});
        }
    }
}
