using Microsoft.AspNetCore.Mvc;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.BLL.Concrate;
using UserApp.UI.ApiProvider;

namespace UserApp.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserProvider _userProvider;
        public UserController(UserProvider ihaleProvider)
        {
            _userProvider = ihaleProvider;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userProvider.AllUsers();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserDTO addedUser)
        {
            var result = await _userProvider.AddUser(addedUser);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Index", "User");
            }
            //hata mesajiyla tekrar kullanici ekleme ekranina dondur
            return RedirectToAction("AddUser", "User");
        }
    }
}
