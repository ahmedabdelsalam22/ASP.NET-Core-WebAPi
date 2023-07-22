using WebAPi.Data;
using WebAPi.Models;
using WebAPi.Models.DTO;
using WebAPi.Repository.IRepository;

namespace WebAPi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
