using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.PictureCommand;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PictureCommand
{
    public class EfDeletePictureCommand : BaseEfCommand, IDeletePictureCommand
    {
        public EfDeletePictureCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var picture = Context.Pictures.Find(request);

            if(picture == null)
            {
                throw new EntityNotFoundException("Picture");
            }

            picture.IsDeleted = true;

            Context.SaveChanges();

        }
    }
}
