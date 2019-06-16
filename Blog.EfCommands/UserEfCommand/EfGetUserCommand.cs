using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
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

        public IEnumerable<UserDto> Execute(UserSearch request)
        {
            var user = Context.Users.Include(u => u.Role).AsQueryable();

            if(request.FirstName != null)
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

            if(request.RoleId != 0)
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

            

            return user.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                RoleName = u.Role.Name
            }).ToList();
        }
    }
}
