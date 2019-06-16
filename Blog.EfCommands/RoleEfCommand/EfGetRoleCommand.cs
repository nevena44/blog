using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.DTO.Role;
using Blog.Application.Searches;
using Blog.EfDataAccess;

namespace Blog.EfCommands.RoleEfCommand
{
    public class EfGetRoleCommand : BaseEfCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(BlogContext context) : base(context)
        {
        }

        public IEnumerable<RoleDto> Execute(RoleSearch request)
        {
            var role = Context.Roles.AsQueryable();

            if (request.Name != null)
            {
                role = role.Where(r => r.Name.ToLower().Contains(request.Name.Trim().ToLower()));
            }

            return role.Select(x => new RoleDto {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                IsDeleted = x.IsDeleted
            }).Where(r => r.IsDeleted == false).ToList();
            
        }
    }
}
