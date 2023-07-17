using Microsoft.EntityFrameworkCore;
using UserApp.DAL.Configuration;
using UserApp.DAL.Entities;
using UserApp.DAL.Entities.Bases;

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

        public override int SaveChanges()
        {
            var data = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in data)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.IsActive = true;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                    entry.Entity.IsActive = false;
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }

       
    }
}
