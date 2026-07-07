namespace tickets_web.Models.DTOS;

public class TicketCategoriasDTO
{
    public long id_cat { get;set; }
    public string descripcion { get;set; } = string.Empty;
}
public class TicketSubCategoriasDTO
{
    public int id_subcategoria { get;set; }
    public string descripcion { get;set; } = string.Empty;
    public int categoria_idf { get;set; }
}
public class TicketFallosDTO
{
    
}