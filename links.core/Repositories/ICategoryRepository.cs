using links.Entities;
using System.Collections.Generic;

namespace links.Core.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll(); // מחזיר את כל הקטגוריות
        Category GetById(int id); // מחזיר קטגוריה לפי מזהה
        void Add(Category category); // מוסיף קטגוריה חדשה
        void Update(Category category); // מעדכן קטגוריה קיימת
        void Delete(int id); // מוחק קטגוריה לפי מזהה
    }
}
