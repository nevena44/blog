using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGetUserCommand _getAllUsers;
        private readonly IGetOneUserCommand _getOneUser;
        private readonly IEditUserCommand _editUser;
        private readonly ICreateUserCommand _createUser;
        private readonly IDeleteUserCommand _deleteUser;

        public UsersController(IGetUserCommand getAllUsers, IGetOneUserCommand getOneUser, IEditUserCommand editUser, ICreateUserCommand createUser, IDeleteUserCommand deleteUser)
        {
            _getAllUsers = getAllUsers;
            _getOneUser = getOneUser;
            _editUser = editUser;
            _createUser = createUser;
            _deleteUser = deleteUser;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get([FromQuery] UserSearch search)
        {
            try
            {
                var users = _getAllUsers.Execute(search);
                return Ok(users);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            try
            {
                var user = _getOneUser.Execute(id);
                return Ok(user);
            }
            catch (Exception e)
            {

                return StatusCode(500,e);
            }
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody] CreateUserDto dto)
        {
            try
            {
                _createUser.Execute(dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
                throw;
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateUserDto dto)
        {
            dto.Id = id;

            try
            {
                _editUser.Execute(dto);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500,e);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteUser.Execute(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }
        }
    }
}
