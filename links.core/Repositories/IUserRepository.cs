using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();  // מחזיר את כל המשתמשים
        User GetById(int id);  // מחזיר משתמש לפי מזהה
        Task AddAsync(User user);  // מוסיף משתמש חדש
        User Update(int id, User user);  // מעדכן משתמש קיים
        Task Delete(int id);  // מוחק משתמש
    }
}
