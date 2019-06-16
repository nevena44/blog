using System;
using System.Collections.Generic;
using System.Text;
using Blog.Application.Commands.PostCommand;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PostEfCommand
{
    public class EfDeletePostCommand : BaseEfCommand, IDeletePostCommand
    {
        public EfDeletePostCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var post = Context.Posts.Find(request);

            if(post == null)
            {
                throw new EntityNotFoundException("Post");
            }

            post.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
