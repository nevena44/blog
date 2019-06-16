using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.DTO.Hashtag;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashtagsController : ControllerBase
    {
        private readonly IGetHashtagCommand _getAllHashtag;
        private readonly ICreateHashtagCommand _createHashtag;
        private readonly IGetOneHashtagCommand _getOneHashtag;
        private readonly IEditHashtagCommand _editHashtag;
        private readonly IDeleteHashtagCommand _deleteHashtag;

        public HashtagsController(IGetHashtagCommand getAllHashtag, ICreateHashtagCommand createHashtag, IGetOneHashtagCommand getOneHashtag, IEditHashtagCommand editHashtag, IDeleteHashtagCommand deleteHashtag)
        {
            _getAllHashtag = getAllHashtag;
            _createHashtag = createHashtag;
            _getOneHashtag = getOneHashtag;
            _editHashtag = editHashtag;
            _deleteHashtag = deleteHashtag;
        }

        // GET: api/Hashtags
        [HttpGet]
        public ActionResult<IEnumerable<HashtagDto>> Get([FromQuery] HashtagSearch search)
        {
            try
            {
                var hashtags = _getAllHashtag.Execute(search);
                return Ok(hashtags);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        // GET: api/Hashtags/5
        [HttpGet("{id}")]
        public ActionResult<HashtagDto> Get(int id)
        {
            try
            {
                var hashtag = _getOneHashtag.Execute(id);
                    return Ok(hashtag);
            }
            catch (Exception e)
            {

                return StatusCode(500,e);
            }
        }

        // POST: api/Hashtags
        [HttpPost]
        public ActionResult Post([FromBody] CreateHashtagDto dto)
        {
            try
            {
                _createHashtag.Execute(dto);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Hashtags/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] HashtagDto dto)
        {
            dto.Id = id;

            try
            {
                _editHashtag.Execute(dto);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteHashtag.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
