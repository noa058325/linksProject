using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public interface IRecommendRepository
    {
        Task<List<Recommend>> GetAllAsync(); // מחזיר את כל ההמלצות
        Recommend GetById(int id);           // מחזיר המלצה לפי מזהה
        Task AddAsync(Recommend recommend);  // מוסיף המלצה חדשה
        Recommend Update(int id, Recommend recommend); // מעדכן המלצה
        Task Delete(int id);                 // מוחק המלצה לפי מזהה
    }
}
