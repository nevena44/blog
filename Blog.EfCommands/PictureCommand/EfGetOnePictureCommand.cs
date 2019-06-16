using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.PictureCommand;
using Blog.Application.DTO.Picture;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PictureCommand
{
    public class EfGetOnePictureCommand : BaseEfCommand, IGetOnePictureCommand
    {
        public EfGetOnePictureCommand(BlogContext context) : base(context)
        {
        }

        public PictureDto Execute(int request)
        {
            var picture = Context.Pictures.Find(request);

            if(picture == null)
            {
                throw new EntityNotFoundException("Picture");
            }

            if (picture.IsDeleted == true)
            {
                throw new EntityNotFoundException("Picture");
            }

            return Context.Pictures.Select(p => new PictureDto
            {
                Id = p.Id,
                Alt = p.Alt,
                CreatedAt = p.CreatedAt,
                ModifiedAt = p.ModifiedAt,
                PostId = p.PostId
            }).Where(p => p.Id == request).First();
        }
    }
}
