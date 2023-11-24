using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface IUserService
    {

        Task<User> CreateUsersAsync(User user);


        Task<IEnumerable<User>> GetUsersAsync();


        Task<User> GetUsersByIdAsync(Guid id);


        Task<User> GetUsersByNameAsync(String name);


        Task<User> EditUsersAsync(User user);


        Task<User> DeleteUsersAsync(Guid id);

    }
}
