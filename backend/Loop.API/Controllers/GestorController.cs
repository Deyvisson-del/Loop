using Loop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorController : ControllerBase
    {
        private readonly IGestorService _gestorService;
        public GestorController(IGestorService gestorService)
        {
            _gestorService = gestorService;
        }



    }
}
