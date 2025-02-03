using links.Core.Repositories;
using links.Core.Services;
using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Service
{
    public class RecommendService : IRecommendService
    {
        private readonly IRecommendRepository _recommendRepository;

        public RecommendService(IRecommendRepository recommendRepository)
        {
            _recommendRepository = recommendRepository;
        }

        // מחזיר רשימה של המלצות
        public async Task<List<Recommend>> GetListAsync()
        {
            return await _recommendRepository.GetAllAsync();
        }

        // מחזיר המלצה לפי מזהה
        public Recommend GetById(int id)
        {
            return _recommendRepository.GetById(id);
        }

        // מוסיף המלצה חדשה
        public async Task AddAsync(Recommend recommend)
        {
            await _recommendRepository.AddAsync(recommend);
        }

        // מעדכן המלצה קיימת
        public Recommend UpdateRecommend(Recommend recommend)
        {
            var existingRecommend = _recommendRepository.GetById(recommend.Id);
            if (existingRecommend != null)
            {
                existingRecommend.Name = recommend.Name;
                existingRecommend.Description = recommend.Description;
                existingRecommend.idUser = recommend.idUser;

                return _recommendRepository.Update(recommend.Id, existingRecommend);
            }
            return null;
        }

        // מוחק המלצה לפי מזהה
        public async Task DeleteRecommendAsync(int id)
        {
            await _recommendRepository.Delete(id);
        }
    }
}
