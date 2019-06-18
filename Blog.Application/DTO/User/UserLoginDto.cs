using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.DTO.User
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
