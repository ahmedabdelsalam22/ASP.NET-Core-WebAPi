using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_mvc.Models;
using Web_mvc.Models.DTO;
using Web_mvc.Services.IServices;

namespace Web_mvc.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _service;
        public VillaController(IVillaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var response = await _service.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
