using tickets_web.Models.DTOS;
namespace tickets_web.Models.Interfaces;

public interface IUser
{
    Task<string> Login(int nomina);
}
