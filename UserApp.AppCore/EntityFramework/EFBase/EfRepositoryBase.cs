using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;
using UserApp.AppCore.EntityFramework.Data;
using UserApp.AppCore.Results;
using UserApp.AppCore.Results.Bases;

namespace UserApp.AppCore.EntityFramework.EFBase
{
	public class EfRepositoryBase<TContext, TEntity>
		: ISelectableRepo<TEntity>,
		  ISelectableRepoAsync<TEntity>,
		  IInsertableRepo<TEntity>,
		  IInsertableRepoAsync<TEntity>,
		  IUpdatetableRepoAsync<TEntity>,
	IDeletableRepo<TEntity>
		  where TEntity : class, IEntity
		 where TContext : DbContext, new()
	{
		private readonly TContext _context;

		public EfRepositoryBase()
		{
			_context = new TContext();
		}
		public EfRepositoryBase(TContext context)
		{
			_context = context;
		}
		public TEntity Add(TEntity item)
		{
			_context.Set<TEntity>().Add(item);
			return item;
		}

		public Task<Result> AddAsync(TEntity item)
		{
			throw new NotImplementedException();
		}

		//todo repoyu duzenle en bastan.. maalesef :( 
		//public async Task<Result> AddAsync(TEntity item)
		//{

		//	var entityEntry = await _context.Set<TEntity>().AddAsync(item);
		//	 await _context.SaveChangesAsync();


		//}

		public List<TEntity> AddRange(List<TEntity> items)
		{
			_context.Set<TEntity>().AddRange(items);
			return items;
		}

		public async Task AddRangeAsync(List<TEntity> items)
		{
			await _context.Set<TEntity>().AddRangeAsync(items);
		}

		public void Delete(TEntity item)
		{
			_context.Set<TEntity>().Remove(item);
		}

		public List<TEntity> GetAll()
		{
			return _context.Set<TEntity>().ToList();
		}


		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public List<TEntity> GetBy(Func<TEntity, bool> condition)
		{
			return _context.Set<TEntity>().Where(condition).ToList();
		}

		public TEntity GetById(object id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		public async Task<TEntity> GetByIdAsync(object id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public void MySaveChanges()
		{
			_context.SaveChanges();
		}
		public async Task<Result> Update(TEntity item)
		{
			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return new SuccessResult(); // veya isteğe bağlı bir sonuç döndürebilirsiniz.
		}
		//public async Task<Result> Update(TEntity item)
		//{
		//	_context.Entry(item).State = EntityState.Modified;
		//	return await _context.Set<TEntity>().Update(item);
		//}
	}
}
