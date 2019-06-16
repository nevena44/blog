using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Blog.Application.Commands.PictureCommand;
using Blog.Application.DTO.Picture;
using Blog.Application.Helpers;
using Blog.EfDataAccess;

namespace Blog.EfCommands.PictureCommand
{
    public class EfEditPictureCommand : BaseEfCommand, IEditPictureCommand
    {
        public EfEditPictureCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(PictureDto request)
        {
            var ext = Path.GetExtension(request.Src.FileName); //.gif

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                throw new Exception();
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + request.Src.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                request.Src.CopyTo(new FileStream(filePath, FileMode.Create));

                var picture = Context.Pictures.Find(request);

            }
            catch (Exception)
            {
                throw new Exception("Nesto nije u redu, pokusajte kasnije");
            }
    }

    }
    }
