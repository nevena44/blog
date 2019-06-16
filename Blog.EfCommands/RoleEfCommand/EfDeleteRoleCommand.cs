using Blog.Application.Commands.RoleCommand;
using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfCommands.RoleEfCommand
{
    public class EfDeleteRoleCommand : BaseEfCommand, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(BlogContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if(role == null)
            {
                throw new EntryPointNotFoundException("Role");
            }

            Context.Roles.Find(request).IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
