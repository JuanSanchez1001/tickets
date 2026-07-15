namespace tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;


public interface ITicket
{
    Task<IEnumerable<TicketCategoriasDTO>> getAllCategorias();
    Task<IEnumerable <TicketSubCategoriasDTO>> getAllSubCategorias(int id_cat);
    Task<IEnumerable<TicketFallosDTO>> getAllFallos(int id_subcat);
    Task<IEnumerable<TicketPrioridadDTO>> getAllPrioridad();
    Task<IEnumerable<TicketEstatusDTO>> getAllEstatus();

    Task <int>CreateNewTicket(NewTicketDTO dto);
    Task <IEnumerable<TableTicketsDTO>> getTicketsTable(DateTime date1, DateTime date2, int id_cat, int id_subcat, int id_fallo, int id_prioridad, int id_estatus, int user);
}
