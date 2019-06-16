using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string RoleName { get; set; }
    }
}
