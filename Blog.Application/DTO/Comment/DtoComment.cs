using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DTO.Comment
{
    public class DtoComment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
