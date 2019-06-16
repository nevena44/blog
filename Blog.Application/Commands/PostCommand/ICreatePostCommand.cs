using Blog.Application.DTO.Post;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.PostCommand
{
    public interface ICreatePostCommand : ICommand<CreatePostDto>
    {
    }
}
