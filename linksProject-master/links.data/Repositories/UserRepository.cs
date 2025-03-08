using Microsoft.EntityFrameworkCore;
using links.Core.Repositories;
using links.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace links.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.id == id);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public User Update(int id, User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.id == id);
            if (existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.Email = user.Email;
                existingUser.PhoneNamber = user.PhoneNamber;
                _context.SaveChanges();
                return existingUser;
            }
            return null;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
