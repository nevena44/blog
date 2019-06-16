using System;
using System.Collections.Generic;
using System.Text;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.DTO.Hashtag;
using Blog.EfDataAccess;
using Blog.Application.Exceptions;

namespace Blog.EfCommands.HashtagEfCommand
{
    public class EfEditHashtagCommand : BaseEfCommand, IEditHashtagCommand
    {
        public EfEditHashtagCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(HashtagDto request)
        {
            var hashtag = Context.Hashtags.Find(request.Id);

            if(hashtag.IsDeleted == true)
            {
                throw new EntryPointNotFoundException("Hashtag");
            }

            hashtag.Name = request.Name;
            hashtag.ModifiedAt = DateTime.Now;

            Context.SaveChanges();
        }
    }
}
