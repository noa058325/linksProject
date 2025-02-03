using links.Data;
using links.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync(); // מחזיר את כל הקטגוריות
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id); // מחזיר קטגוריה לפי מזהה
        }

        public async Task AddAsync(Category category)
        {
            if (!await _context.Categories.AnyAsync(c => c.Id == category.Id))
            {
                await _context.Categories.AddAsync(category); // מוסיף קטגוריה חדשה
                await _context.SaveChangesAsync(); // שומר את השינויים
            }
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name; // מעדכן שם קטגוריה
                await _context.SaveChangesAsync();
                return existingCategory; // מחזיר את הקטגוריה המעודכנת
            }
            return null; // מחזיר null אם הקטגוריה לא נמצאה
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category); // מוחק קטגוריה
                await _context.SaveChangesAsync(); // שומר את השינויים
            }
        }
    }
}
