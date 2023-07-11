using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPi.Data;
using WebAPi.Models;
using WebAPi.Models.DTO;
using WebAPi.Repository.IRepository;

namespace WebAPi.Controllers
{
    //[Route("api/VillaAPI")]
    [Route("api/[Controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVillaRepository _repository;
        private APIResponse _response;
        public VillaAPIController(IVillaRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _response = new();
        }

        [HttpGet(Name = "GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villas = await _repository.GetAllAsync();

                var villaDTO = _mapper.Map<IEnumerable<VillaDTO>>(villas);

                _response.Result = villaDTO;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception e) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }
        [HttpGet("{id}",Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try 
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                Villa? villa = await _repository.GetAsync(filter: x => x.Id == id);

                if (villa == null)
                {
                    return NotFound();
                }
                VillaDTO villaDTO = _mapper.Map<VillaDTO>(villa);

                _response.Result = villaDTO;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            } catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> Create([FromBody] VillaCreateDTO villaCreateDTO)
        {
            try
            {
                if (await _repository.GetAsync(filter: x => x.Name.ToLower() == villaCreateDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Villa already exists");
                    return BadRequest(ModelState);
                }
                if (villaCreateDTO == null)
                {
                    return BadRequest();
                }

                Villa villa = _mapper.Map<Villa>(villaCreateDTO);

                await _repository.CreateAsync(villa);
                _response.Result = villa;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;

                //return CreatedAtRoute("GetVilla", new { id = villa.Id}, villa);
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }


        [HttpPut(Name ="UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Update(int id, [FromBody]VillaDTO villaDTO)
        {
            try
            {
                if (villaDTO == null || id != villaDTO.Id)
                {
                    return BadRequest();
                }

                Villa villa = _mapper.Map<Villa>(villaDTO);

                await _repository.UpdateAsync(villa);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess= true;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }


        [HttpDelete("{id}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _repository.GetAsync(filter: x => x.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await _repository.RemoveAsync(villa);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }
    }
}
