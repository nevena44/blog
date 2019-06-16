using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.RoleCommand
{
    public interface IDeleteRoleCommand : ICommand<int>
    {
    }
}
