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
    public class EfEditCommentCommand : BaseEfCommand, IEditCommentCommand
    {
        public EfEditCommentCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(DtoComment request)
        {
            var comm = Context.Comments.AsQueryable();

            var comment = Context.Comments.Find(request.Id);

            if(comment == null)
            {
                throw new EntityNotFoundException("Comment");
            }

            if(!comm.Any(c => c.PostId == request.PostId))
            {
                throw new EntityNotFoundException("Post");
            }

            if(!comm.Any(c => c.UserId == request.UserId))
            {
                throw new EntityNotFoundException("User");
            }

            if(comment.IsDeleted == true)
            {
                throw new EntityNotFoundException("Comment");
            }

            comment.Description = request.Description;
            comment.PostId = request.PostId;
            comment.UserId = request.UserId;
            comment.ModifiedAt = DateTime.Now;

            Context.SaveChanges();
        }
    }
}
