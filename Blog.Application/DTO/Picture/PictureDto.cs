using System;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.DTO.Picture
{
    public class PictureDto
    {
        public int Id { get; set; }
        public IFormFile Src { get; set; }
        public string Alt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int PostId { get; set; }
    }
}
