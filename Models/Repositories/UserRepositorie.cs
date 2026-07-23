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
    public async Task<IEnumerable<UserLoginDTO>> Login(int nomina, string password)
    {
        var parameters = new DynamicParameters();
        string message = "";
        bool verifyPass = false;
        //var validatePasswotd = "";
        string storedProcedure = "tickets.sps_login";
        parameters.Add("v_nomina", nomina, DbType.Int32, ParameterDirection.Input);
        parameters.Add("hash_pass", dbType: DbType.String,direction: ParameterDirection.Output);
        parameters.Add("v_message", dbType: DbType.String,direction: ParameterDirection.Output);

        await _dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        string hash = parameters.Get<string>("hash_pass");

        if (hash.Length > 0)
        {
            verifyPass = BCrypt.Net.BCrypt.Verify(password, hash);
        }

        if(verifyPass == true)
        {
            var query = "SELECT * FROM tickets.fn_login(@nomina)";
            return await _dbConnection.QueryAsync<UserLoginDTO>(query);
        }   
    }
}
