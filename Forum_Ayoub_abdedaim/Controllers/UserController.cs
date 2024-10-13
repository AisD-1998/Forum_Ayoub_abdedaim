using Microsoft.AspNetCore.Mvc;
using DAO.Models;
using Services.UserService; 
using System.Collections.Generic;

namespace Forum_Ayoub_abdedaim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<Utilisateur> Get()
        {
            return _userService.allUtilisateurs();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public Utilisateur Get(int id)
        {
            return _userService.FindById(id);
        }

        // POST api/user
        [HttpPost]
        public int CreateUser([FromBody] Utilisateur user)
        {
            return _userService.addUtilisateur(user);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public Utilisateur? UpdateUser(int id, [FromBody] Utilisateur user)
        {
            return _userService.updateUtilisateur(user, id);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public Utilisateur? DeleteUser(int id)
        {
            return _userService.deleteUtilisateur(id);
        }
    }
}
