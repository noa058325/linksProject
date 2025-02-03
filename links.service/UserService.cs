using links.Core.Repositories;
using links.Core.Services;
using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetListAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;  // מחזיר את המשתמש שנוסף
        }

        public User Update(int id, User user)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.Email = user.Email;
                existingUser.PhoneNamber = user.PhoneNamber;

                return _userRepository.Update(id, existingUser);
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                await _userRepository.Delete(id);
                return true;
            }
            return false;
        }
    }
}
