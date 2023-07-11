using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPi.Data;
using WebAPi.Models;
using WebAPi.Repository.IRepository;

namespace WebAPi.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Villa> _dbset;

        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbset = _db.Set<Villa>();
        }

        public async Task Create(Villa entity)
        {
            await _dbset.AddAsync(entity);
            await Save();
        }

        public async Task<Villa> Get(Expression<Func<Villa,bool>> filter = null, bool tracked = true)
        {
            IQueryable<Villa> query = _dbset;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Villa>> GetAll(Expression<Func<Villa,bool>> filter = null)
        {
            IQueryable<Villa> query = _dbset;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task Remove(Villa entity)
        {
             _dbset.Remove(entity);
             await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
