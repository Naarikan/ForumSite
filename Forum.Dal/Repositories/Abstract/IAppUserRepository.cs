using Forum.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Forum.Dal.Repositories.Abstract
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task CreateUserAsync(AppUser appUser);
        Task<SignInResult> SignInAsync(string userName, string password);

        Task<AppUser> FindByNameAsync(string userName);
        Task<IList<string>> GetRolesAsync(AppUser user);


        Task<IdentityResult> RemoveFromRolesAsync(AppUser user, IEnumerable<string> roles);
        Task<IdentityResult> AddToRoleAsync(AppUser user, string role);
        Task UpdateUser(AppUser item);


    }
}
