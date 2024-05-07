using entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Services;
using System.Reflection.Metadata;
using System.Text.Json;
using Zxcvbn;
using entities.Models;
using AutoMapper;
using DTO;
//using Org.BouncyCastle.Crypto.Tls;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        IUserServices userServices;
        IMapper mapper;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserServices _userServices, IMapper _mapper, ILogger<UsersController> logger)
        {
            userServices = _userServices;
            mapper = _mapper;
            _logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers() { 
            IEnumerable<User> users = await userServices.getUsers();
            IEnumerable<UsersDTO> usersDTO = mapper.Map<IEnumerable<User>, IEnumerable<UsersDTO>>(users);
            return Ok(usersDTO);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> get([FromBody] UserLoginDTO userLoginDTO)
        {
            User userExsist = await userServices.getUserByUserNameAndPassword(userLoginDTO.UserName, userLoginDTO.Password);
            if (userExsist == null) { 
                return NoContent();
            }
            _logger.LogInformation("Login attemped with user name: {0} and password {1}", userLoginDTO.UserName , userLoginDTO.Password);
            return Ok(userExsist);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UsersDTO> getUserById(int id)
        {
            User user = await userServices.getUserById(id);
            UsersDTO userDTO = mapper.Map<User, UsersDTO>(user);
            return userDTO;
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<UsersDTO> Post([FromBody] UserRegisterDTO userToRegister)
        {
            User user = mapper.Map<UserRegisterDTO, User>(userToRegister);
            User theAddUser = await userServices.addUser(user);
            if (theAddUser == null) {
                return null;
            }
            UsersDTO userDTO = mapper.Map<User, UsersDTO>(user);
            return userDTO;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserRegisterDTO userToUpdate)
        {
            User user = mapper.Map<UserRegisterDTO, User>(userToUpdate);
            user.UserId = id;
            int score = await userServices.updateUser(id, user);
            if (score <= 2) return BadRequest(new { error = "WeakPassword", message = "Your password is too weak" });
            return Ok(new { message = "Success!" });
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await userServices.DeleteUser(id);
           
        }
    }
}
