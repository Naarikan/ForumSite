using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.BLL.ManagerServices.Abstract;
using Forum.Dal.Repositories.Abstract;
using Forum.Entities.Models;

namespace Forum.BLL.ManagerServices.Concrete
{
	public class AnswerManager:BaseManager<Answer>,IAnswerManger
	{
		IAnswerRepository _iAr;
        public AnswerManager(IAnswerRepository iAr):base(iAr) 
        {
            _iAr = iAr;
        }
    }
}
