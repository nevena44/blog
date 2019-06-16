using Blog.Application.DTO.Picture;
using Blog.Application.Interfaces;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.PictureCommand
{
    public interface IGetPictureCommand : ICommand<PictureSearch,IEnumerable<PictureDto>>
    {
    }
}
