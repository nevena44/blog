using Blog.Application.DTO.User;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.UserCommand
{
    public interface IGetOneUserCommand : ICommand<int,UserDto>
    {
    }
}
