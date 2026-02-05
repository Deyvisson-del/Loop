using Loop.API.MVC.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.MVC.Controllers
{

    [AllowAnonymous]
    public class AuthController : Controller
    {
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model) { return Ok(); }


    }
}
