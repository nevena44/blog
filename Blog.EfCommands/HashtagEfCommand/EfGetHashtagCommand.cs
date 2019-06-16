using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.HashtagCommand;
using Blog.Application.DTO.Hashtag;
using Blog.Application.Searches;
using Blog.EfDataAccess;

namespace Blog.EfCommands.HashtagEfCommand
{
    public class EfGetHashtagCommand : BaseEfCommand, IGetHashtagCommand
    {
        public EfGetHashtagCommand(BlogContext context) : base(context)
        {
        }

        public IEnumerable<HashtagDto> Execute(HashtagSearch request)
        {
            if(request.Name!=null)
            {
                Context.Hashtags.Where(h => h.Name.ToLower().Contains(request.Name.Trim().ToLower()));
            }

            return Context.Hashtags.Select(x => new HashtagDto {
                Id =x.Id,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                Name = x.Name,
                IsDeleted = x.IsDeleted
            }).Where(h => h.IsDeleted == false).ToList();
        }
    }
}
