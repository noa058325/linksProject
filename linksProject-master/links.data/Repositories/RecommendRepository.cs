using links.Core.Repositories;
using links.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Data.Repositories
{
    public class RecommendRepository : IRecommendRepository
    {
        private readonly DataContext _context;

        public RecommendRepository(DataContext context)
        {
            _context = context;
        }

        // מחזיר את כל ההמלצות
        public async Task<List<Recommend>> GetAllAsync()
        {
            return await _context.Recommends.ToListAsync();
        }

        // מחזיר המלצה לפי מזהה
        public Recommend GetById(int id)
        {
            return _context.Recommends.FirstOrDefault(r => r.Id == id);
        }

        // מוסיף המלצה חדשה
        public async Task AddAsync(Recommend recommend)
        {
            _context.Recommends.Add(recommend);
            await _context.SaveChangesAsync();
        }

        // מעדכן המלצה קיימת
        public Recommend Update(int id, Recommend recommend)
        {
            var existingRecommend = _context.Recommends.FirstOrDefault(r => r.Id == id);
            if (existingRecommend != null)
            {
                existingRecommend.Name = recommend.Name;
                existingRecommend.Description = recommend.Description;
                existingRecommend.idUser = recommend.idUser;

                _context.SaveChanges();
                return existingRecommend;
            }
            return null;
        }

        // מוחק המלצה לפי מזהה
        public async Task Delete(int id)
        {
            var recommend = await _context.Recommends.FirstOrDefaultAsync(r => r.Id == id);
            if (recommend != null)
            {
                _context.Recommends.Remove(recommend);
                await _context.SaveChangesAsync();
            }
        }
    }
}
