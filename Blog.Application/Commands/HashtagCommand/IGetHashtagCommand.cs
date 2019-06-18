using Blog.Application.DTO.Hashtag;
using Blog.Application.Interfaces;
using Blog.Application.PageResponses;
using Blog.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Commands.HashtagCommand
{
    public interface IGetHashtagCommand : ICommand<HashtagSearch,PageResponse<HashtagDto>>
    {
    }
}
