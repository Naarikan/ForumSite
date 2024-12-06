using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.BLL.ManagerServices.Abstract;
using Forum.Dal.Repositories.Abstract;
using Forum.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Forum.BLL.ManagerServices.Concrete
{
	public class AppUserManager:BaseManager<AppUser>,IAppUserManager
	{
        IAppUserRepository _ıAur;
        public AppUserManager(IAppUserRepository ıAur):base(ıAur)
        {
            _ıAur=ıAur;
        }

        public async Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
        {
          return await _ıAur.AddToRoleAsync(user, role);
        }

        public async Task CreateUserAsync(AppUser appUser)
        {
            
           await _ıAur.CreateUserAsync(appUser);
           
           
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Lütfen Giriş Yapınız");

            return await _ıAur.FindByNameAsync(userName);
        }

        public async Task<IList<string>> GetRolesAsync(AppUser user)
        {
            return await _ıAur.GetRolesAsync(user);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(AppUser user, IEnumerable<string> roles)
        {
           return await _ıAur.RemoveFromRolesAsync(user, roles);
        }

        public Task<SignInResult> SignInAsync(string userName, string password)
        {
            return _ıAur.SignInAsync(userName, password);
        }

        public async Task UpdateUser(AppUser item)
        {
            await _ıAur.UpdateUser(item);
        }
    }
}
