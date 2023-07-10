using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Data;
using WebAPi.Models;
using WebAPi.Models.DTO;

namespace WebAPi.Controllers
{
    //[Route("api/VillaAPI")]
    [Route("api/[Controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaStore.VillaList;           
        }
        [HttpGet("{id}")]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            var villa = VillaStore.VillaList.FirstOrDefault(x=>x.Id == id);
            if (villa == null) 
            {
                return NotFound();
            }
            return villa;
        }
    }
}
