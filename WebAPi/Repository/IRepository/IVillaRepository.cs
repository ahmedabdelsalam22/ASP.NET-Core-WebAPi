using System.Linq.Expressions;
using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task UpdateAsync(Villa entity);
    }
}
