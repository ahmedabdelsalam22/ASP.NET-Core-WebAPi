using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VillaAPIController(ApplicationDbContext db, IMapper iMapper)
        {
            _db = db;
            _mapper = iMapper;
        }

        [HttpGet(Name = "GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            IEnumerable<Villa> villas = await _db.Villas.AsNoTracking().ToListAsync();

            var villaDTO = _mapper.Map<IEnumerable<VillaDTO>>(villas);

            return Ok(villaDTO);           
        }
        [HttpGet("{id}",Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        public async Task<ActionResult> GetVilla(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }

            Villa? villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);

            if (villa == null) 
            {
                return NotFound();
            }
            VillaDTO villaDTO = _mapper.Map<VillaDTO>(villa);
            return Ok(villaDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<VillaDTO>> Create([FromBody] VillaCreateDTO villaCreateDTO)
        {
            if (await _db.Villas.AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToLower() == villaCreateDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists");
                return BadRequest(ModelState);
            }
            if (villaCreateDTO == null)
            {
                return BadRequest();
            }

            Villa villa = _mapper.Map<Villa>(villaCreateDTO);

            await _db.Villas.AddAsync(villa);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = villa.Id}, villa);
        }


        [HttpPut(Name ="UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, [FromBody]VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }

            Villa villa = _mapper.Map<Villa>(villaDTO);

            _db.Villas.Update(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
