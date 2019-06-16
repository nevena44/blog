using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.DTO.Role;
using Blog.EfDataAccess;

namespace Blog.EfCommands.RoleEfCommand
{
    public class EfEditRoleCommand : BaseEfCommand, IEditRoleCommand
    {
        public EfEditRoleCommand(BlogContext context) : base(context)
        {
        }
        public void Execute(RoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

            if(role.IsDeleted == true)
            {
                throw new EntryPointNotFoundException("That Role not found");
            }

            role.Name = request.Name;
            role.IsDeleted = false;
            role.ModifiedAt = DateTime.Now;

            Context.SaveChanges();
        }

    }
}
