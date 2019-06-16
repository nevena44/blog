using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entity) : base($"{entity} doesn't exist.")
        {

        }

        public EntityNotFoundException()
        {

        }
    }
}
