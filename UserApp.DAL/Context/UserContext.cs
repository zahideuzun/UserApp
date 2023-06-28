using Microsoft.EntityFrameworkCore;
using UserApp.DAL.Entities;

namespace UserApp.DAL.Context
{
	public class UserContext : DbContext
	{
		public UserContext() : base()
		{

		}
		public UserContext(DbContextOptions<UserContext> opt) : base(opt)
		{

		}


		public DbSet<User> User { get; set; }
	}
}
