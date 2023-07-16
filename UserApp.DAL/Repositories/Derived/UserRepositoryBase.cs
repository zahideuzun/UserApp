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

    public abstract class UserRepositoryBase : EfRepositoryBase<UserAppContext, User>
    {
        protected UserRepositoryBase(UserAppContext dbContext) : base(dbContext)
        {
        }
    }
    public class UserRepository: UserRepositoryBase
    {
        public UserRepository(UserAppContext dbContext) : base(dbContext)
        {
        }
    }
    //      private readonly UserAppContext _context;
    //public UserRepository()
    //{

    //}
    //public UserRepository(UserAppContext context) : base(context)
    //{
    //	_context = context;
    //}

}
