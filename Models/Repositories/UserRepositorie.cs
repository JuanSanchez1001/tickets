using tickets_web.Models.Interfaces;
using tickets_web.Models.DTOS;
using System.Data;
using Dapper;
using BCrypt.Net;
namespace tickets_web.Models.Repositories;

public class UserRepositorie : IUser
{
    private readonly IDbConnection _dbConnection;

    public UserRepositorie(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<string> Login(int nomina, string password)
    {
        var parameters = new DynamicParameters();
        string message = ""; 
        //var validatePasswotd = "";
        string storedProcedure = "tickets.sps_login";
        parameters.Add("v_nomina", nomina, DbType.Int32, ParameterDirection.Input);
        parameters.Add("hash_pass", dbType: DbType.String,direction: ParameterDirection.Output);
        parameters.Add("v_message", dbType: DbType.String,direction: ParameterDirection.Output);

        await _dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        string hash = parameters.Get<string>("hash_pass");
        Console.WriteLine(hash.Length);

        if (hash.Length > 0)
        {
            bool verifyPass = BCrypt.Net.BCrypt.Verify(password, hash);
            Console.WriteLine(verifyPass);
        }

        // switch (estatus)
        //     {
        //         case 0:
        //             message = "Ususario no encontrado";
        //             break;
        //         case 1: 
        //             message = "Se necesita establacer una nueva contraseña";
        //             break;
        //         case 2:
        //             /* Funcion para login */
        //             string query = "SELECT * FROM tickets.fn_login(@nomina)";
        //             Console.WriteLine(nomina);
        //             var userInfo = await _dbConnection.QueryAsync<UserLoginDTO>(query, new
        //             {
        //                 nomina = nomina
        //             });
        //             //userInfo.ToList();
        //             Console.WriteLine(userInfo.ToList());
        //             break;
        //         default: 
        //             message = "Se produjo un error";
        //         break;
        //     }
            return message;
    }
}
