using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using tickets_web.Models.DTOS;
using tickets_web.Models.Interfaces;

namespace tickets_web.Controllers
{
    public class Auth : Controller
    {
        private readonly IUser _user;

        public Auth (IUser user)
        {
            _user = user;
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> Login(int nomina, string password)
        {
            var message = await _user.Login(nomina, password);
            return "";
            
        }
    }
}
