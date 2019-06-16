using Blog.Application.DTO.Hashtag;
using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.HashtagCommand
{
    public interface IEditHashtagCommand : ICommand<HashtagDto>
    {
    }
}
