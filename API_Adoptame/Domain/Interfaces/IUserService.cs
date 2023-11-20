using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUserAsync();
        Task<User> CreateUserAsync(User user);
    }
}
