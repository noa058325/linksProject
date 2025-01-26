using links.Data;
using links.Entities;

namespace links.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //private readonly List<Category> _categories = new List<Category>(); // רשימה שמחזיקה את הקטגוריות
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList(); // מחזיר את כל הקטגוריות
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id); // מחזיר קטגוריה לפי מזהה
        }

        public void Add(Category category)
        {
            if (!_context.Categories.Any(c => c.Id == category.Id))
            {
                _context.Categories.Add(category); // מוסיף קטגוריה חדשה אם המזהה לא קיים
                _context.SaveChanges();
            }
        }

        public void Update(Category category)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name; // מעדכן שם קטגוריה
                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category); // מוחק קטגוריה מהרשימה
                _context.SaveChanges();
            }
        }
    }
}
