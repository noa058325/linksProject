using links.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace links.Core.services
{
    public interface ICategoryService
    {
        public List<Category> GetList();
        public Category GetById(int id);
        public Category Add(Category category);
        public Category Update(int id, Category value);
        public void Deletecategory(int id);
        
        //public void Delete(int id);
        //public void GetByid(int id);
    }
}
