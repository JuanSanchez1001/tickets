namespace tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;


public interface ITicket
{
    Task<IEnumerable<TicketCategoriasDTO>> getAllCategorias();
    Task<IEnumerable <TicketSubCategoriasDTO>> getAllSubCategorias(int id_cat);
    Task<IEnumerable<TicketFallosDTO>> getAllFallos(int id_subcat);

    Task <int>CreateNewTicket(NewTicketDTO dto);
}
