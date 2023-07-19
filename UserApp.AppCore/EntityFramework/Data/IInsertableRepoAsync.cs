using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data.Bases;

namespace UserApp.AppCore.EntityFramework.Data
{
    public interface IInsertableRepoAsync<T> : IRepository<T> where T : class, IEntity
	{
		Task AddAsync(T item);
		Task AddRangeAsync(List<T> items);
	}
}
