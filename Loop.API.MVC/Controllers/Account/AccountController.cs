using Microsoft.AspNetCore.Mvc;

namespace Loop.API.MVC.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
