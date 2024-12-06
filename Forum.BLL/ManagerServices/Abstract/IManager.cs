using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Forum.Entities.Interfaces;

namespace Forum.BLL.ManagerServices.Abstract
{
	public interface IManager<T> where T : class,IEntity
	{
		//Buradaki metodlar Irepostitory ve BaseRepositorydeki metodlar ile aynı isme sahip olsada
		//Burada çalıştırılma mantıkları farklıdır.Örneğin ben buradan türetilece olan BaseManager içinde Add metodu kullanırken metod içine kontrol 
		//için belirli kodlar yazabilrim ve sonra DAL katmanındaki metodlar ile crudu gerçekleştirirm.


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
		Task DeleteAsync(T item);
		Task DestroyAsync(T item);


		//Filter
		Task<List<T>> GetFilterAsync(Expression<Func<T, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
		Task<T> FirtOrDefaultAsync(Expression<Func<T, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
		IQueryable<T> GetFilter(Expression<Func<T, bool>> exp);

        //Find
        Task<T> FindAsync(int id);

	}
}
