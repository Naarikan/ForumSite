using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Forum.BLL.ManagerServices.Abstract;
using Forum.Dal.Repositories.Abstract;
using Forum.Entities.Interfaces;

namespace Forum.BLL.ManagerServices.Concrete
{
	public class BaseManager<T> :IManager<T> where T : class,IEntity
	{
		protected IRepository<T> _irp;
		//Burada dependency injection kullanılır
		//Daha sonra scoplar eklenerek burada IRepostory istendiğinde BaseRepostory gönderilecek
		//Yani biz CRUD metodlarımıza başrıyla ulaşacağız
		//Böylece elle instance girilmeden bağlılıktan kurtulmuş olacağız.Ayrıca Eğer BaseRepository
		//Abstract olarak tanımlansaydı böyle şekilde instance alamazdık.
		//Bunun dışınd amesela ben burada Add metodunu string tanımlayıp geriye bir değerde döndürebilirim
		//O da şu şekilde olabilir:(örnek olarak verilecek)
		//Biz _irp aracılığıyla BaseRepository classındaki CRUD metodlarından Add'ı çağırırız.
		//Eğer gelen kayıt null değilse işlem Bşaraılı diye geriye dönüş bildirebilirz.
		public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }

		public async Task AddAsync(T item)
		{
			if (item != null)
			{
				await _irp.AddAsync(item);
			}
			else
			{
				Console.WriteLine("Kayıt boş");
			}

		}

		public async Task AddRangeAsync(List<T> item)
		{
			//Todo:BL yazılabilir
			await _irp.AddRangeAsync(item);
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
		{
			return await _irp.AnyAsync(exp);
		}

		public async Task DeleteAsync(T item)
		{
			await _irp.DeleteAsync(item);
		}

		public async Task DestroyAsync(T item)
		{
			await _irp.DestroyAsync(item);
		}

		public async Task<T> FindAsync(int id)
		{
			return await _irp.FindAsync(id);
		}

		public async Task<T> FirtOrDefaultAsync(Expression<Func<T, bool>> exp)
		{
			return await _irp.FirtOrDefaultAsync(exp);
		}

		public IQueryable<T> GetActivesAsync()
		{
			return _irp.GetActivesAsync();
		}

        public List<T> GetAll()
        {
           return _irp.GetAll();
        }

        public IQueryable<T> GetAllAsync()
		{
			return _irp.GetAllAsync();
		}

        public IQueryable<T> GetFilter(Expression<Func<T, bool>> exp)
        {
            return _irp.GetFilter(exp);
        }

        public Task<List<T>> GetFilterAsync(Expression<Func<T, bool>> exp)
		{
			return _irp.GetFilterAsync(exp);
		}

		public IQueryable<T> GetModifiedsAsync()
		{
			return _irp.GetModifiedsAsync();
		}

		public IQueryable<T> GetPassivesAsync()
		{
			return _irp.GetPassivesAsync();
		}

		public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
		{
			return (_irp.Select(exp));
		}

		public async Task Update(T item)
		{
			await _irp.Update(item);
		}

		public async Task UpdateRange(List<T> item)
		{
			await _irp.AddRangeAsync(item);
		}
	}
}
