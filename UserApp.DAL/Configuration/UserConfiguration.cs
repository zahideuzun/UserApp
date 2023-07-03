using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp.DAL.Entities;

namespace UserApp.DAL.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(c => c.Surname)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(c => c.PhoneNumber)
				.IsRequired()
				.HasMaxLength(11);
			builder.Property(c => c.Email)
				.IsRequired() 
				.HasMaxLength(250);
		}
	}
}
