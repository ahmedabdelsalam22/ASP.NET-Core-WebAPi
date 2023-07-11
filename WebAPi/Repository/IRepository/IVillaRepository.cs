using System.Linq.Expressions;
using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    public interface IVillaRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
