using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPi.Data;
using WebAPi.Models;
using WebAPi.Repository.IRepository;

namespace WebAPi.Repository
{
    public class VillaRepository : Repository<Villa>,IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Villa> UpdateAsync(Villa entity)
        {
             _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
