using System.Data;
using Dapper;
using tickets_web.Models.DTOS;
namespace tickets_web.Models.Interfaces;

public class TicketRepositorie : ITicket
{
    private readonly IDbConnection _dbConnection;
    public TicketRepositorie(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<TicketCategoriasDTO>> getAllCategorias()
    {
        var query = "SELECT * FROM tickets.fn_getcategorias()";
        return await _dbConnection.QueryAsync<TicketCategoriasDTO>(query);
    }
    public async Task<IEnumerable<TicketSubCategoriasDTO>> getAllSubCategorias(int id_cat)
    {
        var query = "SELECT * FROM tickets.fn_getsubcategorias(@v_cat)";
        return await _dbConnection.QueryAsync<TicketSubCategoriasDTO>(query, new{ v_cat =  id_cat});
    }
    public async Task<IEnumerable<TicketFallosDTO>> getAllFallos(int id_subcat)
    {
        var query = "SELECT * FROM tickets.fn_getfallos(@v_subcat)";
        return await _dbConnection.QueryAsync<TicketFallosDTO>(query, new {v_subcat = id_subcat});
    }
    public async Task<int> CreateNewTicket(NewTicketDTO dto)
    {
        var parameters = new DynamicParameters();
        parameters.Add("v_nomina", dto.nomina, DbType.Int32, ParameterDirection.Input);
        parameters.Add("v_titulo", dto.title, DbType.String, ParameterDirection.Input);
        parameters.Add("v_categoria", dto.id_cat, DbType.Int32, ParameterDirection.Input);
        parameters.Add("v_subcat", dto.id_subcat, DbType.Int32, ParameterDirection.Input);
        parameters.Add("v_fallo", dto.id_failure, DbType.Int32, ParameterDirection.Input);
        parameters.Add("v_descripcion", dto.descripcion, DbType.String, ParameterDirection.Input);

        parameters.Add("v_idticket", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

        

        return 1;
    }
}
