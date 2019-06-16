using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands;
using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO.Post;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IGetPostCommand _getAllPost;
        private readonly ICreatePostCommand _createPost;
        private readonly IEditPostCommand _editPost;
        private readonly IDeletePostCommand _deletePost;
        private readonly IGetOnePostCommand _getOnePost;

        public PostsController(IGetPostCommand getAllPost, ICreatePostCommand createPost, IEditPostCommand editPost, IDeletePostCommand deletePost, IGetOnePostCommand getOnePost)
        {
            _getAllPost = getAllPost;
            _createPost = createPost;
            _editPost = editPost;
            _deletePost = deletePost;
            _getOnePost = getOnePost;
        }

        // GET: api/Posts
        [HttpGet]
        public ActionResult<IEnumerable<PostDto>> Get([FromQuery] PostSearch search)
        {
            try
            {
                var posts = _getAllPost.Execute(search);
                return Ok(posts);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erorr, come back later! ");
            }
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<PostDto> Get(int id)
        {
            try
            {
                var post = _getOnePost.Execute(id);
                return Ok(post);
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        // POST: api/Posts
        [HttpPost]
        public ActionResult Post([FromBody] CreatePostDto dto)
        {

            try
            {
                _createPost.Execute(dto);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return StatusCode(500,e);
            }

        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public ActionResult<CreatePostDto> Put(int id, [FromBody] CreatePostDto dto)
        {
            dto.Id = id;

            try
            {
                _editPost.Execute(dto);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deletePost.Execute(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }
    }
}
