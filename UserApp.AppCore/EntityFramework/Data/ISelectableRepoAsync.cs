using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data.Bases;

namespace UserApp.AppCore.EntityFramework.Data
{
	public interface ISelectableRepoAsync<T> : IRepository<T> where T : class, IEntity
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(object id);
	}
}
