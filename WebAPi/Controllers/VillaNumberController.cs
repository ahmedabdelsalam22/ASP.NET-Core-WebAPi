using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPi.Models;
using WebAPi.Models.DTO;
using WebAPi.Repository.IRepository;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _repository;


        public VillaNumberController(IMapper mapper, IVillaNumberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<VillaNumberDTO>>> GetAllVillaNumbers()
        {
            IEnumerable<VillaNumber> villaNumber = await _repository.GetAllAsync();

            IEnumerable<VillaNumberDTO> villaNumberDTO = _mapper.Map<IEnumerable<VillaNumberDTO>>(villaNumber);

            return Ok(villaNumberDTO);
        }
        
    }
}
