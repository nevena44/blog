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
    public class EfEditUserCommand : BaseEfCommand, IEditUserCommand
    {
        public EfEditUserCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(CreateUserDto request)
        {
            var user = Context.Users.AsQueryable();

            var userEdit = Context.Users.Find(request.Id);

            if (userEdit == null)
            {
                throw new EntityNotFoundException("User");
            }

            if(userEdit.IsDeleted == true)
            {
                throw new EntityNotFoundException("User");
            }

            if (!user.Any(u => u.RoleId == request.RoleId))
            {
                throw new EntityNotFoundException("Role");
            }

            if ((user.Any(u => u.Username.ToLower().Contains(request.Username.Trim().ToLower()))) && (!user.Any(u => u.Id == request.Id)))
            {
                throw new EntityIsUniqueException("Username");
            }

            if(user.Any(u => u.Username.ToLower().Contains(request.Username.Trim().ToLower())))
            {
                throw new EntityIsUniqueException("Username");
            }

            
            userEdit.FirstName = request.FirstName;
            userEdit.LastName = request.LastName;
            userEdit.Email = request.Email;
            userEdit.Password = request.Password;
            userEdit.ModifiedAt = DateTime.Now;
            userEdit.IsDeleted = false;
            userEdit.RoleId = request.RoleId;

            Context.SaveChanges();
        }
        }
}
