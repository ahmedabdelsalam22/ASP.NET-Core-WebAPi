using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Models;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa> 
            {
                new Villa {Id = 1,Name = "Villa1"},
                new Villa {Id = 2,Name = "Villa2"},
            };              
        }
    }
}
