using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task Updateasync(VillaNumber entity);
    }
}
