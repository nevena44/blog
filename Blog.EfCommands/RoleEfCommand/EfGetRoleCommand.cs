using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.RoleCommand;
using Blog.Application.DTO.Role;
using Blog.Application.PageResponses;
using Blog.Application.Searches;
using Blog.EfDataAccess;

namespace Blog.EfCommands.RoleEfCommand
{
    public class EfGetRoleCommand : BaseEfCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(BlogContext context) : base(context)
        {
        }

        public PageResponse<RoleDto> Execute(RoleSearch request)
        {
            var role = Context.Roles.AsQueryable();

            if (request.Name != null)
            {
                role = role.Where(r => r.Name.ToLower().Contains(request.Name.Trim().ToLower()));
            }

            var totalCount = role.Count();

            role = role.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PageResponse<RoleDto> {
                TotalCount = pageCount,
                PagesCount = pageCount,
                CurrentPage = request.PageNumber,
                Data = role.Select(x => new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt,
                    IsDeleted = x.IsDeleted
                }).ToList()
        };


            return response; 

        }
    }
}
