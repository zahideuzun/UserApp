using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data.Bases;

namespace UserApp.AppCore.EntityFramework.Data
{
	public interface IInsertableRepo<T> : IRepository<T> where T : class, IEntity
	{
		T Add(T item);
		List<T> AddRange(List<T> items);
	}
}
