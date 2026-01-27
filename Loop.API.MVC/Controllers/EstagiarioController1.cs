//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using Loop.API.MVC.Models;

//namespace Loop.API.MVC.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class EstagiarioController : ControllerBase
//    {
//        private readonly ILogger<EstagiarioController> _logger;

//        public EstagiarioController(ILogger<EstagiarioController> logger)
//        {
//            _logger = logger;
//        }

//        // GET: EstagiarioController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: EstagiarioController1/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: EstagiarioController1/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: EstagiarioController1/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: EstagiarioController1/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: EstagiarioController1/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: EstagiarioController1/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: EstagiarioController1/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
