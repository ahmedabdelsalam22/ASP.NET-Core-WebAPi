using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPi.Models;
using WebAPi.Models.DTO;
using WebAPi.Repository.IRepository;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly APIResponse _APIResponse;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
            _APIResponse = new();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dTO)
        {
            var loginResponse = await _repository.Login(dTO);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add("Username or password is incorrect");
                return BadRequest(_APIResponse);
            }
            _APIResponse.StatusCode = HttpStatusCode.OK;
            _APIResponse.IsSuccess = true;
            _APIResponse.Result = loginResponse;
            return Ok(_APIResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO dTO)
        {
            bool ifUserNameIsUnique = _repository.IsUniqueUser(dTO.UserName);
            if (!ifUserNameIsUnique)
            {
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add("Username already exists");
                return BadRequest(_APIResponse);
            }
            var user =await _repository.Register(dTO);
            if (user == null)
            {
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add("Error while registering");
                return BadRequest(_APIResponse);
            }
            _APIResponse.StatusCode = HttpStatusCode.OK;
            _APIResponse.IsSuccess = true;
            return Ok(_APIResponse);
        }
    }
}
