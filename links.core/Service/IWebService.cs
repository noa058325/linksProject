using links.Entities;
using System.Collections.Generic;

namespace links.Core.Services
{
    public interface IWebService
    {
        List<Web> GetList();  // מקבל את כל האתרים
        Web GetById(int id);  // מקבל אתר לפי מזהה
        Web Add(Web web);  // מוסיף אתר חדש
        Web Update(int id, Web web);  // מעדכן את פרטי האתר
        bool Delete(int id);  // מוחק אתר
    }
}
