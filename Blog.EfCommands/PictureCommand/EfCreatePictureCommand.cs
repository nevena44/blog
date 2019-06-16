using System;
using System.Collections.Generic;
using System.Text;
using Blog.Application.Commands.PictureCommand;
using Blog.Application.DTO.Picture;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PictureCommand
{
    public class EfCreatePictureCommand : BaseEfCommand, ICreatePictureCommand
    {
        public EfCreatePictureCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(PictureDto request)
        {
            
        }
    }
}
