using tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;
using System.Data;
using Dapper;
namespace tickets_web.Models.Repositories;

public class UserRepositorie : IUser
{
    private readonly IDbConnection _dbConnection;

    public UserRepositorie(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<string> Login(int nomina)
    {
        var parameters = new DynamicParameters();
        string message = "";
        string storedProcedure = "tickets.login";
        parameters.Add("v_nomina", nomina, DbType.Int32, ParameterDirection.Input);
        parameters.Add("v_estatus", dbType: DbType.String,direction: ParameterDirection.Output);

        await _dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        int estatus = parameters.Get<int>("v_estatus");
        switch (estatus)
            {
                case 0:
                    message = "Ususario no encontrado";
                    break;
                case 1: 
                    message = "Se necesita establacer una nueva contraseña";
                    break;
                case 2:
                    /* Funcion para login */
                    string query = "SELECT * FROM tickets.fn_login(@nomina)";
                    Console.WriteLine(nomina);
                    var userInfo = await _dbConnection.QueryAsync<UserLoginDTO>(query, new
                    {
                        nomina = nomina
                    });
                    //userInfo.ToList();
                    Console.WriteLine(userInfo.ToList());
                    break;
                default: 
                    message = "Se produjo un error";
                break;
            }
            return message;
    }
}
