using Project.Core.Repositories;
using Project.Core.services;
using Project.Entities;
using System.Collections.Generic;

namespace Project.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository; // תלות במחלקת האחסון
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetAll(); // מחזיר את כל הקטגוריות
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id); // מחזיר קטגוריה לפי מזהה
        }

        public Category Add(Category category)
        {
            _categoryRepository.Add(category);
            return category; // מחזיר את הקטגוריה שנוספה
        }

        public Category Update(int id, Category value)
        {
            var existingCategory = _categoryRepository.GetById(id);
            if (existingCategory != null)
            {
                existingCategory.Name = value.Name;

                _categoryRepository.Update(existingCategory);
                return existingCategory; // מחזיר את הקטגוריה שעודכנה
            }
            return null; // אם הקטגוריה לא קיימת
        }

        public void Deletecategory(int id)
        {
            _categoryRepository.Delete(id); // מוחק קטגוריה לפי מזהה
        }
    }
}


