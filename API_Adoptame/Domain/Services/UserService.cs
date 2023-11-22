using API_Adoptame.DAL.Entities;
using API_Adoptame.DAL;
using Microsoft.EntityFrameworkCore;
using API_Adoptame.Domain.Interfaces;

namespace API_Adoptame.Domain.Services
{
    public class UserService : IUserService
    {
        public readonly DataBaseContext _context;
        public UserService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUserAsync()
        {

            var users = await _context.Users.ToListAsync();

            return users;

        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                user.IDuser = Guid.NewGuid();
                user.CreateDate = DateTime.Now;


                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}
