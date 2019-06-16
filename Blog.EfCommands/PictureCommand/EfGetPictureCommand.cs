using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.PictureCommand;
using Blog.Application.DTO.Picture;
using Blog.Application.Exceptions;
using Blog.Application.Searches;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PictureCommand
{
    public class EfGetPictureCommand : BaseEfCommand, IGetPictureCommand
    {
        public EfGetPictureCommand(BlogContext context) : base(context)
        {
        }

        public IEnumerable<PictureDto> Execute(PictureSearch request)
        {
            if(request.Alt != null)
            {
                Context.Pictures.Where(p => p.Alt.ToLower().Contains(request.Alt.Trim().ToLower()));
            }

            if(request.PostId != 0)
            {
                Context.Pictures.Where(p => p.PostId == request.PostId);
            }

            if(Context.Pictures.Any(p => p.PostId == request.PostId))
            {
                throw new EntityNotFoundException("Post");
            }


            return Context.Pictures.Select(p => new PictureDto
            {
                Id = p.Id,
                Alt = p.Alt,
                CreatedAt = p.CreatedAt,
                ModifiedAt = p.ModifiedAt,
                PostId = p.PostId
            }).Where(p => p.IsDeleted == false).ToList();
        }
    }
}
