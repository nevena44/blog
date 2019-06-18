using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands;
using Blog.Application.Commands.PostCommand;
using Blog.Application.DTO;
using Blog.Application.DTO.Hashtag;
using Blog.Application.DTO.Post;
using Blog.Application.DTO.User;
using Blog.Application.Exceptions;
using Blog.Application.Helpers;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Blog.MVC.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class PostsController : Controller
    {
        private int slikaId;
        private readonly IGetPostCommandUnPagginate _getAllPosts;
        private readonly ICreatePostCommand _createPost;
        private readonly IEditPostCommand _editPost;
        private readonly IDeletePostCommand _deletePost;
        private readonly IGetOnePostCommand _getOnePost;
        private readonly ICreateImageCommand _createImage;
        private readonly BlogContext _context;

        public PostsController(int slikaId, IGetPostCommandUnPagginate getAllPosts, ICreatePostCommand createPost, IEditPostCommand editPost, IDeletePostCommand deletePost, IGetOnePostCommand getOnePost, ICreateImageCommand createImage, BlogContext context)
        {
            this.slikaId = slikaId;
            _getAllPosts = getAllPosts;
            _createPost = createPost;
            _editPost = editPost;
            _deletePost = deletePost;
            _getOnePost = getOnePost;
            _createImage = createImage;
            _context = context;
        }


        // GET: Posts
        public ActionResult Index(PostSearch search)
        {
            var posts =_getAllPosts.Execute(search);
            return View(posts);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            var post = _getOnePost.Execute(id);
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.Users = _context.Users.Select(u => new UserDto
            {
                Username = u.Username,
                Id = u.Id
            });

            ViewBag.Hashtag = _context.Hashtags.Select(h => new HashtagDto
            {
                Id = h.Id,
                Name = h.Name
            });
            
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] PostssDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var ext = Path.GetExtension(dto.Picture.FileName);

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                TempData["error"] = "Image extension is not allowed.";
            }
            try
            {

                var newFileName = Guid.NewGuid().ToString() + "_" + dto.Picture.FileName.ToString();

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                dto.Picture.CopyTo(new FileStream(filePath, FileMode.Create));

                var slika = new PictureDto
                {
                    Name = newFileName
                };

                try
                {
                    this.slikaId = _createImage.Execute(slika);
                }

                catch(Exception)
                {
                    TempData["error"] = "Image is not post.";
                }

                var post = new CreatePostDto
                {
                    Title = dto.Title,
                    SubTitle = dto.SubTitle,
                    Description = dto.Description,
                    UserId = dto.UserId,
                    HasTagIds = dto.HasTagIds,
                    PictureId = slikaId
                   
                };
                _createPost.Execute(post);

                TempData["success"] = "Your post has been created!";
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Users = _context.Users.Select(u => new UserDto
            {
                Username = u.Username,
                Id = u.Id
            });

            ViewBag.Hashtag = _context.Hashtags.Select(h => new HashtagDto
            {
                Id = h.Id,
                Name = h.Name
            });
            return View();
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostssDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var ext = Path.GetExtension(dto.Picture.FileName);

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                TempData["error"] = "Image extension is not allowed.";
            }
            try
            {

                var newFileName = Guid.NewGuid().ToString() + "_" + dto.Picture.FileName.ToString();

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                dto.Picture.CopyTo(new FileStream(filePath, FileMode.Create));

                var slika = new PictureDto
                {
                    Name = newFileName
                };

                try
                {
                    this.slikaId = _createImage.Execute(slika);
                }

                catch (Exception)
                {
                    TempData["error"] = "Image is not post.";
                }

                var post = new CreatePostDto
                {
                    Title = dto.Title,
                    SubTitle = dto.SubTitle,
                    Description = dto.Description,
                    UserId = dto.UserId,
                    HasTagIds = dto.HasTagIds,
                    PictureId = slikaId

                };
                _createPost.Execute(post);

                TempData["success"] = "Your post has been created!";
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id,PostDto dto)
        {
            var post =_getOnePost.Execute(id);
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _deletePost.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}