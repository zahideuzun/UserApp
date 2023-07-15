﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data.Bases;
using UserApp.AppCore.Results.Bases;

namespace UserApp.AppCore.EntityFramework.Data
{
	public interface IDeletableRepo<T> : IRepository<T> where T : class, IEntity
	{
		Task<Result> Delete(T item);
	}
}
