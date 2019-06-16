using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.DTO.Hashtag;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class HashtagsController : Controller
    {

        private readonly BlogContext _context;
        private readonly IGetHashtagCommand _getAllHashtags;
        private readonly IGetOneHashtagCommand _getOneHashtag;
        private readonly ICreateHashtagCommand _createHashtag;
        private readonly IEditHashtagCommand _editHashtag;
        private readonly IDeleteHashtagCommand _deleteHashtag;

        public HashtagsController(BlogContext context, IGetHashtagCommand getAllHashtags, IGetOneHashtagCommand getOneHashtag, ICreateHashtagCommand createHashtag, IEditHashtagCommand editHashtag, IDeleteHashtagCommand deleteHashtag)
        {
            _context = context;
            _getAllHashtags = getAllHashtags;
            _getOneHashtag = getOneHashtag;
            _createHashtag = createHashtag;
            _editHashtag = editHashtag;
            _deleteHashtag = deleteHashtag;
        }

        // GET: Hashtags
        public ActionResult<IEnumerable<HashtagDto>> Index(HashtagSearch search)
        {
            var dto = _getAllHashtags.Execute(search);
            return View(dto);
        }

        // GET: Hashtags/Details/5
        public ActionResult<HashtagDto> Details(int id)
        {
            var hashtag = _getOneHashtag.Execute(id);
            return View(hashtag);
        }

        // GET: Hashtags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hashtags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hashtags/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hashtags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hashtags/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hashtags/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}