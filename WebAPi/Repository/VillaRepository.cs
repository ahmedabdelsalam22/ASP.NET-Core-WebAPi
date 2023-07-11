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


    }
}
