using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domen
{
    public class PostHashtag
    {
        public int HashtagId { get; set; }
        public int PostId { get; set; }
        public Hashtag Hashtag { get; set; }
        public Post Post { get; set; }
    }
}
