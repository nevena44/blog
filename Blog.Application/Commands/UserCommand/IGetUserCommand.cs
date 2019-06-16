using Blog.Application.DTO.User;
using Blog.Application.Interfaces;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.UserCommand
{
    public interface IGetUserCommand : ICommand<UserSearch, IEnumerable<UserDto>>
    {
    }
}
