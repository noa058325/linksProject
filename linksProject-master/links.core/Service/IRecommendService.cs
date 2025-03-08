using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public interface IRecommendService
    {
        Task<List<Recommend>> GetListAsync();           // מחזיר רשימה של המלצות
        Recommend GetById(int id);                      // מחזיר המלצה לפי מזהה
        Task AddAsync(Recommend recommend);             // מוסיף המלצה חדשה
        Recommend UpdateRecommend(Recommend recommend); // מעדכן המלצה קיימת
        Task DeleteRecommendAsync(int id);              // מוחק המלצה לפי מזהה
    }
}
