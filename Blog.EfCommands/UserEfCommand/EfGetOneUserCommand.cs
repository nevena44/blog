using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.UserEfCommand
{
    public class EfGetOneUserCommand : BaseEfCommand, IGetOneUserCommand
    {
        public EfGetOneUserCommand(BlogContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException("User");
            }

            if(user.IsDeleted == true)
            {
                throw new EntityNotFoundException("User");

            }

            return Context.Users.Select(u => new UserDto {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                RoleName = u.Role.Name
            }).Where(u => u.Id == request).First();
        }
    }
}
