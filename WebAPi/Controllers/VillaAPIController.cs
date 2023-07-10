using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Models;
using WebAPi.Models.DTO;

namespace WebAPi.Controllers
{
    [Route("api/VillaAPI")]
    [Route("api/[Controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return new List<VillaDTO> 
            {
                new VillaDTO {Id = 1,Name = "Villa1"},
                new VillaDTO {Id = 2,Name = "Villa2"},
            };              
        }
    }
}
