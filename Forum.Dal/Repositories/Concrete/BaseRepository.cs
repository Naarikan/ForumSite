using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Forum.Dal.Context;
using Forum.Dal.Repositories.Abstract;
using Forum.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal.Repositories.Concrete
{
	public class BaseRepository<T> : IRepository<T> where T : class, IEntity
	{
		private readonly MyContext _db;

		public BaseRepository(MyContext db) {
		
		_db=db;
		
		}

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();	
        }


        public async Task AddAsync(T item)
		{
			await _db.Set<T>().AddAsync(item);
			await _db.SaveChangesAsync();
		}

		public async Task AddRangeAsync(List<T> item)
		{
			await _db.Set<T>().AddRangeAsync(item);
			await _db.SaveChangesAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
		{
			return await _db.Set<T>().AnyAsync(exp);
		}

		/// <summary>
		/// Verinin Status değeri False yapılır.Yani verinin Pasife Çekilmesidir
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public async Task DeleteAsync(T item)
		{
			item.Status=Entities.Enums.DataStatus.Deleted;
			item.DeleteDate=DateTime.Now;
			await _db.SaveChangesAsync();
		}

		public async Task DestroyAsync(T item)
		{
			_db.Set<T>().Remove(item);
			await _db.SaveChangesAsync();
		}

		public async Task<T> FindAsync(int id)
		{
			return await _db.Set<T>().FindAsync(id);
		}

		public async Task<T> FirtOrDefaultAsync(Expression<Func<T, bool>> exp)
		{
			return await _db.Set<T>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<T> GetActivesAsync()
		{
			return _db.Set<T>().Where(x=>x.Status!=Entities.Enums.DataStatus.Deleted);
		}

		public IQueryable<T> GetAllAsync()
		{
			return _db.Set<T>().AsQueryable();
		}

		public async Task<List<T>> GetFilterAsync(Expression<Func<T, bool>> exp)
		{
			return await _db.Set<T>().Where(exp).ToListAsync();
		}

		public IQueryable<T> GetModifiedsAsync()
		{
			return _db.Set<T>().Where(x => x.Status == Entities.Enums.DataStatus.Updated);
		}

		public IQueryable<T> GetPassivesAsync()
		{
			return _db.Set<T>().Where(x => x.Status == Entities.Enums.DataStatus.Deleted);
		}

		public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
		{
			return _db.Set<T>().Select(exp);
		}

		public async Task Update(T item)
		{
			item.Status=Entities.Enums.DataStatus.Updated;
			item.ModifiedDate = DateTime.Now;
			T original = await FindAsync(item.ID);
			_db.Entry(original).CurrentValues.SetValues(item);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateRange(List<T> item)
		{
			foreach (T item2 in item) await Update(item2);
		}

        public IQueryable<T> GetFilter(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp);
        }
    }
}
