using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DTO.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public List<HashtagItems> HashtagItems { get; set; }
        public List<CommentItems> CommentItems { get; set; }
        public List<PictureItems> PictureItems { get; set; }
    }
}
