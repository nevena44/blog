using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands;
using Blog.Application.DTO;
using Blog.EfDataAccess;

namespace Blog.EfCommands
{
    public class EfCreatePictureCommand : BaseEfCommand, ICreateImageCommand
    {
        public EfCreatePictureCommand(BlogContext context) : base(context)
        {
        }

        public int Execute(PictureDto request)
        {
            Context.Pictures.Add(new Domen.Picture
            {
                Src = request.Name,
                Alt = request.Name,
                IsDeleted = false
            });

            Context.SaveChanges();

            var slika = Context.Pictures.Where(p => p.Alt == request.Name).First();

            int id = slika.Id;

            return id;
        }
    }
}
