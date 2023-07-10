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
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.VillaList);           
        }
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(x=>x.Id == id);
            if (villa == null) 
            {
                return NotFound();
            }
            return Ok(villa);
        }
    }
}
