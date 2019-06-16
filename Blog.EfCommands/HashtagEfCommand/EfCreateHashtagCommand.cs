using Blog.Application.Commands.HashtagCommand;
using Blog.Application.DTO.Hashtag;
using Blog.Application.Exceptions;
using Blog.Domen;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.EfCommands.HashtagEfCommand
{
    public class EfCreateHashtagCommand : BaseEfCommand, ICreateHashtagCommand
    {
        public EfCreateHashtagCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(CreateHashtagDto request)
        {
            if (Context.Hashtags.Any(h => h.Name.ToLower().Contains(request.Name.Trim().ToLower())))
            {
                throw new EntityIsUniqueException();
            }

            Context.Hashtags.Add(new Hashtag
            {
                Name = "#"+request.Name.ToUpper(),
                IsDeleted = false
            });

            Context.SaveChanges();


        }


    }
}
