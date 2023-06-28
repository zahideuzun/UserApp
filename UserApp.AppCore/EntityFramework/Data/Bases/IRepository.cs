using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;

namespace UserApp.AppCore.EntityFramework.Data.Bases
{
	public interface IRepository<T> where T : class, IEntity
	{
		void MySaveChanges();
	}
}
