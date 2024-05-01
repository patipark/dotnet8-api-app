using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        [Route("")] // localhost:port/api/company/
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "Hello World /api/company/" }); // return Ok("Hello World");
        }
        [HttpGet("about")] // localhost:port/api/company/about
        public IActionResult About()
        {
            return Ok(new { message = "company about us" });
        }

        [HttpGet("map/{id}")] // localhost:port/api/company/map/555
        public IActionResult About([FromRoute] int id)
        {
            return Ok(new { message = $"Map Id: {id}" ,note = "[FromRoute] int id ==> calhost:port/api/company/map/555"});
        }
    }
}
