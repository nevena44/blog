using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domen
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
