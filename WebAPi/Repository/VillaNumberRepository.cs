using WebAPi.Data;
using WebAPi.Models;
using WebAPi.Repository.IRepository;

namespace WebAPi.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberRepository(ApplicationDbContext db, ApplicationDbContext context) : base(db)
        {
            _context = context;
        }

        public async Task Updateasync(VillaNumber entity)
        {
            _context.VillaNumbers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
