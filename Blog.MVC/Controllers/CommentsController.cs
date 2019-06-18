using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.CommentCommand;
using Blog.Application.DTO.Comment;
using Blog.Application.DTO.Post;
using Blog.Application.DTO.User;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IGetCommentCommandUnpagge _getComment;
        private readonly IGetOneCommentCommand _getOneComment;
        private readonly IEditCommentCommand _editCOmment;
        private readonly IDeleteCommentCommand _deleteCOmment;
        private readonly ICreateCommentCommand _createCOmment;
        private readonly BlogContext _context;

        public CommentsController(IGetCommentCommandUnpagge getComment, IGetOneCommentCommand getOneComment, IEditCommentCommand editCOmment, IDeleteCommentCommand deleteCOmment, ICreateCommentCommand createCOmment, BlogContext context)
        {
            _getComment = getComment;
            _getOneComment = getOneComment;
            _editCOmment = editCOmment;
            _deleteCOmment = deleteCOmment;
            _createCOmment = createCOmment;
            _context = context;
        }

        // GET: Comments
        public ActionResult Index(CommentSearch search)
        {
            var comm = _getComment.Execute(search);
            return View(comm);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            var comm = _getOneComment.Execute(id);
            return View(comm);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.Users = _context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username
            });

            ViewBag.Posts = _context.Posts.Select(p => new CreatePostDto
            {
                Id = p.Id,
                Title = p.Title
            });
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DtoComment dto)
        {
            try
            {
                _createCOmment.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Users = _context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username
            });

            ViewBag.Posts = _context.Posts.Select(p => new CreatePostDto
            {
                Id = p.Id,
                Title = p.Title
            });
            return View();
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DtoComment dto)
        {
            dto.Id = id;
            try
            {
                _editCOmment.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id, CommentDto collection)
        {
            var dto = _getOneComment.Execute(id);
            return View(dto);
        }

        // POST: Comments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCOmment.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}