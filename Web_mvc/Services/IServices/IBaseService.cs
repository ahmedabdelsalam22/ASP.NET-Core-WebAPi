using Web_mvc.Models;

namespace Web_mvc.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responseModel { get; set; }

        Task<T> SendAsync<T> (ApiRequest apiRequest);
    }
}
