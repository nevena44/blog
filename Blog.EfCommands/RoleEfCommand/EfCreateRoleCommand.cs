using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.DTO.Role;
using Blog.EfDataAccess;

namespace Blog.EfCommands.RoleEfCommand
{
    public class EfCreateRoleCommand : BaseEfCommand, ICreateRoleCommand
    {
        public EfCreateRoleCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(CreteRoleDto request)
        {
            if(Context.Roles.Any(r => r.Name.ToLower() == request.Name.Trim().ToLower()))
            {
                throw new EntryPointNotFoundException("Role Name");
            }

            Context.Roles.Add(new Domen.Role
            {
                Name = request.Name,
                IsDeleted = false
            });

            Context.SaveChanges();
        }
    }
}
