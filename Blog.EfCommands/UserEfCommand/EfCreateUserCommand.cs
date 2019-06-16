using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
using Blog.Application.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domen;
using Blog.EfDataAccess;

namespace Blog.EfCommands.UserEfCommand
{
    public class EfCreateUserCommand : BaseEfCommand, ICreateUserCommand
    {
        private readonly IEmailSender _emailSender;
        public EfCreateUserCommand(BlogContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

        public void Execute(CreateUserDto request)
        {
            if(!Context.Users.Any(u => u.RoleId == request.RoleId))
            {
                throw new EntityNotFoundException("Role");
            }

            Context.Users.Add(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                IsDeleted = false,
                RoleId = request.RoleId

            });

            Context.SaveChanges();

            _emailSender.Subject = "Uspesno ste se Registrovali";
            _emailSender.Body = "Uspesno ste se registrovali, posetite nas sajt";
            _emailSender.ToEmail = request.Email;
            _emailSender.Send();
        }
    }
}
