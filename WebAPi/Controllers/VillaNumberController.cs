using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        private readonly APIResponse _response;
        private readonly IVillaNumberRepository _repository;


        public VillaNumberController(IMapper mapper, IVillaNumberRepository repository, APIResponse response)
        {
            _mapper = mapper;
            _repository = repository;
            _response = response;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetAllVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumber = await _repository.GetAllAsync();

                IEnumerable<VillaNumberDTO> villaNumberDTO = _mapper.Map<IEnumerable<VillaNumberDTO>>(villaNumber);

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = villaNumberDTO;

                return Ok(_response);
            }
            catch (Exception e) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<String> { e.ToString()};
            }
            return _response;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<APIResponse>> GetVilla(int villaNo)
        {
            try
            {
                if (villaNo == 0)
                {
                    return BadRequest();
                }
                VillaNumber villaNumber = await _repository.GetAsync(filter: x => x.VillaNo == villaNo);
                if (villaNumber == null)
                {
                    return NotFound();
                }
                VillaNumberDTO villaNumberDTO = _mapper.Map<VillaNumberDTO>(villaNumber);

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = villaNumberDTO;
                return Ok(_response);
            }
            catch (Exception e) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<String> { e.ToString() };
            }
            return _response;
        }

    }
}
