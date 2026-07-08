namespace tickets_web.Models.DTOS;

public class TicketCategoriasDTO
{
    public long id_cat { get;set; }
    public string descripcion { get;set; } = string.Empty;
}
public class TicketSubCategoriasDTO
{
    public int id_subcat { get;set; }
    public string descripcion { get;set; } = string.Empty;
    //public int categoria_idf { get;set; }
}
public class TicketFallosDTO
{
    public int id_fallo { get;set; }
    public string descripcion { get;set; } = string.Empty;
    //public int subcategoria_idf { get;set; }
}
public class NewTicketDTO
{
    public int nomina { get;set; }
    public string title { get;set; } = string.Empty;
    public int id_cat { get;set; }
    public int id_subcat { get;set; }
    public int id_failure { get;set; }
    public string descripcion { get;set; } = string.Empty;
}
