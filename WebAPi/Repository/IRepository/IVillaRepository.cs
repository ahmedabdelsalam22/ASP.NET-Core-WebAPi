using System.Linq.Expressions;
using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);
        Task<Villa> GetFirstOrDefault(Expression<Func<Villa,bool>> filter);
        Task<Villa> Get(Expression<Func<Villa>> filter = null ,bool tracked = true);
        Task Create(Villa entity);
        Task Remove();
        Task SaveChanges();
    }
}
