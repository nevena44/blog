using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DTO.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
