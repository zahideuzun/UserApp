using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.EntityFramework.Data;
using UserApp.DAL.Entities;

namespace UserApp.DAL.Repositories.Infrastructor
{
	public interface IUserRepository : IInsertableRepo<User>,IInsertableRepoAsync<User>, ISelectableRepo<User>,ISelectableRepoAsync<User>, IDeletableRepoAsync<User>, IUpdatetableRepoAsync<User>
	{

	}
}
