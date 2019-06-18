using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
using Blog.Application.PageResponses;
using Blog.Application.Searches;
using Blog.EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace Blog.EfCommands.UserEfCommand
{
    public class EfGetUserCommand : BaseEfCommand, IGetUserCommand
    {
        public EfGetUserCommand(BlogContext context) : base(context)
        {
        }

        public PageResponse<UserDto> Execute(UserSearch request)
        {
            var user = Context.Users.Include(u => u.Role).AsQueryable();

            if (request.FirstName != null)
            {
                user = user.Where(u => u.FirstName.ToLower().Contains(request.FirstName.Trim().ToLower()));
            }

            if (request.LastName != null)
            {
                user = user.Where(u => u.LastName.ToLower().Contains(request.LastName.Trim().ToLower()));
            }

            if (request.Username != null)
            {
                user = user.Where(u => u.Username.ToLower().Contains(request.Username.Trim().ToLower()));
            }

            if (request.RoleId != 0)
            {
                user = user.Where(u => u.RoleId == request.RoleId);
            }

            if (request.StartDate.HasValue)
            {
                user = user.Where(p => p.CreatedAt >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                user = user.Where(p => p.CreatedAt <= request.EndDate.Value);
            }
            var totalCount = user.Count();
            user = user.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PageResponse<UserDto>
            {
                TotalCount = totalCount,
                PagesCount = pageCount,
                CurrentPage = request.PageNumber,
                Data = user.Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt,
                    RoleName = u.Role.Name
                }).ToList()
            };


            return response;

    }
    }
}
