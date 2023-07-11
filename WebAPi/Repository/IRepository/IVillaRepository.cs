using System.Linq.Expressions;
using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa,bool>> filter = null);
        Task<Villa> Get(Expression<Func<Villa, bool>> filter = null ,bool tracked = true);
        Task Create(Villa entity);
        Task Remove(Villa entity);
        Task Save();
    }
}
