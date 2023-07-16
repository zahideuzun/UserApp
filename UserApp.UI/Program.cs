using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserApp.DAL.Mapping;
using UserApp.BLL.Abstract;
using UserApp.BLL.Concrate;
using UserApp.DAL.Context;
using UserApp.DAL.Repositories.Derived;
using UserApp.DAL.Repositories.Infrastructor;
using Microsoft.Extensions.DependencyInjection;

namespace UserApp.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<UserAppContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("UserAppDB")));

			#region MappingConfiguration

			//builder.Services.AddAutoMapper(typeof(Program)); todo neden yazmama gerek yok arastir????
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MapProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			builder.Services.AddSingleton(mapper);


			#endregion

			#region InstanceConfiguration

			builder.Services.AddScoped<IUserManager, UserManager>();
			builder.Services.AddScoped<UserRepositoryBase>();

            #endregion

            


            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
            

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}