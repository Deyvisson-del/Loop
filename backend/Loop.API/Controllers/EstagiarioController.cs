using Microsoft.AspNetCore.Mvc;
namespace Loop.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EstagiarioController : Controller
    {



        [HttpGet]
        // GET: CadastrarController
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: CadastrarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastrarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastrarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastrarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadastrarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastrarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastrarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
