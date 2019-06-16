using Blog.Application.Commands.RoleCommand;
using Blog.Application.DTO.Role;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.EfCommands.RoleEfCommand
{
    public class EfGetOneRoleCommand : BaseEfCommand, IGetOneRoleCommand
    {
        public EfGetOneRoleCommand(BlogContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if(role == null)
            {
                throw new EntityNotFoundException("Role");
            }

            if(role.IsDeleted == true)
            {
                throw new EntityNotFoundException("Role");
            }

            return Context.Roles.Select(x => new RoleDto {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                IsDeleted = x.IsDeleted
            }).Where(r => r.Id == request).First();

        }
    }
}
