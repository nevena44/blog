using System;
using System.Collections.Generic;
using System.Text;
using Blog.Application.Commands.UserCommand;
using Blog.Application.Exceptions;
using Blog.EfDataAccess;

namespace Blog.EfCommands.UserEfCommand
{
    public class EfDeleteUserCommand : BaseEfCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFoundException("User");
            }

            if(user.IsDeleted == true)
            {
                throw new EntityNotFoundException("User");
            }

            user.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
