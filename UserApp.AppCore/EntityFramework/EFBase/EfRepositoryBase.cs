using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
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
	IDeletableRepoAsync<TEntity>, IDisposable
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


        /// <summary>
        /// Returns an IQueryable of entities with optional inclusion of related entities.
        /// </summary>
        /// <param name="entitiesToInclude">Expressions that specify related entities to include in the result set.</param>
        /// <returns>An IQueryable of entities that can be further queried or executed against a data source.</returns>
        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }
            return query.AsNoTracking();
        }

        /// <summary>
        /// Gets an IQueryable of entities with optional filtering, ordering and inclusion of related entities.
        /// </summary>
        /// <param name="predicate">An optional expression to filter the entities.</param>
        /// <param name="orderBy">An optional function to order the entities.</param>
        /// <param name="include">An optional function to include related entities.</param>
        /// <returns>An IQueryable of entities that match the specified criteria.</returns>
        public IQueryable<TEntity> GetQueryableEntitiesWithExpression(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

            if (include != null)
                query = include(query);
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);

            return query.AsNoTracking();
        }

        /// <summary>
        /// Returns an IQueryable of entities that match the specified criteria, with optional inclusion of related entities.
        /// </summary>
        /// <param name="predicate">An expression that defines a filter to apply to the entities.</param>
        /// <param name="entitiesToInclude">Expressions that specify related entities to include in the result set.</param>
        /// <returns>An IQueryable of entities that can be further queried or executed against a data source.</returns>
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] entitiesToInclude)
        {
            var query = Query(entitiesToInclude);
            return query.Where(predicate);
        }

        /// <summary>
        /// Returns an IQueryable of a related entity, allowing to query data that is related to the main entity type.
        /// </summary>
        /// <typeparam name="TRelationalEntity">The type of the related entity to query.</typeparam>
        /// <returns>An IQueryable of the specified related entity type that can be further queried or executed against
        public virtual IQueryable<TRelationalEntity> Query<TRelationalEntity>() where TRelationalEntity : class, new()
        {
            return _context.Set<TRelationalEntity>().AsQueryable();
        }


        public TEntity Add(TEntity item)
		{
			_context.Set<TEntity>().Add(item);
			return item;
		}

		//todo repoyu duzenle en bastan.. maalesef :( 
		public async Task AddAsync(TEntity item)
		{

			var entityEntry = await _context.Set<TEntity>().AddAsync(item);
			await _context.SaveChangesAsync();
			//return new SuccessResult();
		}

		public List<TEntity> AddRange(List<TEntity> items)
		{
			_context.Set<TEntity>().AddRange(items);
			return items;
		}

		public async Task AddRangeAsync(List<TEntity> items)
		{
			await _context.Set<TEntity>().AddRangeAsync(items);
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
		public async Task Update(TEntity item)
		{
			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			
		}
		public async Task Delete(TEntity item)
		{
			_context.Set<TEntity>().Remove(item);
			await _context.SaveChangesAsync();
		}

        public async Task Delete(object id)
        {
            var entity = _context.Set<TEntity>().Find(id);
			Delete(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
