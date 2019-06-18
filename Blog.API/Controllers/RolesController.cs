using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.DTO.Role;
using Blog.Application.Exceptions;
using Blog.Application.Helpers;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRoleCommand _getAllRole;
        private readonly ICreateRoleCommand _createRole;
        private readonly IDeleteRoleCommand _deleteRole;
        private readonly IGetOneRoleCommand _getOneRole;
        private readonly IEditRoleCommand _editRole;

        public RolesController(IGetRoleCommand getAllRole, ICreateRoleCommand createRole, IDeleteRoleCommand deleteRole, IGetOneRoleCommand getOneRole, IEditRoleCommand editRole)
        {
            _getAllRole = getAllRole;
            _createRole = createRole;
            _deleteRole = deleteRole;
            _getOneRole = getOneRole;
            _editRole = editRole;
        }

        // GET: api/Roles
        [LoggedIn]
        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> Get([FromQuery] RoleSearch search)
        {
            try
            {
                var roles = _getAllRole.Execute(search);
                return Ok(roles);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
            
        }

        // GET: api/Roles/5
        [LoggedIn]
        [HttpGet("{id}")]
        public ActionResult<RoleDto> Get(int id)
        {
            try
            {
                var role = _getOneRole.Execute(id);
                return Ok(role);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        // POST: api/Roles
        [LoggedIn("Admin")]
        [HttpPost]
        public ActionResult Post([FromBody] CreteRoleDto dto)
        {
            try
            {
                _createRole.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
                
            }
        }

        // PUT: api/Roles/5
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult<RoleDto> Put(int id, [FromQuery] RoleDto dto)
        {
            dto.Id = id;
            try
            {
                _editRole.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteRole.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }

        }
    }
}
