using System.Linq.Expressions;
using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
