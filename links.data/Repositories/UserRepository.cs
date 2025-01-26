using Microsoft.EntityFrameworkCore;
using links.Core.Repositories;
using links.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace links.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {    //פונק'
            return _context.Users.ToList();
        }
       
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(c => c.id == id); // מחזיר משתמש לפי מזהה
        }

        public void Add(User user)
        {
            if (!_context.Users.Any(c => c.id == user.id))
            {
                _context.Users.Add(user); // מוסיף משתמש חדשה אם המזהה לא קיים
                _context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(c => c.id == user.id);
            if (existingUser != null)
            {
                existingUser.name = user.name; // מעדכן שם משתמש
                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.id == id);
            if (user != null)
            {
                _context.Users.Remove(user); // מוחק משתמש מהרשימה
                _context.SaveChanges();
            }
        }
    }
}