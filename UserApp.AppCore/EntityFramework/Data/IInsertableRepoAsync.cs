using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data.Bases;
using UserApp.AppCore.Results.Bases;

namespace UserApp.AppCore.EntityFramework.Data
{
	public interface IInsertableRepoAsync<T> : IRepository<T> where T : class, IEntity
	{
		Task AddAsync(T item);
		Task AddRangeAsync(List<T> items);
	}
}
