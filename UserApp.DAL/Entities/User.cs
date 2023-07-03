using UserApp.AppCore.Core.Bases;
using UserApp.DAL.Entities.Bases;

namespace UserApp.DAL.Entities
{
	public class User :BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string ImageURL { get; set; }

	}
}
