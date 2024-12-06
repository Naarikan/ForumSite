using System.Linq.Expressions;
using Forum.Entities.Interfaces;

namespace Forum.Dal.Repositories.Abstract
{
	public interface IRepository<T> where T : class, IEntity
	{
		//List 
		IQueryable<T> GetAllAsync();
		IQueryable<T> GetActivesAsync();
		IQueryable<T> GetModifiedsAsync();
		IQueryable<T> GetPassivesAsync();
		List<T> GetAll();

        //Modify
        Task AddAsync(T item);
		Task AddRangeAsync(List<T> item);
		
		Task Update(T item);
		Task UpdateRange(List<T> item);
		Task DeleteAsync (T item);
		Task DestroyAsync(T item);
		
		//Filter
		Task<List<T>> GetFilterAsync(Expression<Func<T,bool>> exp);
		IQueryable<T> GetFilter(Expression<Func<T, bool>> exp);

        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
		Task<T> FirtOrDefaultAsync(Expression<Func<T, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<T,X>> exp);

		//Find
		Task<T> FindAsync(int id);


	}
}
