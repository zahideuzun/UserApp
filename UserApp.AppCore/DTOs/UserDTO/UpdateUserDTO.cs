using Microsoft.AspNetCore.Http;

namespace UserApp.AppCore.DTOs.UserDTO
{
    public class UpdateUserDTO
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public IFormFile ImageURL { get; set; }
	}
}
