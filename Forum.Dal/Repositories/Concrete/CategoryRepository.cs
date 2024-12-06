using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Dal.Context;
using Forum.Dal.Repositories.Abstract;
using Forum.Entities.Models;

namespace Forum.Dal.Repositories.Concrete
{
	public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
	{
        public CategoryRepository(MyContext db):base(db) 
        {
            
        }

    }
}
