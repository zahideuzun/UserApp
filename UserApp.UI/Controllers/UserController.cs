using Microsoft.AspNetCore.Mvc;
using UserApp.BLL.Concrate;

namespace UserApp.UI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
