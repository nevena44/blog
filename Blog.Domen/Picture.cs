using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domen
{
    public class Picture : BaseEntity
    {
        public string Src { get; set; }
        public string Alt { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
