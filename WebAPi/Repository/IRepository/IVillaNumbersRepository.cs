using WebAPi.Models;

namespace WebAPi.Repository.IRepository
{
    interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task Updateasync(VillaNumber entity);
    }
}
