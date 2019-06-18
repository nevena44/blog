using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.DTO
{
    public class PostDtoNovo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Picture { get; set; }
        [Required]
        public int UserId { get; set; }
        public List<int> HasTagIds { get; set; }
    }
}
