using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.AppCore.DTOs.UserDTO
{
	public class UserDTO
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string ImageURL { get; set; }
	}
}
