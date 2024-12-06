using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Dal.Context;
using Forum.Dal.Repositories.Abstract;
using Forum.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Forum.Dal.Repositories.Concrete
{
	public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository //bu interface burada elle instance almamamız için kullanıldı
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AppUserRepository(MyContext db,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

        public async Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task  CreateUserAsync(AppUser appUser)
		{
            IdentityResult result = await _userManager.CreateAsync(appUser,appUser.PasswordHash);
            var res = result;
		}

        public Task<AppUser> FindByNameAsync(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public Task<IList<string>> GetRolesAsync(AppUser user)
        {
            return _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(AppUser user, IEnumerable<string> roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<SignInResult> SignInAsync(string userName, string password)
        {
			AppUser user=await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            else
            {
                SignInResult res= await _signInManager.CheckPasswordSignInAsync(user, password,false);
                return res;
            }
        }


        public async Task UpdateUser(AppUser item)
        {

            if (item.Status == Entities.Enums.DataStatus.Deleted)
            {
                item.DeleteDate = null;
            }
            item.Status = Entities.Enums.DataStatus.Updated; 
            item.ModifiedDate=DateTime.Now;
            await _userManager.UpdateAsync(item);


        }
    }
    }

