using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Application.DTO.Hashtag
{
    public class CreateHashtagDto
    {
        [Required]
        public string Name { get; set; }
    }
}
