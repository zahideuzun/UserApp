using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserApp.AppCore;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results;
using UserApp.BLL.Concrate;
using UserApp.DAL.Entities;
using UserApp.UI.ApiProvider;

namespace UserApp.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserProvider _userProvider;
        private readonly IMapper _mapper;
        public UserController(UserProvider ihaleProvider, IMapper mapper)
        {
            _userProvider = ihaleProvider;
            _mapper = mapper;
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
                FileStringBase fileStringBase = new FileStringBase();
                var tempFilePath = fileStringBase.SaveFileToTempLocation(imageFile);
                addedUser.ImageURL = tempFilePath;
            }
            else
            {
                addedUser.ImageURL = string.Empty;
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
            var updatedUser= _mapper.Map<UpdateUserDTO>(result);
            return View(updatedUser);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updatedUser, [FromForm] IFormFile imageFile)
        {
            if (imageFile != null)
            {
                FileStringBase fileStringBase = new FileStringBase();
                var tempFilePath = fileStringBase.SaveFileToTempLocation(imageFile);
                updatedUser.ImageURL = tempFilePath;
            }
            else
            {
                updatedUser.ImageURL = string.Empty;
            }
            var result = await _userProvider.UpdateUser(updatedUser, updatedUser.Id);
            if (result.IsSuccessful)
            {
                // Bilgilendirme mesajıyla tekrar güncelleme ekranına dön
                return RedirectToAction("UpdateUser", "User", new { id = updatedUser.Id });
            }
            // Hata mesajıyla tekrar güncelleme ekranına dön
            return RedirectToAction("UpdateUser", "User", new {id=updatedUser.Id});
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var result = await _userProvider.DeleteUser(id);
        //    var updatedUser = _mapper.Map<UpdateUserDTO>(result);
        //    return View(updatedUser);
        //}
    }
}
