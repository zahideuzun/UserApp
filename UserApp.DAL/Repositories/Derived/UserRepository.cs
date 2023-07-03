using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.EntityFramework.EFBase;
using UserApp.DAL.Context;
using UserApp.DAL.Entities;
using UserApp.DAL.Repositories.Infrastructor;

namespace UserApp.DAL.Repositories.Derived
{
	public class UserRepository : EfRepositoryBase<UserAppContext, User>, IUserRepository
	{
		private readonly UserAppContext _context;
		public UserRepository()
		{

		}
		public UserRepository(UserAppContext context) : base(context)
		{
			_context = context;
		}
	}
}
