using Blog.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfCommands
{
    public abstract class BaseEfCommand
    {
        protected BlogContext Context { get; }
        public BaseEfCommand(BlogContext context) => Context = context;

    }
}
