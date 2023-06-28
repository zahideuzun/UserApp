using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.DAL.Entities.Bases;
using UserApp.DAL.Repositories.Data.Bases;

namespace UserApp.DAL.Repositories.Data
{
	public interface IInsertableRepoAsync<T> : IRepository<T> where T : class, IEntity
	{
		Task AddAsync(T item);
		Task AddRangeAsync(List<T> items);
	}
}
