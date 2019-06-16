using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.HashtagCommand
{
    public interface IDeleteHashtagCommand : ICommand<int>
    {
    }
}
