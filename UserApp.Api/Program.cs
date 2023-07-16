using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserApp.BLL.Abstract;
using UserApp.BLL.Concrate;
using UserApp.DAL.Context;
using UserApp.DAL.Mapping;
using UserApp.DAL.Repositories.Derived;

namespace UserApp.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
            builder.Services.AddDbContext<UserAppContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("UserAppDB")));

            #region InstanceConfiguration

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<UserRepository, UserRepository>();

            #endregion

            #region MappingConfiguration

            builder.Services.AddAutoMapper(typeof(Program));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);


            #endregion

            #region Swagger

            builder.Services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo() { Title = "UserApp", Version = "v1" });
            });

            #endregion

            var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
            });

            app.MapControllers();

			app.Run();
		}
	}
}