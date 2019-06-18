using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
using Blog.Application.Exceptions;
using Blog.Application.Interfaces;
using Blog.EfDataAccess;

namespace Blog.EfCommands.UserEfCommand
{
    public class EFLoginCommand : BaseEfCommand, ILoginCommand
    {
        public EFLoginCommand(BlogContext context) : base(context)
        {
        }

        public UserLoginDto Execute(UserLogDto request)
        {

            if (request.Username == null)
            {
                throw new EntityNotFoundException("User");
            }

            if (request.Password == null)
            {
                throw new EntityNotFoundException("User");
            }

            if (Context.Users.Where(u => u.Username == request.Username && u.Password == request.Password).First() == null)
            {
                throw new EntityNotFoundException("User");

            }

            return Context.Users.Select(x => new UserLoginDto
            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                RoleName = x.Role.Name
            }).Where(u => u.Username == request.Username && u.Password == request.Password).First();
        }
    }
    }
    
