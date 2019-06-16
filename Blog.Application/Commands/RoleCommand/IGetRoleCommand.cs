using Blog.Application.DTO.Role;
using Blog.Application.Interfaces;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.RoleCommand
{
    public interface IGetRoleCommand : ICommand<RoleSearch, IEnumerable<RoleDto>>
    {
    }
}
