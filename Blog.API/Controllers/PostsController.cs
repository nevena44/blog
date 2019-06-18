using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.DTO;
using Blog.Application.Commands;
using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO;
using Blog.Application.DTO.Post;
using Blog.Application.Exceptions;
using Blog.Application.Helpers;
using Blog.Application.PageResponses;
using Blog.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private int idslika;
        private readonly IGetPostCommand _getAllPost;
        private readonly ICreatePostCommand _createPost;
        private readonly IEditPostCommand _editPost;
        private readonly IDeletePostCommand _deletePost;
        private readonly IGetOnePostCommand _getOnePost;
        private readonly ICreateImageCommand _createImage;

        public PostsController(IGetPostCommand getAllPost, ICreatePostCommand createPost, IEditPostCommand editPost, IDeletePostCommand deletePost, IGetOnePostCommand getOnePost, ICreateImageCommand createImage)
        {
            _getAllPost = getAllPost;
            _createPost = createPost;
            _editPost = editPost;
            _deletePost = deletePost;
            _getOnePost = getOnePost;
            _createImage = createImage;
        }

        /// <summary>
        /// Get all Posts.
        /// </summary>
        [HttpGet]
        public ActionResult Get([FromQuery] PostSearch search)
        {
            try
            {
                var posts = _getAllPost.Execute(search);
                return Ok(posts);
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

        /// <summary>
        /// Get a specific Post.
        /// </summary>

        [LoggedIn]
        [HttpGet("{id}")]
        public ActionResult<PostDto> Get(int id)
        {
            try
            {
                var post = _getOnePost.Execute(id);
                return Ok(post);
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

        /// <summary>
        /// Create a specific Post.
        /// </summary>
        [LoggedIn("Admin")]
        [HttpPost]
        public ActionResult Post([FromForm] PostDtoNovo dto)
        {

            var ext = Path.GetExtension(dto.Picture.FileName);

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + dto.Picture.FileName.ToString();

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", newFileName);


                dto.Picture.CopyTo(new FileStream(filePath, FileMode.Create));

                var slika = new PictureDto {
                    Name = newFileName
                };

                    this.idslika = _createImage.Execute(slika);
                

                var post = new CreatePostDto
                {
                    Title = dto.Title,
                    SubTitle = dto.SubTitle,
                    Description = dto.Description,
                    PictureId =idslika,
                    HasTagIds= dto.HasTagIds,
                    UserId = dto.UserId

                };
                _createPost.Execute(post);
                return StatusCode(201);
            }
            catch(EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }

        }

        /// <summary>
        /// Update a specific Post.
        /// </summary>
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult<CreatePostDto> Put(int id, [FromBody] PostDtoNovo dto)
        {
            dto.Id = id;

            try
            {
                var ext = Path.GetExtension(dto.Picture.FileName);

                if (!FileUpload.AllowedExtensions.Contains(ext))
                {
                    return UnprocessableEntity("Image extension is not allowed.");
                }

                    var newFileName = Guid.NewGuid().ToString() + "_" + dto.Picture.FileName.ToString();

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", newFileName);


                    dto.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                 var slika = new PictureDto
                {
                    Name = newFileName
                };

                this.idslika = _createImage.Execute(slika);

                var post = new CreatePostDto
                    {
                        Title = dto.Title,
                        SubTitle = dto.SubTitle,
                        Description = dto.Description,
                        PictureId = idslika,
                        HasTagIds = dto.HasTagIds,
                        UserId = dto.UserId

                    };
                    _editPost.Execute(post);
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

        /// <summary>
        /// Deletes a specific Post.
        /// </summary>
        [LoggedIn("Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deletePost.Execute(id);
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
