using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.CommentCommand;
using Blog.Application.DTO.Comment;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.CommentCommand
{
    public class EfCreateCommentCommand : BaseEfCommand , ICreateCommentCommand
    {
        public EfCreateCommentCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(DtoComment request)
        {
            if (!Context.Comments.Any(c => c.PostId == request.PostId))
            {
                throw new EntityNotFoundException("Post");
            }

            if (!Context.Comments.Any(c => c.UserId == request.UserId))
            {
                throw new EntityNotFoundException("User");
            }

            Context.Comments.Add(new Domen.Comment
            {
                Description = request.Description,
                PostId = request.PostId,
                UserId = request.UserId,
                IsDeleted = false
            });

            Context.SaveChanges();
        }
    }
}
