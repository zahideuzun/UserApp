﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data.Bases;

namespace UserApp.AppCore.EntityFramework.Data
{
	public interface ISelectableRepo<T> : IRepository<T> where T : class, IEntity
	{
		List<T> GetAll();
		T GetById(object id);
		List<T> GetBy(Func<T, bool> condition);
	}
}
