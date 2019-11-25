using core.Data.Repositories.User;
using core.Domain.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _repo.GetAllUsers();
        }
    }
}
