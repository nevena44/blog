using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.UserCommand
{
    public interface IDeleteUserCommand : ICommand<int>
    {
    }
}
