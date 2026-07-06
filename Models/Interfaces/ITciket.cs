using tickets_web.Models.DTOS;
namespace tickets_web.Models.Interfaces;

public interface ITciket
{
    Task<IEnumerable<TicketCategoriasDTO>> getAllCategoria();
}