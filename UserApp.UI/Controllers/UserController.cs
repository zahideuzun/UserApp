using Microsoft.AspNetCore.Mvc;
using UserApp.AppCore;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results;
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
        public async Task<IActionResult> AddUser(AddUserDTO addedUser, [FromForm] IFormFile imageFile)
        {
            if (imageFile != null)
            {
                // Dosyayı geçici bir konuma kaydedin
                var tempFilePath = FileStringBase.SaveFileToTempLocation(imageFile);

                // Dosya yolunu ImageURL özelliğine atayın
                addedUser.ImageURL = tempFilePath;
            }


            var result = await _userProvider.AddUser(addedUser);

            if (result.IsSuccessful)
            {
                return RedirectToAction("Index", "User");
            }
            // Hata mesajıyla tekrar kullanıcı ekleme ekranına dön
            return RedirectToAction("AddUser", "User");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var result = await _userProvider.GetUser(id);
            return View(result);
        }
    }
}
