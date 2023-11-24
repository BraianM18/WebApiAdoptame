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





        /*GET ALL*/

        public async Task<IEnumerable<User>> GetUsersAsync()
        {


            var users = await _context.Users.ToListAsync();

            return users;


        }





        /*CREATE*/

        public async Task<User> CreateUsersAsync(User user)
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





        /*GET BY ID*/

        public async Task<User> GetUsersByIdAsync(Guid id)
        {


            return await _context.Users.FirstOrDefaultAsync(p => p.IDuser == id);


        }





        /*GET BY NAME*/

        public async Task<User> GetUsersByNameAsync(String name)
        {


            return await _context.Users.FirstOrDefaultAsync(c => c.Name == name); //es un método propio del db context (db set)


        }




        /*UPDATE*/

        public async Task<User> EditUsersAsync(User user)
        {


            try
            {


                user.ModifiedDate = DateTime.Now;

                _context.Users.Update(user);//Este metodo me sirve para actualizar un objeto
                await _context.SaveChangesAsync();

                return user;


            }
            catch (DbUpdateException dbUpdateException)
            {


                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);


            }


        }





        /*DELETE*/

        public async Task<User> DeleteUsersAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.IDuser == id);

                if (user == null) return null;


                _context.Users.Remove(user);

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
