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
    public class WebRepository : IWebRepository
    {
        

        private readonly DataContext _context;

        public WebRepository(DataContext context)
        {
            _context = context;
        }
        public List<Web> GetAll()
        {
            // מחזיר את כל אתרים
            return _context.Webs.ToList();
        }

        public Web GetById(int id)
        {
            return _context.Webs.FirstOrDefault(c => c.id == id); // מחזיר אתר לפי מזהה
        }

        public void Add(Web web)
        {
            if (!_context.Webs.Any(c => c.id == web.id))
            {
                _context.Webs.Add(web); // מוסיף אתר חדשה אם המזהה לא קיים
                _context.SaveChanges();
            }
        }

        public void Update(Web web)
        {
            var existingWeb = _context.Webs.FirstOrDefault(c => c.id == web.id);
            if (existingWeb != null)
            {
                existingWeb.name = web.name; // מעדכן שם אתר
                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var web = _context.Webs.FirstOrDefault(c => c.id == id);
            if (web != null)
            {
                _context.Webs.Remove(web); // מוחק אתר מהרשימה
                _context.SaveChanges();
            }
        }
    }
}