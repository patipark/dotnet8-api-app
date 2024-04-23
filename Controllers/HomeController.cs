using DotnetAPIApp.Services.ThaiDate;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPIApp.Controllers
{

    [Route("api")] // http://localhost:port/api
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IThaiDate _thaiDate;
        public HomeController(IThaiDate thaiDate) {
            _thaiDate = thaiDate;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new
            {
                message = "Backend API Running...",
                date = $"วันนี้วันที่ {_thaiDate.ShowThaiDate()}"
            });
        }
    }
}
