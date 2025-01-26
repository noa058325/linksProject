using links.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
        public interface IRecommendRepository
        {
            List<Recommend> GetAll();
        Recommend GetById(int id);
            void Add(Recommend user);
            void Update(Recommend user);
            void Delete(int id);
        }
    

}

