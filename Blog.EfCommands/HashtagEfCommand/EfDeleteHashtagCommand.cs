using System;
using System.Collections.Generic;
using System.Text;
using Blog.Application.Commands.HashtagCommand;
using Blog.EfDataAccess;

namespace Blog.EfCommands.HashtagEfCommand
{
    public class EfDeleteHashtagCommand : BaseEfCommand, IDeleteHashtagCommand
    {
        public EfDeleteHashtagCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var hashtag = Context.Hashtags.Find(request);

            if(hashtag == null)
            {
                throw new EntryPointNotFoundException("Hashtag");
            }

            hashtag.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
