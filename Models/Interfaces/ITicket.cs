namespace tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;


public interface ITicket
{
    Task<IEnumerable<TicketCategoriasDTO>> getAllCategorias();
}
