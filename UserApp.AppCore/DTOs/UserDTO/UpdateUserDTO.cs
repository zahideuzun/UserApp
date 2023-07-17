using Microsoft.AspNetCore.Http;

namespace UserApp.AppCore.DTOs.UserDTO
{
    public class UpdateUserDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
    }
}
