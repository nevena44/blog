using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domen
{
    public class Hashtag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostHashtag> PostHashtags { get; set; }
    }
}
