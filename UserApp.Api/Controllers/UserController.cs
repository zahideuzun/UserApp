﻿using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApp.AppCore.BaseApiType;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results.Bases;
using UserApp.BLL.Abstract;

namespace UserApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserManager _userManager;
		
		public UserController(IUserManager userManager)
		{
			_userManager = userManager;
		}
        [HttpGet("UserList")]
        public List<UserDTO> GetAll()
        {
            return _userManager.GetAll().ToList();
        }

        [HttpGet("GetUser/{id}")]
        public UserDTO Get(int id)
        {
            return _userManager.Get(id);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> Post([FromBody] AddUserDTO user)
        {
            var addedUser = await _userManager.AddAsync(user);
            return BaseActionType.ReturnResponse(addedUser);
        }

        [HttpPut("UserUpdate/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserDTO user)
        {
            var updatedUser = await _userManager.UpdateAsync(id, user);
            return BaseActionType.ReturnResponse(updatedUser);
        }

        [HttpDelete("UserDelete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedUser = await _userManager.DeleteAsync(id);
            return BaseActionType.ReturnResponse(deletedUser);
        }
    }
}
