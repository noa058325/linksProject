using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public interface IUserService
    {
        Task<List<User>> GetListAsync();  // מחזיר את כל המשתמשים
        User GetById(int id);  // מחזיר משתמש לפי מזהה
        Task<User> AddAsync(User user);  // מוסיף משתמש חדש ומחזיר אותו
        User Update(int id, User user);  // מעדכן משתמש קיים
        Task<bool> Delete(int id);  // מוחק משתמש, מחזיר true אם הצליח, false אם לא
    }
}
