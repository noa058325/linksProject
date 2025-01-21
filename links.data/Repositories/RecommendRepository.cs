using Microsoft.EntityFrameworkCore;
using Project.Core.Repositories;
using Project.Entities;

namespace Project.Data.Repositories
{
    public class RecommendRepository : IRecommendRepository
    {
        private readonly DataContext _context;

        public RecommendRepository(DataContext context)
        {
            _context = context;
        }

        public List<Recommend> GetAll()
        {
            // מחזיר את כל ההמלצות
            return _context.Recommends.ToList();
        }

        public Recommend GetById(int id)
        {
            // מחזיר המלצה לפי מזהה
            return _context.Recommends.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Recommend recommend)
        {
            // מוסיף המלצה חדשה
            _context.Recommends.Add(recommend);
            _context.SaveChanges();
        }

        public void Update(Recommend recommend)
        {
            // מעדכן את ההמלצה הקיימת
            _context.Recommends.Update(recommend);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // מוחק המלצה לפי מזהה
            var recommend = _context.Recommends.FirstOrDefault(r => r.Id == id);
            if (recommend != null)
            {
                _context.Recommends.Remove(recommend);
                _context.SaveChanges();
            }
        }
    }
}
