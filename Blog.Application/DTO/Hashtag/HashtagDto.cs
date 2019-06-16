using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DTO.Hashtag
{
    public class HashtagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
