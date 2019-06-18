using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.CommentCommand;
using Blog.Application.DTO.Comment;
using Blog.Application.Exceptions;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace Blog.EfCommands.CommentCommand
{
    public class EfGetCommentCommandUnpagge : BaseEfCommand, IGetCommentCommandUnpagge
    {
        public EfGetCommentCommandUnpagge(BlogContext context) : base(context)
        {
        }

        public IEnumerable<CommentDto> Execute(CommentSearch request)
        {
            var comment = Context.Comments.Where(c => c.UserId == request.UserId);

            if (comment == null)
            {
                throw new EntityNotFoundException("User");
            }

                if (request.UserId != 0)
                {
                    Context.Comments.Where(c => c.UserId == request.UserId);
                }

                var comments = Context.Comments.AsQueryable();


                return comment.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    PostId = c.Post.Title,
                    UserId = c.User.Username
                }).ToList();

            }
        }
    }

