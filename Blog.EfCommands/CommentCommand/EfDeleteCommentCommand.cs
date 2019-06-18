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
    public class EfDeleteCommentCommand : BaseEfCommand, IDeleteCommentCommand
    {
        public EfDeleteCommentCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var comment = Context.Comments.Where(c => c.Id == request);

            if(comment == null)
            {
                throw new EntityNotFoundException("Comment");
            }

            var com = Context.Comments.Find(request);

            com.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
