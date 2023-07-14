using Web_mvc.Models.DTO;

namespace Web_mvc.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDTO dTO);
        Task<T> UpdateAsync<T>(VillaUpdateDTO dTO);
        Task<T> DeleteAsync<T>(int id);
    }
}
