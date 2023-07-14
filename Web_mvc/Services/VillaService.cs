using Web_mvc.Models;
using Web_mvc.Models.DTO;
using Web_mvc.Services.IServices;
using static Web_Utility.SD;

namespace Web_mvc.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClient;
        private string _villaUrl;
        public VillaService(IHttpClientFactory httpClient,IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreateDTO dTO)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = dTO,
                Url = _villaUrl+ "api/VillaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = _villaUrl + "api/VillaAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = _villaUrl + "api/VillaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = _villaUrl + "api/VillaAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dTO)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = dTO,
                Url = _villaUrl + "api/VillaAPI/"+dTO.Id
            });
        }
    }
}
