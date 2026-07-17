using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using tickets_web.Models.DTOS;
namespace tickets_web.Models;

public class DbConnection
{
    private readonly IDbConnection _dbConnection;
    public DbConnection(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
}