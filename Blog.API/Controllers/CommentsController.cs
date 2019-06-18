using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.CommentCommand;
using Blog.Application.DTO.Comment;
using Blog.Application.Exceptions;
using Blog.Application.Helpers;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGetCommentCommand _getAllComment;
        private readonly IGetOneCommentCommand _getOneComment;
        private readonly ICreateCommentCommand _createComment;
        private readonly IEditCommentCommand _editComment;
        private readonly IDeleteCommentCommand _deleteComment;

        public CommentsController(IGetCommentCommand getAllComment, IGetOneCommentCommand getOneComment, ICreateCommentCommand createComment, IEditCommentCommand editComment, IDeleteCommentCommand deleteComment)
        {
            _getAllComment = getAllComment;
            _getOneComment = getOneComment;
            _createComment = createComment;
            _editComment = editComment;
            _deleteComment = deleteComment;
        }

        // GET: api/Comments
        [LoggedIn]
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> Get([FromQuery] CommentSearch search)
        {
            try
            {
                var comm = _getAllComment.Execute(search);
                return Ok(comm);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            };
        }

        // GET: api/Comments/5
        [LoggedIn]
        [HttpGet("{id}")]
        public ActionResult<CommentDto> Get(int id)
        {
            try
            {
                var com = _getOneComment.Execute(id);
                return Ok(com);
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

        // POST: api/Comments
        [LoggedIn]
        [HttpPost]
        public ActionResult Post([FromBody] DtoComment dto)
        {
            try
            {
                _createComment.Execute(dto);
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

        // PUT: api/Comments/5
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DtoComment dto)
        {
            dto.Id = id;
            try
            {
                _editComment.Execute(dto);
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

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteComment.Execute(id);
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
