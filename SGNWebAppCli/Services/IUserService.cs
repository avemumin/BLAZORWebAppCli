using SGNWebAppCli.Data;
using System.Threading.Tasks;

namespace SGNWebAppCli.Services
{
    public interface IUserService
    {
        public Task<User> LoginAsync(User user);
        public Task<User> RefreshTokenAsync(RefreshRequest refreshRequest);

        public Task<User> RegisterUserAsync(User user);
    }
}
