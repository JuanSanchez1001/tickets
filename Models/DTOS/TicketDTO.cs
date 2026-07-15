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
public class TicketPrioridadDTO
{
    public int id_prioridad { get;set; }
    public string descripcion { get;set; } = string.Empty;
}
public class TicketEstatusDTO
{
    public int id_estatus { get;set; }
    public string descripcion { get;set; } = string.Empty;
}
public class TableTicketsDTO
{
    public int id_ticket { get; set; }
    public string titulo { get; set; } = string.Empty;
    public string user_owner { get; set; } = string.Empty;
    public string category { get;set; } = string.Empty;
    public string subcategory { get; set; } = string.Empty;
    public string failure { get;set; } = string.Empty;
    public string v_date { get;set; } = string.Empty;
    public string priority { get;set; } = string.Empty;
    public string status { get;set; } = string.Empty;
    public string responsible { get;set; } = string.Empty;
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