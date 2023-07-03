using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApp.AppCore.BaseApiType;
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

	}
}
