using links.Entities;
using System.Collections.Generic;

namespace links.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
