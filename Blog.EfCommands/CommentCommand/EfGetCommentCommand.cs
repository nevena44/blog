using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.CommentCommand;
using Blog.Application.DTO.Comment;
using Blog.Application.Exceptions;
using Blog.Application.PageResponses;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace Blog.EfCommands.CommentCommand
{
    public class EfGetCommentCommand : BaseEfCommand, IGetCommentCommand
    {
        public EfGetCommentCommand(BlogContext context) : base(context)
        {
        }

        public PageResponse<CommentDto> Execute(CommentSearch request)
        {
            var comment = Context.Comments.Include(c => c.UserId == request.UserId);

            if (comment == null)
            {
                throw new EntityNotFoundException("User");
            }

            if(request.UserId != 0)
            {
                Context.Comments.Where(c => c.UserId == request.UserId);
            }

            var comments = Context.Comments.AsQueryable();

            var totalCount = comments.Count();
            comments = comments.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PageResponse<CommentDto>
            {
                TotalCount = totalCount,
                PagesCount = pageCount,
                CurrentPage = request.PageNumber,
                Data = comments.Select(u => new CommentDto
                {
                   Description = u.Description,
                   PostId = u.Post.Title,
                   UserId = u.User.Username
                }).ToList()
            };

            return response;
        }
    }
}
