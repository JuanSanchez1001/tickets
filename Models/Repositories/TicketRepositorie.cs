using System.Data;
using Dapper;
using tickets_web.Models.DTOS;
namespace tickets_web.Models.Interfaces;

public class TicketRepositorie : ITciket
{
    private readonly IDbConnection _dbConnection;
    public TicketRepositorie(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<TicketCategoriasDTO>> getAllCategoria()
    {
        var query = "SELECT * FROM tickets.fn_getcategorias()";
        return await _dbConnection.QueryAsync<TicketCategoriasDTO>(query);
    }
}
