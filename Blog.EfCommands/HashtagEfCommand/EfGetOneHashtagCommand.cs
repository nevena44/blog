using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.DTO.Hashtag;
using Blog.EfDataAccess;

namespace Blog.EfCommands.HashtagEfCommand
{
    public class EfGetOneHashtagCommand : BaseEfCommand, IGetOneHashtagCommand
    {
        public EfGetOneHashtagCommand(BlogContext context) : base(context)
        {
        }

        public HashtagDto Execute(int request)
        {
            var hashtag = Context.Hashtags.Find(request);

            return Context.Hashtags.Select(x => new HashtagDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                IsDeleted = x.IsDeleted
            }).Where(h => h.Id == request).First();
        }
    }
}
