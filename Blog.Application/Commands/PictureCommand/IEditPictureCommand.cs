using Blog.Application.DTO.Picture;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.PictureCommand
{
    public interface IEditPictureCommand : ICommand<PictureDto>
    {
    }
}
