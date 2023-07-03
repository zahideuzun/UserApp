using Microsoft.EntityFrameworkCore;
using UserApp.DAL.Configuration;
using UserApp.DAL.Entities;

namespace UserApp.DAL.Context
{
	public class UserAppContext : DbContext
	{
		public UserAppContext() : base()
		{

		}
		public UserAppContext(DbContextOptions<UserAppContext> opt) : base(opt)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<User> Users { get; set; }
	}
}
