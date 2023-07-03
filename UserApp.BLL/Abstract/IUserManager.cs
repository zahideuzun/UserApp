using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results.Bases;

namespace UserApp.BLL.Abstract
{
	public interface IUserManager
	{
		List<UserDTO> GetAllUsers();
		Task<UserDTO> GetUser(object id);
		//Task<UserDTO> GetUserByName(string userName);
		Task<Result> Add(AddUserDTO model);
		Task<Result> Update(object id, UpdateUserDTO model);
		Task<Result> Delete(object id);
		Task<Result> Delete(UserDTO user);
	}
}
