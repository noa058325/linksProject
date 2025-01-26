using links.Entities;
using System.Collections.Generic;

namespace links.Core.Repositories
{
    public interface IWebRepository
    {
        List<Web> GetAll();
        Web GetById(int id);
        void Add(Web web);
        void Update(Web web);
        void Delete(int id);
    }
}
