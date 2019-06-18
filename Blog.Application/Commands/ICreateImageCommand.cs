using Blog.Application.DTO;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands
{
    public interface ICreateImageCommand : ICommand<PictureDto,int>
    {
    }
}
