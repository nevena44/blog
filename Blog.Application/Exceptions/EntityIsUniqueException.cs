using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class EntityIsUniqueException : Exception
    {
        public EntityIsUniqueException(string entity) : base($"{entity} already exists.")
        {

        }

        public EntityIsUniqueException()
        {

        }
    }
}
