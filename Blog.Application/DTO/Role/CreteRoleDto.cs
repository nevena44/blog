using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Application.DTO.Role
{
    public class CreteRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
