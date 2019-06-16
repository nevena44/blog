using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domen
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostHashtag> PostHashtags { get; set; }
    }
}
