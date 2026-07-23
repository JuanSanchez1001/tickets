namespace tickets_web.Models.DTOS;

public class UserInfoDTO
{
    public int nomina { get;set; }
    public string nombre { get;set; } = string.Empty;
    public string rol { get;set; } = string.Empty;
    public string v_hash { get;set; } = string.Empty;
}
public class UserLoginDTO
{
    public int nomina { get;set; }
    public string nombre { get;set; } = string.Empty;
    public string rol { get;set; } = string.Empty;
    public string v_hash { get;set; } = string.Empty;
}