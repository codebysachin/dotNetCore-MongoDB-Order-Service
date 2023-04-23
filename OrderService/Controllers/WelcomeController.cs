using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Greet()
        {
            return "Welcome to the new world of AI";
        }
    }
}
