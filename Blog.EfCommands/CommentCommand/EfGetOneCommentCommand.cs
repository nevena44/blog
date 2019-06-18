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
    public class EfGetOneCommentCommand : BaseEfCommand, IGetOneCommentCommand
    {
        public EfGetOneCommentCommand(BlogContext context) : base(context)
        {
        }

        public CommentDto Execute(int request)
        {
            var comment = Context.Comments.Where(c => c.Id == request);

            if(comment == null)
            {
                throw new EntityNotFoundException("Comment");
            }

            return Context.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Description = c.Description,
                PostId = c.Post.Title,
                UserId = c.User.Username
            }).Where(c => c.Id == request).First();
        }
    }
}
