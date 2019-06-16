using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.PictureCommand
{
    public interface IDeletePictureCommand : ICommand<int>
    {
    }
}
