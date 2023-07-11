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


        public VillaNumberController(IMapper mapper, IVillaNumberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            _response = new();
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                VillaNumber villaNumber = await _repository.GetAsync(filter: x => x.VillaNo == id);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO dTO)
        {
            try
            {
                if (await _repository.GetAsync(filter: x => x.VillaNo == dTO.VillaNo) != null)
                {
                    ModelState.AddModelError("CustomError", "VillaNumber is already exists");
                    return Ok(ModelState);
                }
                if (dTO == null)
                {
                    return BadRequest();
                }
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(dTO);
                await _repository.CreateAsync(villaNumber);

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = villaNumber;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<String> { e.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO dTO)
        {
            try
            {
                if (dTO == null || id != dTO.VillaNo)
                {
                    return BadRequest();
                }
                VillaNumber villaNumber = _mapper.Map<VillaNumber>(dTO);
                await _repository.Updateasync(villaNumber);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = villaNumber;
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
