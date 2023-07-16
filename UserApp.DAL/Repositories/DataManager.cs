using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.DAL.Context;
using UserApp.DAL.Repositories.Derived;
using UserApp.DAL.Repositories.Infrastructor;

namespace UserApp.DAL.Repositories
{
	public class DataManager
	{
		public UserAppContext Context { get; set; }
		public DataManager()
		{
			Context = new UserAppContext();
		}

		public IUserRepository GetUserRepository()
		{
			return new UserRepositoryBase(Context);
		}
		public void MySaveChanges()
		{
			Context.SaveChanges();
		}
	}
}
