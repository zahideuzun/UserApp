using UserApp.AppCore.EntityFramework.EFBase;
using UserApp.DAL.Context;
using UserApp.DAL.Entities;

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
}
